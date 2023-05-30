using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace UdpReceiver
{
    public class UdpLogger : MonoBehaviourPun, IUdpCallback
    {
        [SerializeField] private int _receivePort = 40002;

        private Udp _udp;
        private Character_Effect _characterEffect;

        private void Start()
        {
            _characterEffect = GetComponent<Character_Effect>();
            _udp = new Udp();
            _udp.InitRcvClient(_receivePort);
            _udp.ReceiveMessage(this, out _);
        }

        private void OnApplicationQuit()
        {
            _udp.CloseClient();
        }

        private string _tmp;
        private bool _received = false;
        public void OnReceivedCallback(string val)
        {
            // valに受信した文字列が渡されるので、以下で必要な処理を行う
            _tmp = val;
            _received = true;
        }

        private void Update()
        {
            if (_received)
            {
                if (photonView.IsMine)
                {
                    _characterEffect.emset = int.Parse(_tmp);
                }
                _received = false;
            }
        }
    }
}