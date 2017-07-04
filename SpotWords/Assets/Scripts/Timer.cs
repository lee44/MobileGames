using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
	private float startTime; 
	private float restSeconds; 
	private int roundedRestSeconds; 
	private float displaySeconds; 
	private float displayMinutes; 
	public int CountDownSeconds = 120; 
	private float Timeleft; 
	string timetext; 

void Start () 
{
	startTime = Time.deltaTime; 
}
void Update()
{
		Timeleft = Time.time - startTime; 
		restSeconds = CountDownSeconds - (Timeleft); 
		roundedRestSeconds = Mathf.CeilToInt(restSeconds); 
		displaySeconds = roundedRestSeconds % 60; 
		displayMinutes = (roundedRestSeconds / 60) % 60; 
		timetext = (displayMinutes.ToString() + ":"); 
		
		if (displaySeconds == 9) 
		{
			guiText.text = timetext + displaySeconds.ToString(); 
		}
		else if(displaySeconds == 0)
		{
			guiText.text = timetext + "0" + displaySeconds.ToString(); 
		}
		else
			guiText.text = timetext + displaySeconds.ToString();
}
    
}
/*
public class Timer : MonoBehaviour 
{ 
	private float startTime; 
	private float restSeconds; 
	private int roundedRestSeconds; 
	private float displaySeconds; 
	private float displayMinutes; 
	public int CountDownSeconds = 120; 
	private float Timeleft; 
	string timetext; 
	public Font font;

void Start () 
{
	startTime = Time.deltaTime; 
}
void OnGUI() 
{ 
	Timeleft = Time.time - startTime; 
	restSeconds = CountDownSeconds - (Timeleft); 
	roundedRestSeconds = Mathf.CeilToInt(restSeconds); 
	displaySeconds = roundedRestSeconds % 60; 
	displayMinutes = (roundedRestSeconds / 60) % 60; 
	timetext = (displayMinutes.ToString() + ":"); 
	
	if (displaySeconds == 9) 
	{
		timetext = timetext + displaySeconds.ToString(); 
	}
	else if(displaySeconds == 0)
	{
		timetext = timetext + "0" + displaySeconds.ToString(); 
	}
	else
		timetext = timetext + displaySeconds.ToString(); 
	
	GUI.skin.font = font;
	GUI.Label(new Rect(Screen.width / 2 - 50, 0.0f, 100.0f, 50.0f), timetext); 
}
}*/