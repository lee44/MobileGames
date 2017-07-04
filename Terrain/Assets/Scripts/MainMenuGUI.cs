using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class MainMenuGUI : MonoBehaviour //pg 328
{
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect playButton;
	public Rect instructionsButton;
	public Rect quitButton;
	Rect menuAreaNormalized;
	string menuPage = "main";
	public Rect instructions, back;

	void Start () //pg 338
	{
		menuAreaNormalized = new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f),menuArea.y * Screen.height - (menuArea.height * 0.5f),menuArea.width, menuArea.height);
	}
	void OnGUI()
	{
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuAreaNormalized);

		if(menuPage == "main")
		{
			if(Application.CanStreamedLevelBeLoaded("Island"))
			{
				if(GUI.Button(new Rect(playButton), "Play"))
				{
					StartCoroutine("ButtonAction", "Island");
				}
			}
			else
			{
				float percentLoaded = Application.GetStreamProgressForLevel(1) * 100;
				GUI.Box(new Rect(playButton),"Loading.. " + percentLoaded.ToString("f0") + "%"); //f0 removes decimals from the float stored in percentLoaded
			}
			if(GUI.Button(new Rect(instructionsButton), "Instructions"))
			{
				GetComponent<AudioSource>().PlayOneShot(beep);
				menuPage = "instructions";
			}
			if(Application.platform != RuntimePlatform.OSXWebPlayer && Application.platform != RuntimePlatform.WindowsWebPlayer)
			{
				if(GUI.Button(new Rect(quitButton), "Quit"))
				{
					StartCoroutine("ButtonAction", "quit");
				}
			}
		}
		else if(menuPage == "instructions")
		{
			GUI.Label(new Rect(instructions),"You awake on a mysterious island...Find a way to signal for help or face certain doom!");
			
			if(GUI.Button(new Rect(back), "Back"))
			{
				GetComponent<AudioSource>().PlayOneShot(beep);
				menuPage = "main";
			}
		}

		GUI.EndGroup();
	}
	IEnumerator ButtonAction(string levelName)
	{
		GetComponent<AudioSource>().PlayOneShot(beep);

		yield return new WaitForSeconds(.35f);
		
		if(levelName != "quit")
		{
			Application.LoadLevel(levelName);
		}
		else
		{
			Application.Quit();
			Debug.Log("Have Quit");
		}
	}
}
