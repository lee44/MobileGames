using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{

public Texture texture;
public static GameManager instance;
public int TotalShips, ShipsKilled, playerLives, level = 1;
public Transform playerShip;
public GameObject player;
public EnemySpawn enemySpawn;
public static bool started = false;
public bool gracePeriod;
float originalWidth = 347,originalHeight = 617;
public float timer, time, totalTime;
Vector3 scale;

void Start()
{
	//creates a reference to itself so other scripts can access GameManger's data members
	instance = this;
	//Screen.SetResolution(270,480,true);
}
void Update ()  
{
	if(started)
	{
		timer = Time.time;
		if (player == null && playerLives == 3)
		{
			time = timer;
			EnemySpawn.spawn = true;  
			player = ((Transform)Instantiate (playerShip, new Vector3 (0, -6f, -2.8f), Quaternion.Inverse(playerShip.rotation))).gameObject; 		
			playerLives--;	
		}
		else if(player == null && playerLives == 2 && gracePeriod != true)
		{
			time = timer;
			gracePeriod = true;
			EnemySpawn.spawn = false;	
			EnemyShot.immune = true;
			Enemy.immune = true;
		}
		else if(player == null && playerLives == 1 && gracePeriod != true)
		{	
			time = timer;
			gracePeriod = true;
			EnemySpawn.spawn = false;	
			EnemyShot.immune = true;
			Enemy.immune = true;
		}
		else if(player == null && playerLives == 0)
		{
			Invoke("ToggleLabel",2);   
		}
		if(gracePeriod)
			respawn();
	}
	
	if(ShipsKilled > (level*10))
		level++;
}
public void ToggleLabel()        
{
	Application.LoadLevel("GameOver");
}
public void respawn() 
{
	EnemySpawn.spawn = false;
	totalTime = timer - time;
	if(totalTime > 1 && level != 3)
	{   
		Enemy.immune = false;
		EnemyShot.immune = false;
		EnemySpawn.spawn = true;
		gracePeriod = false;
		player = ((Transform)Instantiate (playerShip, new Vector3 (0, -6f, -2.8f), Quaternion.Inverse(playerShip.rotation))).gameObject; 			
		playerLives--;
	}
	else if(totalTime > 1 && level == 3) 
	{
		Enemy.immune = false;
		EnemyShot.immune = false;
		Enemy.immune = false;
		gracePeriod = false;
		player = ((Transform)Instantiate (playerShip, new Vector3 (0, -6f, -2.8f), Quaternion.Inverse(playerShip.rotation))).gameObject; 			
		playerLives--;
	}
} 
void OnGUI() 
{
	GUIStyle style = GUI.skin.GetStyle ("box"); 
	style.fontSize = (int)(30.0f);  
	 
	GUIStyle style2 = GUI.skin.GetStyle ("button"); 
	style2.fontSize = (int)(20.0f); 
 
	scale.x = Screen.width/originalWidth; // calculate hor scale
	scale.y = Screen.height/originalHeight; // calculate vert scale
	scale.z = 1;
	Matrix4x4 svMat = GUI.matrix; // save current matrix
	// substitute matrix - only scale is altered from standard
	GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
	// draw your GUI controls here:
		 	
	if(started)  
	{ 
		//GUI.Box(new Rect(0, Screen.height - 70, 100, 70), "Total Ships " + TotalShips + "\nShips Killed" + " " + ShipsKilled + "\nAccuracy " + "" + accuracy);
		GUI.Box( new Rect( originalWidth / 2 - 50,0,100,100), "Score \n" + ShipsKilled * 10); 
	   
		for (int i=1; i <= playerLives; i++)  
			GUI.DrawTexture (new Rect (i * i * i * i * i *.5f*i, 0, 45 ,45), texture);   
	}
		// restore matrix before returning
		GUI.matrix = svMat; // restore matrix
}

 	 
//Tiling a sprite sheet depends on 1 / the amount of images in the sprite sheet for the y value

}  
