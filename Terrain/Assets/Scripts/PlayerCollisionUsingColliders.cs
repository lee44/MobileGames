using UnityEngine;
using System.Collections;

public class PlayerCollisionUsingColliders : MonoBehaviour 
{

	bool doorIsOpen = false;
	float doorTimer = 0.0f;
	public float doorOpenTime = 3.0f;
	public AudioClip doorOpenSound;
	public AudioClip doorShutSound;
	GameObject currentDoor;

	void Update ()
	{
		if(doorIsOpen)
		{
			doorTimer += Time.deltaTime;
		}
		if(doorTimer > doorOpenTime)
		{
			Door(doorShutSound, false, "doorshut", currentDoor);
			doorTimer = 0.0f;
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.tag == "playerDoor" && doorIsOpen == false)
		{
			currentDoor = hit.gameObject;
			Door(doorOpenSound, true, "dooropen", currentDoor);
		}
	}
	
	void Door(AudioClip aClip, bool openCheck, string animName, GameObject thisDoor)
	{
		thisDoor.GetComponent<AudioSource>().PlayOneShot(aClip);
		doorIsOpen = openCheck;
		thisDoor.transform.parent.GetComponent<Animation>().Play(animName);
	}
	
}
