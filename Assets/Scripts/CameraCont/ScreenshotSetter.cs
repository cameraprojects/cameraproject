using Photon.Pun;
using System.IO;
using UnityEngine;
using System.Text.RegularExpressions;
using System;


public class ScreenshotSetter : MonoBehaviourPun
{
	public Renderer[] PhotoPics; //VR���[�U�[���̎ʐ^�I�u�W�F�N�g
	public Renderer[] PhotoStand;
	public GameObject[] objects; //�ʂ��Ă���l���X�g
	 //���f�����[�U�[���̎ʐ^�I�u�W�F�N�g
	private int i=0;
	public void Start()
    {

	}

	[PunRPC]
	void TakePics(string nickname)
	{
		string filePath = Application.dataPath + "/Pictures/CameraScreenShot/";
		GameObject cameratemp = GameObject.Find("Camera" + nickname);
		Camera _cameratemp = cameratemp.GetComponent<Camera>();

		int tempNum = int.Parse(Regex.Replace(nickname, @"[^0-9]", ""));
		var rt = new RenderTexture(_cameratemp.pixelWidth, _cameratemp.pixelHeight, 32);
		var prev = _cameratemp.targetTexture;
		_cameratemp.targetTexture = rt;
		_cameratemp.Render();
		_cameratemp.targetTexture = prev;
		RenderTexture.active = rt;

		Debug.Log("===========================================================");

		Texture2D screenShot = new Texture2D(
			_cameratemp.pixelWidth,
			_cameratemp.pixelHeight,
			TextureFormat.ARGB32,
			false);

		
		screenShot.ReadPixels(new Rect(0, 0, screenShot.width, screenShot.height), 0, 0);
		screenShot.Apply();
		var bytes = screenShot.EncodeToPNG();

		if (PhotonNetwork.NickName == nickname)
        {
			File.WriteAllBytes(filePath + DateTime.Now.ToString().Replace('/', '-').Replace(':', '.') + ".png", bytes);
		}
		
		PhotoPics[tempNum - 1].material.mainTexture = rt;
		PhotoStand[i].material.mainTexture = rt;
		i=(i+1)%PhotoStand.Length;
		Destroy(screenShot);
	}


	[PunRPC]
	void TakePics2(string nickname, string nickname2)
	{
		string filePath = Application.dataPath + "/Pictures/CameraScreenShot/";
		GameObject cameratemp = GameObject.Find("Camera" + nickname);
		Camera _cameratemp = cameratemp.GetComponent<Camera>();

		int tempNum = int.Parse(Regex.Replace(nickname, @"[^0-9]", ""));
		int tempNum2 = int.Parse(Regex.Replace(nickname2, @"[^0-9]", ""));

		GameObject ggo = GameObject.Find("Model Stage");
		GameObject go = ggo.transform.Find("Model" + tempNum2.ToString()).gameObject;
		GameObject oo = go.transform.Find("TakenPic" + tempNum2.ToString()).gameObject;
		Renderer target = oo.GetComponent<Renderer>();

		
		var rt = new RenderTexture(_cameratemp.pixelWidth, _cameratemp.pixelHeight, 32);
		var prev = _cameratemp.targetTexture;
		_cameratemp.targetTexture = rt;
		_cameratemp.Render();
		_cameratemp.targetTexture = prev;
		RenderTexture.active = rt;

		Debug.Log("===========================================================");

		Texture2D screenShot = new Texture2D(
			_cameratemp.pixelWidth,
			_cameratemp.pixelHeight,
			TextureFormat.ARGB32,
			false);


		screenShot.ReadPixels(new Rect(0, 0, screenShot.width, screenShot.height), 0, 0);

		screenShot.Apply();



		var bytes = screenShot.EncodeToPNG();





		if (PhotonNetwork.NickName == nickname)
		{
			File.WriteAllBytes(filePath + DateTime.Now.ToString().Replace('/', '-').Replace(':', '.') + ".png", bytes);
		}
		
		else if (PhotonNetwork.NickName == nickname2)
		{
			oo.SetActive(false);
			oo.SetActive(true);


			target.material.mainTexture = rt; //�B��ꂽ���f�����̎ʐ^���X�V����

			File.WriteAllBytes(filePath + DateTime.Now.ToString().Replace('/', '-').Replace(':', '.') + ".png", bytes);
		
		}
		

		PhotoPics[tempNum - 1].material.mainTexture = rt; //�����uVR�v���̎ʐ^���X�V����
		PhotoStand[i].material.mainTexture = rt;
		i=(i+1)% PhotoStand.Length;
		Destroy(screenShot);
	}


	public void TakeScreenshot()
	{
		//return;
		//string filePath = "Assets/Pictures/CameraScreenShot/";
		//string filePath = Application.dataPath + "/Pictures/CameraScreenShot/";





		if (objects[0]. GetComponent<SubjectList>().subjects.Contains("key1(Clone)")) //�����B��ꂽ�L�����N�^�[���A���f���ukey1�v�̏ꍇ
		{
			photonView.RPC(nameof(TakePics2), RpcTarget.AllBuffered, PhotonNetwork.NickName, "key1");
		}
		else if (objects[0].GetComponent<SubjectList>().subjects.Contains("key2(Clone)"))
		{
			photonView.RPC(nameof(TakePics2), RpcTarget.AllBuffered, PhotonNetwork.NickName, "key2");
		}
		else if (objects[0].GetComponent<SubjectList>().subjects.Contains("key3(Clone)"))
		{
			photonView.RPC(nameof(TakePics2), RpcTarget.AllBuffered, PhotonNetwork.NickName, "key3");
		}
		else if (objects[0].GetComponent<SubjectList>().subjects.Contains("key4(Clone)"))
		{
			photonView.RPC(nameof(TakePics2), RpcTarget.AllBuffered, PhotonNetwork.NickName, "key4");
		}
		else
        {
			photonView.RPC(nameof(TakePics), RpcTarget.AllBuffered, PhotonNetwork.NickName);
		}


	}


}
