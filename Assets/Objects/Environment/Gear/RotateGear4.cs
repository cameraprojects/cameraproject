using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGear4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(20f, 0f, 0f) * Time.deltaTime);
    }
}
