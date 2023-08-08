using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;
using Photon.Pun;
using System.Text.RegularExpressions;

public class CameraTrigger : MonoBehaviourPun
{
    // Start is called before the first frame update
    [SerializeField] private InputActionReference triggerButton;
    public GameObject cameraControl;
    [SerializeField] private GameObject xrcontroller;
    

    void Start()
    {
        triggerButton.action.started += cameraTake;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void cameraTake(InputAction.CallbackContext context)
    {
        Debug.Log("DEBUG");

        // string tempNum = Regex.Replace(PhotonNetwork.NickName, @"[^0-9]", "");
        string tempNum=PhotonNetwork.NickName;
        cameraControl.GetComponent<CameraControlScript>().RandomDraw();

        photonView.RPC(nameof(playsound), RpcTarget.AllBuffered, tempNum);
        xrcontroller.GetComponent<HapticTest>().HapticOne();
    }

    [PunRPC]
    void playsound(string tempNum)
    {
        GameObject cameraSound = GameObject.Find("RensLing " + tempNum);
        if(cameraSound){
                    cameraSound.GetComponent<CameraSoundPlay1>().TakeSoundPlay();
        }
    }
}