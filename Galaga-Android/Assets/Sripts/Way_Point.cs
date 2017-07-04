// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Way_Point : MonoBehaviour 
{
	//   This is a very simple waypoint system.
	//   Each bit is explained in as much detail as possible for people (like me!) who need every single line explained.
	//
	//   As a side note to the inexperienced (like me at the moment!), you can delete the word "private" on any variable to see it in the inspector for debugging.
	//
	//   I am sure there are issues with this as is, but it seems to work pretty well as a demonstration.
	//
	//STEPS:
	//1. Attach this script to a GameObject with a RidgidBody and a Collider.
	//2. Change the "Size" variable in "Waypoints" to the number of waypoints you want to use.
	//3. Drop your waypoint objects on to the empty variable slots.
	//4. Make sure all your waypoint objects have colliders. (Sphere Collider is best IMO).
	//5. Click the checkbox for "is Trigger" to "On" on the waypoint objects to make them triggers.
	//6. Set the Size (radius for sphere collider) or just Scale for your waypoints.
	//7. Have fun! Try changing variables to get different speeds and such.
	//
	//   Disclaimer:
	//   Extreeme values will start to mess things up.
	//   Maybe someone more experienced than me knows how to improve it.
	//   Please correct me if any of my comments are incorrect.
	
	public float accel= 0.8f; //This is the rate of accelleration after the function "Accell()" is called. Higher values will cause the object to reach the "speedLimit" in less time.
	
	public float inertia= 0.9f; //This is the the amount of velocity retained after the function "Slow()" is called. Lower values cause quicker stops. A value of "1.0f" will never stop. Values above "1.0f" will speed up.
	
	public float speedLimit= 10.0f; //This is as fast the object is allowed to go.
	
	public float minSpeed= 1.0f; //This is the speed that tells the functon "Slow()" when to stop moving the object.
	
	//float stopTime = 1.0f; //This is how long to pause inside "Slow()" before activating the function "Accell()" to start the script again.
	
	//This variable "currentSpeed" is the major player for dealing with velocity.
	//The "currentSpeed" is mutiplied by the variable "accel" to speed up inside the function "accell()".
	//Again, The "currentSpeed" is multiplied by the variable "inertia" to slow things down inside the function "Slow()".
	private float currentSpeed = 0.0f;
	
	//The variable "functionState" controlls which function, "Accell()" or "Slow()", is active. "0" is function "Accell()" and "1" is function "Slow()".
	//private float functionState= 0;
	
	private bool generate = false;
	
	//This variable will store the "active" target object (the waypoint to move to).
	private Transform waypoint ;
	
	//This is the speed the object will rotate to face the active Waypoint.
	//float rotationDamping = 1.0f;
	
	//If this is false, the object will rotate instantly toward the Waypoint. If true, you get smoooooth rotation baby!
	public bool smoothRotation = true;
	
	//This variable is an array. []< that is an array container if you didnt know. It holds all the Waypoint Objects that you assign in the inspector.
	public Transform[] waypoints;
	
	//This variable keeps track of which Waypoint Object, in the previously mentioned array variable "waypoints", is currently active.
	int WPindexPointer;
	public int Path;
	
void Start()
{
	Path = (int)Random.Range(1,3);
}	
void  Update ()
{
		/**/
	if((Path == 0 || Path == 1) && generate == false)
	{
		WPindexPointer = 0;
		generate = true;
	}
	else if( (Path == 3 || Path == 2) && generate == false)
	{
		WPindexPointer = 7;
		generate = true;
	}
	
	waypoint = waypoints[WPindexPointer]; //Keep the object pointed toward the current Waypoint object.	
	Accell ();
}
void  Accell ()
{

//I grabbed this next part from the unity "SmoothLookAt" script but try to explain more.
if (waypoint) //If there is a waypoint do the next "if".
{
	if (smoothRotation) //If smoothRotation is set to "On", do the rotation over time with nice ease in and ease out motion.
	{
		//Looks at the active waypoint. Transform.position - waypoint.position gives u the direction 
		//the waypoint is at and Vector3.Forward means the z-axis is now the upward axis instead of y
		Quaternion newRotation= Quaternion.LookRotation(transform.position - waypoint.position, Vector3.forward);
		newRotation.x = 0;
		newRotation.y = 0;
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
		transform.rotation = newRotation;
	}
}
	//Now do the accelleration toward the active waypoint untill the "speedLimit" is reached
	currentSpeed = currentSpeed + accel * accel;
	transform.Translate (0,Time.deltaTime * currentSpeed,0);
	
	//When the "speedlimit" is reached or exceeded ...
	if (currentSpeed >= speedLimit)
	{
		// ... turn off accelleration and set "currentSpeed" to be exactly the "speedLimit". Without this, the "currentSpeed will be slightly above "speedLimit"
		currentSpeed = speedLimit;
	}
}
	
//The function "OnTriggerEnter" is called when a collision happens.
void  OnTriggerEnter ( Collider other)
{
	if(other.tag == "Path")
	{
		//functionState = 1; //When the GameObject collides with the waypoint's collider, activate "Slow()" by setting "functionState" to "1".
		if(WPindexPointer < 6)   
			WPindexPointer++;  //When the GameObject collides with the waypoint's collider, change the active waypoint to the next one in the array variable "waypoints".
		else if( WPindexPointer < 16)  
			WPindexPointer++;		
	}   
	//When the array variable reaches the end of the list ...
	//if (WPindexPointer >= 7)
	//{
		//WPindexPointer = 0; // ... reset the active waypoint to the first object in the array variable "waypoints" and start from the beginning.
		//transform.position = new Vector3(-0.2833158f,12.90102f,-2.8f);
	//}
}
/*
void  Slow ()
{
	if (slowState == false)
	{                  
		accelState = false; //Make sure that if Slow() is running, Accell() can not run.
		slowState = true;  
	}                 
	//Begin to do the slow down (or speed up if inertia is set above "1.0f" in the inspector).
	currentSpeed = currentSpeed * inertia;
	transform.Translate (0,0,Time.deltaTime * currentSpeed);
	
	//When the "minSpeed" is reached or exceeded ...
	if (currentSpeed <= minSpeed)
	{
		currentSpeed = 0.0f; // ... Stop the movement by setting "currentSpeed to Zero.
		//yield WaitForSeconds (stopTime); //Wait for the amount of time set in "stopTime" before moving to next waypoint.
		functionState = 0; //Activate the function "Accell()" to move to next waypoint.
	}
}*/

}