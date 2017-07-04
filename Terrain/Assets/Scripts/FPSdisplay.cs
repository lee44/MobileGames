using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUIText))] 

public class FPSdisplay : MonoBehaviour 
{
	float frames = 0;
	float fps = 0;

	void Update () 
	{
		frames++;
		fps = Mathf.Round(frames / Time.realtimeSinceStartup);
		GetComponent<GUIText>().text = "Frames Per Second: " + fps;
	}
}
