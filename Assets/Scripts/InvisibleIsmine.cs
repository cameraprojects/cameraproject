using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class InvisibleIsmine : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
         if(photonView.IsMine)
        {
            //自分のカメラから見えないようにする
            //gameObject.SetActive(false);
            this.gameObject.layer=10;
            for(int i=0;i<this.transform.childCount;i++){
                this.transform.GetChild(i).gameObject.layer=10;
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
