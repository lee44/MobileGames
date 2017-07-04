using UnityEngine;
using System.Collections;

public class PowerCell : MonoBehaviour 
{
	public float rotationSpeed = 100.0f;
	
	void Update () 
	{
		transform.Rotate(new Vector3(0,rotationSpeed * Time.deltaTime ,0));
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			col.gameObject.SendMessage("CellPickup");
			Destroy(gameObject);
		}
	}
}
