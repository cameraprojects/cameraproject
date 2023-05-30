using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Input;
using UnityEngine.InputSystem;

public class HapticTest : MonoBehaviour
{

 

    void Start()
    {


    }

    public void HapticOne()
    {
        this.GetComponent<XRBaseController>().SendHapticImpulse(0.4f, 0.2f);
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
