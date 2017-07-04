using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
	
	int speed = 5;
	public Transform shieldPowerup;
	
	
	// Use this for initialization
	void Start ()
	{
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
	}

	void OnCollisionEnter (Collision col)
	{
		if ("Top" == col.gameObject.tag) {
			Destroy (gameObject);	
		}
		
		if ("Enemy" == col.gameObject.tag) {
			GameManager.instance.shipsKilled++;
			Destroy (col.gameObject);
			Destroy (gameObject);
			
			
			if (GameManager.instance.player != null && !GameManager.instance.player.GetComponent<Player> ().shield && Random.Range (1, 5) == 1) {
				Instantiate (shieldPowerup, transform.position, Quaternion.identity);
			}
		}
		
		if ("Boss" == col.gameObject.tag) {
			
			Boss boss = col.gameObject.GetComponent<Boss> ();
			boss.health -= 5;			
			Destroy (gameObject);
		}
		
		if ("Shield" == col.gameObject.tag) {
			Destroy (gameObject);
		}
		
		if ("BossShot" == col.gameObject.tag) {
			Destroy (col.gameObject);
			Destroy (gameObject);
		}
	
	}
}
