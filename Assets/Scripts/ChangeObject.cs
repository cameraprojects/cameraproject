using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    public GameObject[] cubeArray;
    private int count;
    public GameObject cubeObj;

    void Start()
    {
        count = 0;
        cubeObj = GameObject.Instantiate(cubeArray[count])as GameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Destroy(cubeObj);
            count++;
            cubeObj = GameObject.Instantiate(cubeArray[count], cubeArray[count-1].transform.position, cubeArray[count - 1].transform.rotation) as GameObject;
            if (count == 2)
            {
                count = -1;
            }
        }

    }
}