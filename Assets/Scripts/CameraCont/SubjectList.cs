using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using System.IO;
using UnityEngine;
using System.Text.RegularExpressions;

public class SubjectList : MonoBehaviourPun //�J�����ɉf���Ă���I�u�W�F�N�g���̃��X�g
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

    public void ClearSubjects() //���X�g�̃I�u�W�F�N�g������
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
            GameObject.Find(subjects[i]).transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 1); //�J�����̐F

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
        if(subjects.Contains("key1(Clone)"))//�@//�ukey1�v�L�����N�^�[���B��ꂽ��A�B�����l�́uNickName�v�ƁA�B��ꂽ�ukey1�v��n��
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
        if (PhotonNetwork.NickName == target) //�������B��ꂽ�l�Ȃ�u��jkey1�v�AWebCamera�����s
        {
            webCamera.GetComponent<WebCamera>().WebCamCapture(tempNum); //�B�����l�uVR�v�̃j�b�N�l�[����n���āA���̐l���̎ʐ^�e�N�X�`�����X�V������
        }
    }
}
