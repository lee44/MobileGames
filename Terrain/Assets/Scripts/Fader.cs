using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour 
{
	public GUITexture loadGUI;

	void LoadAnim()
	{
		//pg 372
		Instantiate(loadGUI);
	}
	void Start()
	{
		//pg 338
		Rect currentRes = new Rect(-Screen.width * 0.5f, -Screen.height * 0.5f, Screen.width, Screen.height);
		GetComponent<GUITexture>().pixelInset = currentRes;
	}
}
