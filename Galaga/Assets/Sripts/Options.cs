using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour 
{
float speed = 23, time;
private bool showLabel = false;
public AudioClip clip, clip2;
Vector3 scale;

public void Start() 
{
	time = Time.time;
	Invoke("ToggleLabel", 0);
	Invoke("playSound", 23);
	Invoke("Done",47);  
}

public void ToggleLabel()        
{
	showLabel = !showLabel;
	GetComponent<AudioSource>().clip = clip;
	GetComponent<AudioSource>().Play();
}
public void playSound()
{
	//AudioSource.PlayClipAtPoint(clip,transform.position);
	GetComponent<AudioSource>().clip = clip2;
	GetComponent<AudioSource>().Play();
}
public void Done()
{
	Application.LoadLevel("Game");  
	GameManager.started = false;
	EnemySpawn.spawn = false;
}
void Update()
{
	speed+=.9f;
}

void OnGUI () 
{
	//Set the GUIStyle style to be label
	GUIStyle style = GUI.skin.GetStyle ("label"); 
	
	//Set the style font size to increase and decrease over time
	style.fontSize = (int)(25.0f);

	scale.x = Screen.width/347; // calculate hor scale
	scale.y = Screen.height/617; // calculate vert scale
	scale.z = 1;
	Matrix4x4 svMat = GUI.matrix; // save current matrix
	// substitute matrix - only scale is altered from standard
	GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
	// draw your GUI controls here:

		time = 740 - speed ;
		//Create a label and display with the current settings 
		GUI.Label (new Rect (347/2 - 145, time, 400, 700), "            Credits \n\nDirected By Joshua Lee \n\n\nProduced By Joshua Lee\n\n\nProgrammed By Joshua Lee \n\n\nGraphics Design By \nJoshua Lee \n\n\nSpecial Thanks to \nJoshua Lee \n\n\nOkay You Get the Point \nI Created The Game Bitches");
		  
		GUI.matrix = svMat; // restore matrix
	
}
  
}
   