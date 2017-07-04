using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public int totalShips = 0;
	public int shipsKilled = 0;
	public int shipsEscaped = 0;
	public Transform playerShip;
	public Transform enemyShip;
	public int level = 1;
	public int playerLifes = 4;
	public GameObject player;
	public Texture shipTexture;
	public EnemySpawn enemySpawn;
	bool started = false;
	
	// Use this for initialization
	void Start ()
	{
		instance = this;
		enemySpawn.isOn = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (player == null && playerLifes > 0 && started) {
			playerLifes--;
			player = ((Transform)Instantiate (playerShip, new Vector3 (0, -4.2f, 0), Quaternion.identity)).gameObject;
			
		} else if (player == null && playerLifes <= 0) {
			//quit
			Application.LoadLevel(2);
		}
		
		if (shipsKilled > (level * 10))
			level++;
        
	}
	
	void OnGUI ()
	{
		if (started) {
			if (shipsEscaped > 10) {
				GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "\n\nGame Over: aliens escaped &\n invaded earth");
				enemySpawn.isOn = false;
				Destroy (player);
				playerLifes = 0;
				enemySpawn.isOn = false;

			} else if (playerLifes <= 0) {
				if (player != null)
					Destroy (player);
				//GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "\n\nGame Over: no ships left");
				//enemySpawn.isOn = false;
				Application.LoadLevel(2);
			}
 
			int perc = (int)(totalShips == 0 ? 0 : ((double)shipsKilled / ((double)totalShips)) * 100);
		
			//NumberFormatInfo f = new NumberFormatInfo ();
			//string pS = perc.ToString("G3",f);
		
			GUI.Box (new Rect (Screen.width - 100, 0, 100, 50), "Total Ships " + totalShips +
			"\nKilled " + shipsKilled + " " + perc + "%" +
			"\nLevel:" + level + " Lives " + (playerLifes));
		
			if (player != null) {
				for (int i=1; i<=playerLifes; i++) {
					GUI.DrawTexture (new Rect (i * 20, 0, 18, 24), shipTexture, ScaleMode.ScaleToFit, true);
				}
			} 
		}
		
		if (!started) {
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), "Start Game")) {
				started = true;
				enemySpawn.isOn = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 100), "Options")) {
				Debug.Log ("clicked 2");
			}
		}
	}
}
