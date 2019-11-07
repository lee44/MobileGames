using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour 
{
	Vector3 scale;

public void Start() 
{
	EnemySpawn.spawn = false;
	GameManager.started = false;
	Invoke("ToggleLabel",5);  
}
	
public void ToggleLabel()        
{
	Application.LoadLevel("Game");
}	
void OnGUI () 
{
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
		 
	GUI.Label(new Rect(347/2 - 75, 720/2-50, 200,200), "GameOver");

	GUI.matrix = svMat;
}

}
