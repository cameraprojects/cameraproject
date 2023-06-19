using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Text.RegularExpressions;


public class FireWorksPlay : MonoBehaviourPun
{
    [SerializeField]
    private GameObject fireworksParticle;

    public GameObject laserParticle;
    public GameObject hoshiParticle;
    public GameObject shootingstarParticle;
    
    
    public void PlayFireWorks()
    {
        photonView.RPC(nameof(PlayFireWorksss), RpcTarget.AllBuffered, PhotonNetwork.NickName);
        //PhotonNetwork.Instantiate("Fireworks", new Vector3(0f, 0f, 0f), Quaternion.identity, eventpos);
        //fireworksParticle.SetActive(true);
        //StartCoroutine(PauseFireWorks());
    }
    public void Punstar()
    {
        photonView.RPC(nameof(PlayHoshi), RpcTarget.AllBuffered);
    }
    public void Punshootingstar()
    {
        photonView.RPC(nameof(PlaySS), RpcTarget.AllBuffered);
    }
    [PunRPC]
    void PlayFireWorksss(string nickname)
    {
        Debug.Log("PlayFireWorksss");
        // string tempNum = Regex.Replace(nickname, @"[^0-9]", "");
        // GameObject parentObject = GameObject.Find("EventPos " + tempNum);
        GameObject parentObject = GameObject.Find("EventPos " + nickname);
        GameObject fireworks1 = Instantiate(fireworksParticle);
        //fireworks1.transform.localPosition = parentObject.transform.localPosition;
        //fireworks1.transform.localRotation = parentObject.transform.localRotation;
        fireworks1.transform.parent = parentObject.transform;
        fireworks1.transform.localPosition = new Vector3(0, 0, 0);
        fireworks1.transform.rotation = parentObject.transform.rotation;
        Destroy(fireworks1, 10.0f);
    }

    /*
    IEnumerator PauseFireWorks()
    {
        yield return new WaitForSeconds(10.0f);
        fireworksParticle.SetActive(false);
    }
    */


    /*
    public void PlayLaser()
    {
        laserParticle.SetActive(true);

        StartCoroutine(PauseLaser());
    }
    IEnumerator PauseLaser()
    {
        yield return new WaitForSeconds(10.0f);
        laserParticle.SetActive(false);
    }
    */
    [PunRPC]
    public void PlayHoshi()
    {
       if (hoshiParticle.activeSelf)
        {
            hoshiParticle.SetActive(false);
        }
        else
        {
            hoshiParticle.SetActive(true);
        }
    }
    [PunRPC]
    public void PlaySS()
    {
        if (shootingstarParticle.activeSelf)
        {
           shootingstarParticle.SetActive(false);
        }
        else
        {
           shootingstarParticle.SetActive(true);
        }
    }
}
