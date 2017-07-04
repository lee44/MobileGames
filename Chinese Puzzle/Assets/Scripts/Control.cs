using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Control : MonoBehaviour 
{
	public Canvas optionsCanvas, sound, howtoPlay, mainMenu, category;

	void Start()
	{
		optionsCanvas = optionsCanvas.GetComponent <Canvas>();
		sound = sound.GetComponent <Canvas>();
		mainMenu = mainMenu.GetComponent <Canvas>();
		category = category.GetComponent <Canvas>();
	}
	public void quitPress()
	{
		Application.Quit();
	}
	public void optionsPress()
	{
		optionsCanvas.enabled = true;
		mainMenu.enabled = false;
	}
	public void howtoplayPress()
	{
		howtoPlay.enabled = true;
		optionsCanvas.enabled = false;
	}
	public void soundPress()
	{
		sound.enabled = true;
		optionsCanvas.enabled = false;
	}
	public void goToOptionsFromSound()
	{
		sound.enabled = false;
		optionsCanvas.enabled = true;	
	}
	public void goToMainMenuFromOptions()
	{
		optionsCanvas.enabled = false;
		mainMenu.enabled = true;	
	}
	public void goToOptionsFromHowToPlay()
	{
		howtoPlay.enabled = false;
		optionsCanvas.enabled = true;
	}
	public void playPress()
	{
		mainMenu.enabled = false;
		category.enabled = true;
	}
	public void goToMainMenuFromCategory()
	{
		mainMenu.enabled = true;
		category.enabled = false;
	}
	public void loadLevel()
	{
		Application.LoadLevel("Game");
	}
}
