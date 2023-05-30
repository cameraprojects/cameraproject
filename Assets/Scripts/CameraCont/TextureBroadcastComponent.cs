using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Sample.Scripts;
using UniRx;


namespace TextureSharings
{
    public class TextureBroadcastComponent : MonoBehaviourPunCallbacks, IOnEventCallback
    {
        public GameObject[] photopics;


        public enum StreamingBytesEventCode
        {
            BeginStream = 10,
            Streaming = 11,
        }

        [SerializeField] int messagePerSecond = 100; // 100 Messages / Second

        int bytePerMessage = 1000; // 1KBytes / Message


        //public Texture2D ShareTexture; // ★ Readable texture ★

        bool isReceiving;
        byte[] receiveBuffer;
        int totalDataSize;
        int currentReceivedDataSize;
        int receivedMessageCount;

        #region sender methods

        public void BroadcastTexture(Texture2D tex, int key)
        {
            //int key = 2;

            byte[] rawKeyData = BitConverter.GetBytes(key);
            byte[] rawTextureData = tex.DeCompress().EncodeToPNG();
            byte[] dist = new byte[rawKeyData.Length + rawTextureData.Length];
            Buffer.BlockCopy(rawKeyData, 0, dist, 0, rawKeyData.Length);
            Buffer.BlockCopy(rawTextureData, 0, dist, rawKeyData.Length, rawTextureData.Length);
            int width = tex.width;
            int height = tex.height;
            int dataSize = dist.Length;
            int viewId = this.photonView.ViewID;


            Debug.Log("uouuuoouo");
            StreamTextureDataToOtherClients(dist, width, height, dataSize, viewId);
        }

        void StreamTextureDataToOtherClients(byte[] rawTextureData, int width, int height, int dataSize, int viewId)
        {
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            {
                CachingOption = EventCaching.DoNotCache,
                Receivers = ReceiverGroup.Others,
            };

            SendOptions sendOptions = new ExitGames.Client.Photon.SendOptions
            {
                Reliability = true,
            };

            // Send info
            int[] textureInfo = new int[4];
            textureInfo[0] = viewId;
            textureInfo[1] = width;
            textureInfo[2] = height;
            textureInfo[3] = dataSize;
            PhotonNetwork.RaiseEvent((byte) StreamingBytesEventCode.BeginStream, textureInfo, raiseEventOptions,
                sendOptions);

            // Send raw data
            // The SlowDown operator is not necessary if you ignore the limit on the number of messages per second of Photon Cloud.
            rawTextureData.ToObservable()
                .Buffer(bytePerMessage)
                // .SlowDown(1.0f/messagePerSecond)
                .Subscribe(byteSubList =>
                {
                    byte[] sendData = new byte[byteSubList.Count];
                    byteSubList.CopyTo(sendData, 0);
                    PhotonNetwork.RaiseEvent((byte) StreamingBytesEventCode.Streaming, sendData, raiseEventOptions,
                        sendOptions);
                });
        }

        #endregion

        #region receiver methods

        //**************************************************
        //  These methods are executed in receiver clients
        //**************************************************
        public void OnEvent(ExitGames.Client.Photon.EventData photonEvent)
        {
            if (photonEvent.Code == (byte) StreamingBytesEventCode.BeginStream)
            {
                int[] data = (int[]) photonEvent.Parameters[ParameterCode.Data];
                OnReceivedTextureInfo(data);
            }

            if (photonEvent.Code == (byte) StreamingBytesEventCode.Streaming)
            {
                byte[] data = (byte[]) photonEvent.Parameters[ParameterCode.Data];

                OnReceivedRawTextureDataStream(data);
            }
        }

        void OnReceivedTextureInfo(int[] data)
        {
            int viewId = data[0];
            if (viewId != this.photonView.ViewID)
            {
                this.isReceiving = false;
                this.totalDataSize = 0;
                this.currentReceivedDataSize = 0;
                this.receivedMessageCount = 0;
                return;
            }

            this.isReceiving = true;
            this.currentReceivedDataSize = 0;
            this.receivedMessageCount = 0;

            int width = data[1];
            int height = data[2];
            int dataSize = data[3];
            this.totalDataSize = dataSize;
            this.receiveBuffer = new byte[dataSize];
        }

        void OnReceivedRawTextureDataStream(byte[] data)
        {
            Debug.Log("uouuusssssssoouo");
            if (this.isReceiving)
            {
                data.CopyTo(this.receiveBuffer, this.currentReceivedDataSize);
                this.currentReceivedDataSize += data.Length;
                this.receivedMessageCount++;

                if (this.currentReceivedDataSize >= (this.totalDataSize))
                {
                    this.isReceiving = false;
                    this.currentReceivedDataSize = 0;
                    this.receivedMessageCount = 0;

                    OnReceivedRawTextureData();
                }
            }
        }

        void OnReceivedRawTextureData()
        {
            byte[] keyData = new byte[4];
            byte[] texData = new byte[receiveBuffer.Length - 4];
            Buffer.BlockCopy(receiveBuffer, 0, keyData, 0, keyData.Length);
            Buffer.BlockCopy(receiveBuffer, keyData.Length, texData, 0, texData.Length);
            Debug.Log(BitConverter.ToInt32(keyData, 0));
            Texture2D tex = new Texture2D(256, 256);
            tex.LoadImage(texData);
            tex.Apply();

            OnReceivedEvent(BitConverter.ToInt32(keyData, 0), tex);
        }

        void OnReceivedEvent(int key, Texture2D tex)
        {
            Debug.Log(key);
            Renderer target = photopics[key-1].GetComponent<Renderer>(); //findで撮った人(vr"key")の(召喚された)写真オブジェクトをtargetに指定しましょう

            target.material.mainTexture = tex;
        }

        #endregion
    }
}