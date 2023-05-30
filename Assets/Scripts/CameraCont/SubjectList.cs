using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using System.IO;
using UnityEngine;
using System.Text.RegularExpressions;

public class SubjectList : MonoBehaviourPun //カメラに映っているオブジェクト名のリスト
{
    public List<string> subjects = new List<string>();

    [SerializeField] private GameObject webCamera;


    void Start()
    {
        subjects = new List<string>();
    }

    void Update()
    {

    }

    public void ClearSubjects() //リストのオブジェクトを消す
    {
        for (int i = 0; i< subjects.Count; i++)
        {
            Destroy(GameObject.Find(subjects[i]));
        }
    }

    public void ChangeColor()
    {
        for (int i = 0; i< subjects.Count; i++)
        {
            GameObject.Find(subjects[i]).transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 1); //カメラの色

        }
    }

    public void SetPose()
    {
        for (int i = 0; i < subjects.Count; i++)
        {
            GameObject.Find(subjects[i]).GetComponent<IsRendered>().Pose1();
        }
    }

    public void SetBigger()
    {
        for (int i = 0; i < subjects.Count; i++)
        {
            GameObject Target = GameObject.Find(subjects[i]);
            StartCoroutine(BigStart(Target));
        }

    }

    IEnumerator BigStart(GameObject Target)
    {
        float size_big = 2f;
        float speed = 0.5f;
        float time = 0f;
        Vector3 originScale = Target.transform.localScale; ;

        while (Target.transform.localScale.x < size_big)
        {
            Target.transform.localScale = originScale * (1f + time * speed);
            time += Time.deltaTime;

            if (Target.transform.localScale.x >= size_big)
            {
                time = 0;
                break;
            }
            yield return null;
        }
    }


    public void beforeWebCamera()
    {
        if(subjects.Contains("key1(Clone)"))　//「key1」キャラクターが撮られたら、撮った人の「NickName」と、撮られた「key1」を渡す
        {
            photonView.RPC(nameof(beforeWebCamera2), RpcTarget.AllBuffered, PhotonNetwork.NickName, "key1");
        }
        else if (subjects.Contains("key2(Clone)"))
        {
            photonView.RPC(nameof(beforeWebCamera2), RpcTarget.AllBuffered, PhotonNetwork.NickName, "key2");
        }
        else if (subjects.Contains("key3(Clone)"))
        {
            photonView.RPC(nameof(beforeWebCamera2), RpcTarget.AllBuffered, PhotonNetwork.NickName, "key3");
        }
        else if (subjects.Contains("key4(Clone)"))
        {
            photonView.RPC(nameof(beforeWebCamera2), RpcTarget.AllBuffered, PhotonNetwork.NickName, "key4");
        }
    }


    [PunRPC]
    void beforeWebCamera2(string nickname, string target)
    {
        int tempNum = int.Parse(Regex.Replace(nickname, @"[^0-9]", ""));
        if (PhotonNetwork.NickName == target) //自分が撮られた人なら「例）key1」、WebCameraを実行
        {
            webCamera.GetComponent<WebCamera>().WebCamCapture(tempNum); //撮った人「VR」のニックネームを渡して、その人側の写真テクスチャを更新したい
        }
    }
}
