using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���J�ڂ�����ꍇ�ɕK�v
using System.IO;


public class InputWorlddebug : MonoBehaviour
{
    public string deviceNum;
    public bool model = false, cameraman = false;
    //WebCamDevice[] camDevice;
    //string nametarget = "Virtual";
    //string webcamName;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //camDevice = WebCamTexture.devices;
        //webcamName = camDevice[0].name;
        //Debug.Log(webcamName);
        string filePath = Application.dataPath + "/Pictures/CameraScreenShot/";
        if (System.IO.Directory.Exists(filePath))
        {
            //写真を保存するフォルダーが存在する時  
            Debug.Log("filepath exits");
        }
        else
        {
            //していない時
            Debug.Log("filepath dont exits createfolder");
            System.IO.Directory.CreateDirectory(filePath);
        }
        DontDestroyOnLoad(gameObject); //�V�[����؂�ւ��Ă��폜���Ȃ�
    }
    public void ModelSelect(){
        if(!model){model=true;}
    }
    public void CameramanSelect(){
        if(!cameraman){cameraman=true;}
    }

    // Update is called once per frame
    void Update()
    { 
            if(Input.GetKey(KeyCode.Alpha1)||model)
            {
                Debug.Log("Model");
                deviceNum = "1";             
            }
            else if(Input.GetKey(KeyCode.Alpha2)||cameraman)
            {
                Debug.Log("Camera Man");
                deviceNum = "2";
            }
            else if(Input.GetKey(KeyCode.Alpha3))
            {
                Debug.Log("Camera Man Keyboard");
                deviceNum = "3";
            }
        }
}
