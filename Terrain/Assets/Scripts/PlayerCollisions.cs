using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour 
{
	GameObject currentDoor;

	void Update () 
	{
		RaycastHit hit;
		
		if(Physics.Raycast (transform.position, transform.forward,out hit, 3))
			if(hit.collider.gameObject.tag == "playerDoor")
			{
				currentDoor = hit.collider.gameObject;

				//SendMessage is a function that calls DoorCheck function in DoorManager class so you dont have to instantiate a variable of type DoorManager and call 
				// the function using that variable. Page 179
				currentDoor.SendMessage("DoorCheck");
			}
		
	}
}