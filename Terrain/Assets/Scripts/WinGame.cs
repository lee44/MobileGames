using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour 
{
	public GameObject winSequence;
	public GUITexture fader;
	public AudioClip winClip;

	//Note that in C# it is necessary to use the prefix IEnumerator rather than void in
	//order to allow this function to behave as a co-routine, meaning that we will be able
	//to implement a pause within it, by using the yield command. A co-routine is a function that can suspend its execution by using the yield command
	
	IEnumerator GameOver () 
	{
		AudioSource.PlayClipAtPoint(winClip, transform.position);
		Instantiate(winSequence);
		yield return new WaitForSeconds(8.0f);
		Instantiate(fader);
	}
}
