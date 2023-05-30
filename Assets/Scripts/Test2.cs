using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Sample
{
    public class Test2 : MonoBehaviourPun, IConnectionCallbacks, IPunInstantiateMagicCallback
    {
        [SerializeField] private RootMotion.FinalIK.VRIK ik;
        [SerializeField] private Transform selfHead, selfRight, selfLeft;
        private Transform head, left, right;
        private bool nonVR = false;

        private void Start()
        {
            if (this.photonView.IsMine)
            {
                head = GameObject.Find("XR Origin/Camera Offset/Main Camera1").transform;
                right = GameObject.Find("XR Origin/Camera Offset/Right Ray Interactor").transform;
                left = GameObject.Find("XR Origin/Camera Offset/Left Ray Interactor").transform;

            }

        }

        private void Update()
        {

            if (this.photonView.IsMine)
            {

                if(Input.GetKey("a")){
                    GameObject.Find("XR Origin").transform.position+=new Vector3(0.01f,0,0);
                    head.transform.position+=new Vector3(0.01f,0,0);
                    left.transform.position+=new Vector3(0.01f,0,0);
                    right.transform.position+=new Vector3(0.01f,0,0);
                }if(Input.GetKey("w")){
                    GameObject.Find("XR Origin").transform.position+=new Vector3(0,0,0.01f);
                    head.transform.position+=new Vector3(0,0,0.01f);
                    left.transform.position+=new Vector3(0,0,0.01f);
                    right.transform.position+=new Vector3(0,0,0.01f);
                }if(Input.GetKey("s")){
                    GameObject.Find("XR Origin").transform.position+=new Vector3(0,0,-0.01f);
                    head.transform.position+=new Vector3(0,0,-0.01f);
                    left.transform.position+=new Vector3(0,0,-0.01f);
                    right.transform.position+=new Vector3(0,0,-0.01f);
                }if(Input.GetKey("d")){
                    GameObject.Find("XR Origin").transform.position+=new Vector3(-0.01f,0,0);
                    head.transform.position+=new Vector3(-0.01f,0,0);
                    left.transform.position+=new Vector3(-0.01f,0,0);
                    right.transform.position+=new Vector3(-0.01f,0,0);
                }
                selfHead.transform.position = head.transform.position;
                selfHead.transform.rotation = head.transform.rotation;

                selfLeft.transform.position = left.transform.position;
                selfLeft.transform.rotation = left.transform.rotation;

                selfRight.transform.position = right.transform.position;
                selfRight.transform.rotation = right.transform.rotation;

                

            }
        }


        private void OnEnable()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        public void OnPhotonInstantiate(PhotonMessageInfo info)
        {
            Debug.Log(info.photonView.ViewID);
        }

        private void OnDisable()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        public void OnConnected()
        {

            Debug.Log(this.photonView.ViewID);

            Debug.Log("Connect");
        }

        public void OnConnectedToMaster()
        {
            Debug.Log(this.photonView.ViewID);
        }

        public void OnDisconnected(DisconnectCause cause)
        {

        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {

        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {

        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
        }
    }
}