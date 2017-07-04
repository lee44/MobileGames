using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class MainMenuBtns : MonoBehaviour 
{
	public string levelToLoad;
	public Texture2D normalTexture;
	public Texture2D rollOverTexture;
	public AudioClip beep;
	public bool quitButton = false;

	void Update () 
	{
	
	}
	void OnMouseEnter()
	{
		GetComponent<GUITexture>().texture = rollOverTexture; 
	}
	void OnMouseExit()
	{
		GetComponent<GUITexture>().texture = normalTexture;
	}
	IEnumerator OnMouseUp() //pg 317
	{
		AudioSource.PlayClipAtPoint(beep,new Vector3(-360f,314f,816f));
		yield return new WaitForSeconds(0.35f);

		if(quitButton)
		{
			Application.Quit();
		}
		else
			Application.LoadLevel(levelToLoad);
	}
}
