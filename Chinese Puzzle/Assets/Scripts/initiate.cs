using UnityEngine;
using System.Collections;

public class initiate : MonoBehaviour 
{

	void Start () 
	{
		Instantiate(Resources.Load ("Prefabs/ImageManager",typeof(GameObject)));
		Instantiate(Resources.Load ("Prefabs/InputManager",typeof(GameObject)));
	}
	
}
