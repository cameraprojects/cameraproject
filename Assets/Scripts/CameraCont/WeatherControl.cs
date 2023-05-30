using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WeatherControl : MonoBehaviourPun
{
    public GameObject weather;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Punrain()
    {
        photonView.RPC(nameof(StartRain), RpcTarget.AllBuffered);
    }
    [PunRPC]
    void StartRain(){
        if (weather.activeSelf)
        {
            weather.SetActive(false);
        }
        else
        {
            weather.SetActive(true);
        }
    }
}
