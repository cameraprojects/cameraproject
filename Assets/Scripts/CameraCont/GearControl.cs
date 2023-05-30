using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GearControl : MonoBehaviourPun
{

    GameObject[] G1_Objects;
    GameObject[] G2_Objects;
    GameObject[] G3_Objects;
    public GameObject gearSound;

    // Start is called before the first frame update
    void Start()
    {

    }



    [PunRPC]
    void GearSS()
    {

        G1_Objects = GameObject.FindGameObjectsWithTag("Gear1");
        G2_Objects = GameObject.FindGameObjectsWithTag("Gear2");
        G3_Objects = GameObject.FindGameObjectsWithTag("Gear3");

        for (int i = 0; i < G1_Objects.Length; i++)
        {
            if (!G1_Objects[i].GetComponent<RotateGear>().enabled)
            {
                G1_Objects[i].GetComponent<RotateGear>().enabled = true;
            }
            else
            {
                G1_Objects[i].GetComponent<RotateGear>().enabled = false;
            }

        }
        for (int i = 0; i < G2_Objects.Length; i++)
        {
            if (!G2_Objects[i].GetComponent<RotateGear2>().enabled)
            {
                G2_Objects[i].GetComponent<RotateGear2>().enabled = true;
            }
            else
            {
                G2_Objects[i].GetComponent<RotateGear2>().enabled = false;
            }
        }
        for (int i = 0; i < G3_Objects.Length; i++)
        {
            if (!G3_Objects[i].GetComponent<RotateGear3>().enabled)
            {
                G3_Objects[i].GetComponent<RotateGear3>().enabled = true;
            }
            else
            {
                G3_Objects[i].GetComponent<RotateGear3>().enabled = false;
            }
        }


        if (!gearSound.GetComponent<AudioSource>().enabled)
        {
            gearSound.GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            gearSound.GetComponent<AudioSource>().enabled = false;
        }

    }    

    public void GearStartRotate()
    {
        photonView.RPC(nameof(GearSS), RpcTarget.AllBuffered);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
