using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour
{
	
	int speed = 3;
	public Transform shot;
	float nextShot = 0;
	
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float d = (-1 * (speed + (GameManager.instance.level / 2)) * Time.deltaTime);
		transform.Translate (new Vector3 (0, d, 0));
		//Debug.Log("moving ship to "+d);
		
		if (GameManager.instance.level == 2) {
			if (Time.time > nextShot) {
				Fire ();
				nextShot = Time.time + Random.Range (3, 5);
			}
		}
	
	}
	
	void OnCollisionEnter (Collision col)
	{
		if ("Bottom" == col.gameObject.tag) {
			GameManager.instance.shipsEscaped++;
			Destroy (gameObject);	
		} 
		
	
	}
	
	void Fire ()
	{
		Transform t = (Transform)Instantiate (shot, new Vector3 
			(transform.position.x, transform.position.y - .85f, transform.position.z), Quaternion.identity);
	}
 }
