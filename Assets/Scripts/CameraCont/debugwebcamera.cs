using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TextureSharings;
using Photon.Pun;
using System.Text.RegularExpressions;

public class debugwebcamera : MonoBehaviour
{
    [SerializeField] private TextureBroadcastComponent textureBroadcastComponent;
    static WebCamTexture cam;

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            WebCamCapture(22);
        }
        */
    }

    private void Awake()
    {
        cam = new WebCamTexture();
        //var tmp = GameObject.Find("webcamselector").GetComponent<WebCamSelector>();
       // webcamname = tmp.getCamname();
        //Debug.Log("lllllllllllllllllll   " + webcamname + "   lllllllllllllllllllll");
        //cam.deviceName = webcamname;
    }

     public void WebCamCapture(int key)
     {

        //transform.localScale = new Vector3((float)Screen.width, (float)Screen.height, 1);

        if (cam == null)
        {
            cam = new WebCamTexture();
           // webcamname = GameObject.Find("webcamselector").GetComponent<WebCamSelector>().getCamname();
            //Debug.Log(webcamname);
            //.deviceName = webcamname;
        }
        //  cam = new WebCamTexture();

        if (!cam.isPlaying)
        { cam.Play(); }

         StartCoroutine(TakePhoto(key));


     }

    IEnumerator TakePhoto(int key)
    {
        yield return new WaitForSeconds(1.0f);
        int tempNum = int.Parse(Regex.Replace(PhotonNetwork.NickName, @"[^0-9]", ""));

        GameObject go = GameObject.Find("Model" + tempNum.ToString());
        GameObject SelfPicture = go.transform.Find("TakenPic" + tempNum.ToString()).gameObject;


        Texture2D photo = new Texture2D(cam.width, cam.height);
        photo.SetPixels(cam.GetPixels());
        photo.Apply();

        photo = ScaleTexture(photo, 100, 100);

        SelfPicture.GetComponent<Renderer>().material.mainTexture = photo;

        SelfPicture.SetActive(false);
        SelfPicture.SetActive(true);

        textureBroadcastComponent.BroadcastTexture(photo, key);

        cam.Stop();

    }

    Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
    {
        Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, true);
        Color[] rpixels = result.GetPixels(0);
        float incX = (1.0f / (float)targetWidth);
        float incY = (1.0f / (float)targetHeight);
        for (int px = 0; px < rpixels.Length; px++)
        {
            rpixels[px] = source.GetPixelBilinear(incX * ((float)px % targetWidth), incY * ((float)Mathf.Floor(px / targetWidth)));
        }
        result.SetPixels(rpixels, 0);
        result.Apply();
        return result;
    }

}