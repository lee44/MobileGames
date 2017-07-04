using UnityEngine;
using System.Collections;

public class TidyObject : MonoBehaviour 
{
	public float removeTime = 3.0f;

	void Start () 
	{
		Destroy(gameObject, removeTime);
	}
}
