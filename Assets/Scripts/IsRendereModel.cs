using UnityEngine;
using Photon.Pun;

public class IsRendereModel : MonoBehaviour
{
    public GameObject objectList;
    //メインカメラに付いているタグ名
    private const string MAIN_CAMERA_TAG_NAME = "CameraView";

    //カメラに表示されているか

    int cameraNum = 0;

    void Start()
    {
        objectList = GameObject.FindGameObjectWithTag("SubjectScript");
    }

    public void Update()
    {
        TakeList(cameraNum);
        cameraNum = 0;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 tempPos = other.GetComponent<Transform>().position;
            tempPos.y = transform.position.y;
            transform.LookAt(tempPos);
        }
    }


    //カメラに映ってる間に呼ばれる
    void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRenderedを有効に
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            PhotonView _photonView = Camera.current.GetComponent<PhotonView>();

            if(_photonView.IsMine)
            {
                cameraNum++;
            }
        }
    }

    void TakeList(int num)
    {
        switch (num)
        {
            case 0:

                if (objectList.GetComponent<SubjectList>().subjects.Contains(this.name) == true)
                {
                    objectList.GetComponent<SubjectList>().subjects.Remove(this.name);
                }

                break;

            case 1:

                if (objectList.GetComponent<SubjectList>().subjects.Contains(this.name) == false)
                {
                    objectList.GetComponent<SubjectList>().subjects.Add(this.name);
                }

                break;

            default:
                break;
        }
    }
}