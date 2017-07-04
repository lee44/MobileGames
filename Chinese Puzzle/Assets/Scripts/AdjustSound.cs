using UnityEngine;
using System.Collections;

public class AdjustSound : MonoBehaviour 
{
	public void sound(float newSound)
	{
		gameObject.GetComponent<AudioSource>().volume = newSound;
	}
}
