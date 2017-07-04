using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))] //Tells Unity to add a AudioSource Component to the object this script is attached to

public class CoconutThrower : MonoBehaviour 
{
	public AudioClip throwSound;
	public Rigidbody coconutPrefab; //pg 237
	public float throwSpeed = 30.0f;
	public static bool canThrow = false; //pg 249, static means canThrow is a global variable accessable by other scripts

	void Update () 
	{
		if(Input.GetButtonDown("Fire1") && canThrow)
		{
			GetComponent<AudioSource>().PlayOneShot(throwSound);
			Rigidbody newCoconut = Instantiate(coconutPrefab, transform.position, transform.rotation) as Rigidbody;
			newCoconut.name = "coconut";
			newCoconut.velocity = transform.forward * throwSpeed; //transform.forward is (0,0,1) z-direction.
			
			//Physics Engine will ignore collision between player and coconut. transform.root simply finds the ultimate parent object of any objects that the Launcher is attached
			Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), newCoconut.GetComponent<Collider>(), true); 
		}
	}
}
