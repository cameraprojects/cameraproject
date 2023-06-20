using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public int c=0;   
    void Start()
    {
        LeftButton.action.started += UIOpen;
        filePath = Application.dataPath + "/Pictures/CameraScreenShot/";
    }

    void UIOpen(InputAction.CallbackContext context)
    {
        if (vrui.activeSelf)
        {
            c=vrui.transform.childCount;
            for(int i=0;i<c;i++){
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
         foreach (string file in Directory.GetFiles(filePath,"*.png"))
        {
            byte[] bytes = File.ReadAllBytes(file);
            Texture2D texture = new Texture2D(10, 10);
		    texture.filterMode = FilterMode.Trilinear;
		    texture.LoadImage(bytes);
            var newbutton = Instantiate(Pictures,this.transform.position,this.transform.rotation,vrui.transform);
            newbutton.GetComponent<Image>().sprite = Sprite.Create(texture,new Rect(0,0, texture.width,texture.height),Vector2.zero) ;
            
        }
    }
}
