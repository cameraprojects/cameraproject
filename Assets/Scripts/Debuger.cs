using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Debuger : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Awake()
    {
        if (photonView.IsMine)
        {
            this.transform.GetChild(0).gameObject.AddComponent<AudioListener>();
            this.transform.GetChild(0).gameObject.tag="MainCamera";
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
