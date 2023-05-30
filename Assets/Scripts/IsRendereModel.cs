using UnityEngine;
using Photon.Pun;

public class IsRendereModel : MonoBehaviour
{
    public GameObject objectList;
    //���C���J�����ɕt���Ă���^�O��
    private const string MAIN_CAMERA_TAG_NAME = "CameraView";

    //�J�����ɕ\������Ă��邩

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


    //�J�����ɉf���Ă�ԂɌĂ΂��
    void OnWillRenderObject()
    {
        //���C���J�����ɉf����������_isRendered��L����
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