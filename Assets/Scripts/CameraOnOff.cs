using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnOff : MonoBehaviour
{

    public MeshRenderer screenRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOn()
    {
        screenRenderer.material.color = Color.white;
    }

    public void TurnOff()
    {
        screenRenderer.material.color = Color.black;
    }
}
