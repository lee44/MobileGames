#pragma strict
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
 
 
 
 
var accel = 0.8; //This is the rate of accelleration after the function "Accell()" is called. Higher values will cause the object to reach the "speedLimit" in less time.
 
var inertia = 0.9; //This is the the amount of velocity retained after the function "Slow()" is called. Lower values cause quicker stops. A value of "1.0" will never stop. Values above "1.0" will speed up.
 
var speedLimit = 10.0; //This is as fast the object is allowed to go.
 
var minSpeed = 1.0; //This is the speed that tells the functon "Slow()" when to stop moving the object.
 
var stopTime = 1.0; //This is how long to pause inside "Slow()" before activating the function "Accell()" to start the script again.
 
//This variable "currentSpeed" is the major player for dealing with velocity.
//The "currentSpeed" is mutiplied by the variable "accel" to speed up inside the function "accell()".
//Again, The "currentSpeed" is multiplied by the variable "inertia" to slow things down inside the function "Slow()".
private var currentSpeed = 0.0;
 
//The variable "functionState" controlls which function, "Accell()" or "Slow()", is active. "0" is function "Accell()" and "1" is function "Slow()".
private var functionState = 0;
 
//The next two variables are used to make sure that while the function "Accell()" is running, the function "Slow()" can not run (as well as the reverse).
private var accelState : boolean;
private var slowState : boolean;
 
//This variable will store the "active" target object (the waypoint to move to).
private var waypoint : Transform;
 
//This is the speed the object will rotate to face the active Waypoint.
var rotationDamping = 6.0;
 
//If this is false, the object will rotate instantly toward the Waypoint. If true, you get smoooooth rotation baby!
var smoothRotation = true;
 
//This variable is an array. []< that is an array container if you didnt know. It holds all the Waypoint Objects that you assign in the inspector.
var waypoints : Transform[];
 
//This variable keeps track of which Waypoint Object, in the previously mentioned array variable "waypoints", is currently active.
private var WPindexPointer : int;

static var start = false;

function Start ()
{
   functionState = 0; //When the script starts set "0" or function Accell() to be active.    
}

function Update ()
{
   if(start)
   Accell ();
   /*
   if (functionState == 0) //If functionState variable is currently "0" then run "Accell()". Withouth the "if", "Accell()" would run every frame.
   {
      Accell ();
   }
   if (functionState == 1) //If functionState variable is currently "1" then run "Slow()". Withouth the "if", "Slow()" would run every frame.
   {
      Slow ();
   }
   */
   waypoint = waypoints[WPindexPointer]; //Keep the object pointed toward the current Waypoint object.
   
}
 
function Accell ()
{
   if (accelState == false) //
   {                   //
      accelState = true;    //Make sure that if Accell() is running, Slow() can not run.
      slowState = false;    //
   }
                      //
//I grabbed this next part from the unity "SmoothLookAt" script but try to explain more.
   if (waypoint) //If there is a waypoint do the next "if".
   {
      if (smoothRotation) //If smoothRotation is set to "On", do the rotation over time with nice ease in and ease out motion.
      {
        //Looks at the active waypoint. Transform.position - waypoint.position gives u the direction 
        //the waypoint is at and Vector3.Forward means the z-axis is now the upward axis instead of y
    	var newRotation = Quaternion.LookRotation(transform.position - waypoint.position, Vector3.forward);
   		newRotation.x = 0.0;
    	newRotation.y = 0.0;
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
function OnTriggerEnter (other : Collider)
{
   if(other.tag == "Path")
   {
   functionState = 1; //When the GameObject collides with the waypoint's collider, activate "Slow()" by setting "functionState" to "1".
   WPindexPointer++;  //When the GameObject collides with the waypoint's collider, change the active waypoint to the next one in the array variable "waypoints".
   }
   
   
   
   //When the array variable reaches the end of the list ...
   if (WPindexPointer >= waypoints.Length)
   {
      WPindexPointer = 0; // ... reset the active waypoint to the first object in the array variable "waypoints" and start from the beginning.
      transform.position = Vector3(-0.2833158,12.90102,-2.8);
   }
}
  
//I declared "Slow()".
function Slow ()
{
   if (slowState == false) //
   {                  //
      accelState = false; //Make sure that if Slow() is running, Accell() can not run.
      slowState = true;   //
   }                  //
   
   //Begin to do the slow down (or speed up if inertia is set above "1.0" in the inspector).
   currentSpeed = currentSpeed * inertia;
   transform.Translate (0,0,Time.deltaTime * currentSpeed);
   
   //When the "minSpeed" is reached or exceeded ...
   if (currentSpeed <= minSpeed)
      {
      currentSpeed = 0.0; // ... Stop the movement by setting "currentSpeed to Zero.
      yield WaitForSeconds (stopTime); //Wait for the amount of time set in "stopTime" before moving to next waypoint.
      functionState = 0; //Activate the function "Accell()" to move to next waypoint.
   }
}