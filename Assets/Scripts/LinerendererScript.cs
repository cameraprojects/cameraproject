using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerendererScript : MonoBehaviour
{
    LineRenderer linerend;
    // Start is called before the first frame update
    void Start()
    {
        linerend = gameObject.AddComponent<LineRenderer>();

        Vector3 pos1 = new Vector3(0, -3, 0);
        Vector3 pos2 = new Vector3(0, 3, 0);

        // ���������ꏊ���w�肷��
        linerend.SetPosition(0, pos1);
        linerend.SetPosition(1, pos2);

    }

    // Update is called once per frame
    // void Update()
    //{
        
    //}
}
