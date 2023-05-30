using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            if(cam1.activeSelf){
                cam2.SetActive(true);
                cam1.SetActive(false);
            }else if(cam2.activeSelf){
                cam1.SetActive(true);
                cam2.SetActive(false);
            }
        }
    }
}
