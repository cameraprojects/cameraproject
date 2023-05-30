using UnityEngine;
using System;
using System.IO;

[RequireComponent(typeof(Camera))]
public class ScreenshotHandlerBuiltin : ScreenshotHandlerBase
{
	public RenderTexture TextureSet; //renderしたテクスチャ

	private void Awake()
	{
		m_Camera = GetComponent<Camera>();
	}

	private void OnPostRender()
	{
		if (m_bTakeScreenshotNextFrame == false)
		{
			return;
		}

		m_bTakeScreenshotNextFrame = false;

		RenderTexture renderTexture = m_Camera.targetTexture;

		Texture2D renderResult = new Texture2D(
			renderTexture.width,
			renderTexture.height,
			TextureFormat.ARGB32,
			//TextureFormat.RGBAHalf,
			//TextureFormat.RGBAFloat,
			false);










		Rect rect = new Rect(0f, 0f, renderTexture.width, renderTexture.height);
		renderResult.ReadPixels(rect, 0, 0);





		/*
		RenderTexture.active = m_Camera.targetTexture;

		var tex = new Texture2D(m_Camera.targetTexture.width, m_Camera.targetTexture.height);
		tex.ReadPixels(new Rect(0, 0, m_Camera.targetTexture.width, m_Camera.targetTexture.height), 0, 0);
		tex.Apply();

		//string savePath = Path.Combine(saveLoad.imageOutputPath, );

		File.WriteAllBytes("Assets/SavePics/" + "Shot_" + ".png", tex.EncodeToPNG());



		
		Color[] Pixel = renderResult.GetPixels();
		for (int i = 0; i < Pixel.Length; ++i)
		{
			Color Rgb = new Color();
			for (int j = 0; j < 3; ++j)
			{
				Rgb[j] = Mathf.LinearToGammaSpace(Pixel[i][j]);
			}
			Pixel[i] = Rgb;
		}
		renderResult.SetPixels(Pixel);
		*/


		onScreenshotTaken?.Invoke(renderResult);
		m_Camera.targetTexture = TextureSet;
	}
}
