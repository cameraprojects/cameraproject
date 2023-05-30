using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using System.Text.RegularExpressions;

public class CameraControlScript : MonoBehaviourPun
{
    public GameObject objects;

    public GameObject subjectlist;
    // Start is called before the first frame update
    public GameObject[] photoPrefabs;

    public int countCam;

    private XRController xr;

    public int _randomrange=15;

    void Start()
    {
        countCam = 0;
        //xr = (XRController)GameObject.FindObjectOfType(typeof(XRController));
        //objects[11].GetComponent<WhaleControl>().WhaleStart(); //�~
    }
    void Update()
    {
    }

    void ActivateHaptic()
    {
       // xr.SendHapticImpulse(0.7f, 2f);   
    }

    public void RandomDraw()
    {
        int random = Random.Range(0, _randomrange);
        switch(random)
        {
            case 0:
                SpawnPhoto();
                //花火
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
               objects.GetComponent<FireWorksPlay>().PlayFireWorks(); //�ԉ�
               //objects[4].GetComponent<SubjectList>().beforeWebCamera(); //�E�F�u�J����
                Debug.Log("happning number1");
                break;

            case 1:
                SpawnPhoto();
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                //歯車が回り始める
                objects.GetComponent<GearControl>().GearStartRotate(); //����
                Debug.Log("happning number2");

                break;

            case 2:
                SpawnPhoto();
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                //カメラの色が変わる
                objects.GetComponent<ChangeCameraColor>().ChangeColor(); //�J�����̐F
                //objects[4].GetComponent<SubjectList>().beforeWebCamera(); //�E�F�u�J����
                Debug.Log("happning number3");

                break;

            case 3:
                SpawnPhoto();
                //objects[0].GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                //ウェブカメラで撮影
                subjectlist.GetComponent<SubjectList>().beforeWebCamera(); //�E�F�u�J����
                Debug.Log("happning number4");

                break;

            case 4:
                SpawnPhoto();
                //クジラ
                //objects[0].GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                Debug.Log("happning number5");
                objects.GetComponent<WhaleControl>().WhaleStart();
                //objects[4].GetComponent<SubjectList>().beforeWebCamera(); //�E�F�u�J����

                break;
            case 5:
                SpawnPhoto();
                //列車
                //objects[0].GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                Debug.Log("happning number6");
                objects.GetComponent<TrainControl>().StartTrainEvent();
                //objects[4].GetComponent<SubjectList>().beforeWebCamera(); //�E�F�u�J����

                break;
            case 6:
                SpawnPhoto();
                //カメラマンが大きくなる　未実装
                //objects[0].GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                Debug.Log("happning number7");
                //objects[4].GetComponent<SubjectList>().beforeWebCamera(); //�E�F�u�J����

                break;
            case 7:
                SpawnPhoto();
                //雨
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                Debug.Log("happning number8");
                
                objects.GetComponent<WeatherControl>().Punrain(); //�E�F�u�J����
                
                break;
            case 8:
                SpawnPhoto();
                //星　
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                Debug.Log("happning number9");
                objects.GetComponent<FireWorksPlay>().Punstar();
                break;
            case 9:
                SpawnPhoto();
                //流れ星
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                Debug.Log("happning number10");
                objects.GetComponent<FireWorksPlay>().Punshootingstar();
                break;
            default:
                SpawnPhoto();
                //流れ星
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                break;
        }

    
    }
    public void staticDraw(int n)
    {
       switch(n)
        {
            case 0:
                SpawnPhoto();
                //花火
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
               objects.GetComponent<FireWorksPlay>().PlayFireWorks(); //�ԉ�
               //objects[4].GetComponent<SubjectList>().beforeWebCamera(); //�E�F�u�J����
                Debug.Log("happning number1");
                break;

            case 1:
                SpawnPhoto();
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                //歯車が回り始める
                objects.GetComponent<GearControl>().GearStartRotate(); //����
                Debug.Log("happning number2");

                break;

            case 2:
                SpawnPhoto();
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                //カメラの色が変わる
                objects.GetComponent<ChangeCameraColor>().ChangeColor(); //�J�����̐F
                //objects[4].GetComponent<SubjectList>().beforeWebCamera(); //�E�F�u�J����
                Debug.Log("happning number3");

                break;

            case 3:
                SpawnPhoto();
                //objects[0].GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                //ウェブカメラで撮影
                objects.GetComponent<SubjectList>().beforeWebCamera(); //�E�F�u�J����
                Debug.Log("happning number4");

                break;

            case 4:
                SpawnPhoto();
                //クジラ
                //objects[0].GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                Debug.Log("happning number5");
                objects.GetComponent<WhaleControl>().WhaleStart();
                //objects[4].GetComponent<SubjectList>().beforeWebCamera(); //�E�F�u�J����

                break;
            case 5:
                SpawnPhoto();
                //列車
                //objects[0].GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                Debug.Log("happning number6");
                objects.GetComponent<TrainControl>().StartTrainEvent();
                //objects[4].GetComponent<SubjectList>().beforeWebCamera(); //�E�F�u�J����

                break;
            case 6:
                SpawnPhoto();
                //カメラマンが大きくなる　未実装
                //objects[0].GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                Debug.Log("happning number7");
                //objects[4].GetComponent<SubjectList>().beforeWebCamera(); //�E�F�u�J����

                break;
            case 7:
                SpawnPhoto();
                //雨
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                Debug.Log("happning number8");
                
                objects.GetComponent<WeatherControl>().Punrain(); //�E�F�u�J����
                
                break;
            case 8:
                SpawnPhoto();
                //星　
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                Debug.Log("happning number9");
                objects.GetComponent<FireWorksPlay>().Punstar();
                break;
            case 9:
                SpawnPhoto();
                //流れ星
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); //�ʐ^�B�e
                Debug.Log("happning number10");
                objects.GetComponent<FireWorksPlay>().Punshootingstar();
                break;
            default:
                SpawnPhoto();
                objects.GetComponent<ScreenshotSetter>().TakeScreenshot(); 
                break;
        }
          
     
    }
    public void SpawnPhoto()
    {
        photonView.RPC(nameof(SpawnPhotoSS), RpcTarget.AllBuffered, PhotonNetwork.NickName);
    }

    [PunRPC]
    void SpawnPhotoSS(string nickname)
    {
        int tempNum = int.Parse(Regex.Replace(nickname, @"[^0-9]", ""));
        GameObject SpawnPose = GameObject.Find("SpawnLocation "+tempNum.ToString());

        photoPrefabs[tempNum-1].transform.position = SpawnPose.transform.position;
        photoPrefabs[tempNum-1].transform.rotation = SpawnPose.transform.rotation;
        photoPrefabs[tempNum-1].SetActive(true);
    }



}
