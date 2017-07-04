using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{

public Texture texture;
public static GameManager instance;
public int TotalShips;
public int ShipsKilled;
public Transform enemyShip;
public Transform playerShip;
public int playerLives;
public GameObject player;
public int level = 1;
int accuracy;
public static bool started;

void Start()
{
	//creates a reference to itself so other scripts can access GameManger's data members
	instance = this;
}
void Update ()  
{
		if(started){
	if (player == null && playerLives > 0)
	{
		playerLives--;
		player = ((Transform)Instantiate (playerShip, new Vector3 (0, -3.5f, -2.8f), Quaternion.Inverse(playerShip.rotation))).gameObject;
	}

	if(ShipsKilled > (level*10))
	{
		level++;
	}
		if(ShipsKilled > 0)
			accuracy = (int)((TotalShips/ShipsKilled) / 100);
}
}
void OnGUI() 
{
	if(started){
	GUI.Box(new Rect(0, Screen.height - 70, 100, 70), "Total Ships " + TotalShips + "\nShips Killed" + " " + ShipsKilled + "\nAccuracy " + "" + accuracy);
	if (player != null) 
	{
		for (int i=1; i <= playerLives; i++) 
		{
			GUI.DrawTexture (new Rect (i * 20, 0, 40,40), texture);
		} 
	}
	else
	{
		GUI.Box(new Rect(Screen.width/2 - 125, Screen.width/2, 150, 150), "Game Over ");  
		EnemySpawn.isOn = false;  
	}
}
	if (!started) 
	{
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), "Start Game")) 
		{
			started = true;
			EnemySpawn.spawn = true;
				
		}
		
	}
}

//Tiling a sprite sheet depends on 1 / the amount of images in the sprite sheet for the y value

}  
