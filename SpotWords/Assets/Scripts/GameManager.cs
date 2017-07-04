using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
public static int level = 3, score = 0;
public Font font;

void Update () 
{
	
}

void OnGUI()
{
	GUI.skin.font = font;
	GUI.Label(new Rect(0f, 0.0f, 110.0f, 70.0f),"Score "+ score);
}

}