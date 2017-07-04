using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Settings : MonoBehaviour 
{
	public Toggle easy, anime, animals, cars, celebrities, models, basketball;
	public bool hardCore, normal;
	public Image hardC, norm;

	public void Awake () 
	{
		DontDestroyOnLoad (transform.gameObject);
	}
	public void HardCore()
	{
		hardCore = true;
		hardC.enabled = true;
		norm.enabled = false;
		
	}
	public void Normal()
	{
		normal = true;
		hardC.enabled = false;
		norm.enabled = true;;
	}
}
