using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WhaleControl : MonoBehaviourPun
{
    public GameObject whale;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator WhaleMove(GameObject a, Vector3 toPos)
    {
        float count = 0f;
        Vector3 wasPos = a.transform.position;
        while (true)
        {
            count += Time.deltaTime;
            a.transform.position = Vector3.Lerp(wasPos, toPos, count / 60f);
            if (count > 60f)
            {
                a.transform.position = toPos;
                a.SetActive(false);
                a.transform.position=wasPos;
                break;
            }
            yield return null;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
    
    public void WhaleStart()
    {
        photonView.RPC(nameof(moveWhole), RpcTarget.AllBuffered);
    }
    [PunRPC]
    void moveWhole(){
        if (whale.activeSelf)
        {
            
        }
        else
        {
            whale.SetActive(true);
            StartCoroutine(WhaleMove(whale, target.position));
        }
    }
}
