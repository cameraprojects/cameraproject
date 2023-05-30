using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Text.RegularExpressions;

public class ChangeCameraColor : MonoBehaviourPun
{


    public void ChangeColor()
    {
        photonView.RPC(nameof(ChageColorss), RpcTarget.AllBuffered, PhotonNetwork.NickName);
        
    }

    [PunRPC]
    void ChageColorss(string nickname)
    {
        string tempNum = Regex.Replace(nickname, @"[^0-9]", "");

        GameObject go = GameObject.Find("vrcamera " + tempNum);
        Renderer target = go.transform.Find("Camera.001").gameObject.GetComponent<Renderer>();
        
        target.material.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 1); //ÉJÉÅÉâÇÃêF
    }    
}
