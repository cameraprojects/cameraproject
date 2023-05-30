using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainControl2 : MonoBehaviour
{
    public GameObject Train;
    public Transform target2;
    // Start is called before the first frame update
    void Start()
    {

    }
    IEnumerator TrainMove(GameObject a, Vector3 toPos)
    {
        float count = 0;
        Vector3 wasPos = a.transform.position;
        while (true)
        {
            count += Time.deltaTime;
            a.transform.position = Vector3.Lerp(wasPos, toPos, count / 20);
            if (count == 1)
            {
                a.transform.position = toPos;
                break;
            }
            yield return null;
        }
    }

    public void EndTrainEvent()
    {
        StartCoroutine(TrainMove(Train, target2.position));
    }









    // Update is called once per frame
    void Update()
    {

    }
}
