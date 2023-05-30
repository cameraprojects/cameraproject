using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;

public class SwitchCamera : MonoBehaviour
{

    [SerializeField] private InputActionReference changeaction;
    public GameObject camera1;
    public GameObject camera2;
    //XROrigin scrip;
    int WhereCamera = 0;
    // Start is called before the first frame update
    void Start()
    {
        //scrip = camera1.GetComponent<m_TargetDisplay>();

        changeaction.action.started += SwitchCam;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CameraObject"))
        {
            WhereCamera = 1;
            Debug.Log("CameraIn");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CameraObject"))
        {
            WhereCamera = 0;
        }
    }

    void SwitchCam(InputAction.CallbackContext context)
    {
        if(camera2.activeSelf == true )
        {

                camera1.SetActive(true);
                camera2.SetActive(false);

            
        }
        else
        {
            if (WhereCamera == 1)
            {
                camera1.SetActive(false);
                  camera2.SetActive(true);
            }
        }
        //if (scrip.m_Camera == camera1) { scrip.m_Camera = camera2; }
        //else { scrip.m_Camera = camera1; }
    }

}
