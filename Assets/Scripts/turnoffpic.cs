using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnoffpic : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("turnoffThis",5.0f);
    }

    // Update is called once per frame
    void turnoffThis()
    {
        this.gameObject.SetActive(false);
    }
}
