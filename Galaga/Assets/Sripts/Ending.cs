using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour 
{
public float speed = 20;
private bool showLabel = false;
	
public void Start() 
{
	Invoke("ToggleLabel", 2);
}

public void ToggleLabel()        
{
	showLabel = !showLabel;
} 

void OnGUI () 
{
	//Set the GUIStyle style to be label
	GUIStyle style = GUI.skin.GetStyle ("label"); 
	
	//Set the style font size to increase and decrease over time
	style.fontSize = (int)(25.0f);

	if (!showLabel) 
		GUI.Label(new Rect(Screen.width/2 - 80, Screen.height/2, 200,200), "GameOver");  
	else
	{
		//Create a label and display with the current settings 
		GUI.Label (new Rect (Screen.width/2 - 100, 650 - speed * Time.time, 380, 580), "Directed By Joshua Lee \n\n\nProduced By Joshua Lee\n\n\nProgrammed By Joshua Lee \n\n\nGraphics Design By Joshua Lee \n\n\nSpecial Thanks to Joshua Lee \n\n\nOkay You Get the Point \nI Created This Game Bitches");
	}	
}

}
