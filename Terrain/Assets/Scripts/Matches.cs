using UnityEngine;
using System.Collections;

public class Matches : MonoBehaviour 
{
	void Update () 
	{
	
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			col.gameObject.SendMessage("MatchPickup");
			Destroy(gameObject);
		}
	}
}
