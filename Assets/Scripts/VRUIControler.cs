using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;
using Photon.Pun;
using System.Text.RegularExpressions;
using System.IO;
public class VRUIControler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private InputActionReference LeftButton;
    public GameObject vrui; 
    private string filePath;
    private string[] _fileinfo;
    public GameObject Pictures;
    //public int c=0;   
    void Start()
    {
        LeftButton.action.started += UIOpen;
        filePath = Application.dataPath + "/Pictures/CameraScreenShot/";
        vrui.transform.Find("Scrollbar").GetComponent<Scrollbar>().onValueChanged.AddListener(scrollbarmoved);
    }
    void scrollbarmoved(float val){
         int c=vrui.transform.childCount;
            for(int i=1;i<c;i++){
                if(vrui.transform.GetChild(i)){
                    vrui.transform.GetChild(i).localPosition=new Vector3(vrui.transform.GetChild(i).localPosition.x,-(float)(i/5)*15f+vrui.transform.Find("Scrollbar").GetComponent<Scrollbar>().value*(float)(vrui.transform.Find("Scrollbar").GetComponent<Scrollbar>().numberOfSteps),vrui.transform.GetChild(i).localPosition.z);
                }
            }
    }
    
    void UIOpen(InputAction.CallbackContext context)
    {
        if (vrui.activeSelf)
        {
            int c=vrui.transform.childCount;
            for(int i=1;i<c;i++){
                if(vrui.transform.GetChild(i)){
                    Destroy(vrui.transform.GetChild(i).gameObject);
                }
            }
            vrui.SetActive(false);
        }
        else
        {
            vrui.SetActive(true);
            UIUpdate();
        }
    }

    void UIUpdate(){
        int i=0; 
        foreach (string file in Directory.GetFiles(filePath,"*.png"))
        {
            Vector3 photopos=new Vector3((float)(i%5-2)*0.1f,-(float)(i/5)*0.1f,0);
            byte[] bytes = File.ReadAllBytes(file);
            Texture2D texture = new Texture2D(1, 1);
		    texture.filterMode = FilterMode.Trilinear;
		    texture.LoadImage(bytes);
            var newbutton = Instantiate(Pictures,this.transform.position+photopos,this.transform.rotation,vrui.transform);
            newbutton.GetComponent<Image>().sprite = Sprite.Create(texture,new Rect(0,0, texture.width,texture.height),Vector2.zero) ;
            i++;
        }
        
        vrui.transform.Find("Scrollbar").GetComponent<Scrollbar>().numberOfSteps=(i/5)+1;
    }
}
