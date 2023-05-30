using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRhappningDegug : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cameracontroler;
    private static int i = 0; 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            cameracontroler.GetComponent<CameraControlScript>().RandomDraw();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            cameracontroler.GetComponent<CameraControlScript>().staticDraw((i++)%10);
        }
    }
}