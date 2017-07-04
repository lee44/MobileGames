using UnityEngine;
using System.Collections;

public class CameraRatio : MonoBehaviour 
{
	// set the desired aspect ratio (the values in this example are
	// hard-coded for 16:9, but you could make them into public
	// variables instead so you can set them at design time)
	public float targetaspect = 347f / 617.0f;	
	
	void Start () 
	{
		Camera.main.orthographicSize = 347f/(((347f/617f)*2)*32);
		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;
		
		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;
		
		// obtain camera component so we can modify its viewport
		Camera camera = GetComponent<Camera>();
		
		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f)
		{  
			Rect rect = camera.rect;
			
			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;
			
			camera.rect = rect;
		}
		else // add pillarbox
		{
			float scalewidth = 1.0f / scaleheight;
			
			Rect rect = camera.rect;
			
			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;
			
			camera.rect = rect;
		}
		//float width = Screen.width, height = Screen.height, s = 32;
		//camera.orthographicSize = width / (((width / height) * 2) * s);
	}
}