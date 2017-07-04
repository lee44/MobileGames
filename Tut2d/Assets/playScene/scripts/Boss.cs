using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
	
	public Transform bossShot;
	public int? health = 100;
	bool firing = false;
	float animRate = 0.1f;
	float animOn = 0f;
	const float frameHeight = 0.025641f;
	bool blowUp = false;
	int direction = 1;
	int speed = 2;
	float nextShot;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	//up to frame 14. inspecting
	//15-31: blowing up
	//32-39: breathing
	void Update ()
	{
		if (health <= 0) {
			Destroy (gameObject);
			GameManager.instance.enemySpawn.isOn=true;
			GameManager.instance.enemySpawn.bossKilled=true;
		}
		
		if (transform.position.y>2.2)
			transform.Translate (new Vector3 (0, -(speed/2)*Time.deltaTime, 0));

		
		if (!firing) {
						
			float d = direction * speed * Time.deltaTime;
			transform.Translate (new Vector3 (d, 0, 0));

			if (Time.time > (animOn + animRate)) {
			
			
				animOn = Time.time;
				float frameOffset = renderer.material.mainTextureOffset.y;
			
				if (health >= 50) {
			
					if ((1 - frameOffset) < (14 * frameHeight)) {
						frameOffset -= frameHeight;
					} else {
						frameOffset = 1 - frameHeight;
					} 
				
				
				} else if (health < 50) {
					if (!blowUp) {
						speed = 4;
						frameOffset = 1 - (15 * frameHeight);		
						blowUp = true;
					} else {
						frameOffset -= frameHeight;
					}
					if (frameOffset <= 0)
						frameOffset = 1 - (32 * frameHeight);
				
				}
			
				renderer.material.mainTextureOffset = new Vector2 (renderer.material.mainTextureOffset.x, frameOffset);
			}			
		}
	
		if (Time.time>nextShot) {
			firing = true;
			Fire();
			nextShot = Time.time + Random.Range(2,5);
		}
		
	}
	
	void OnCollisionEnter (Collision col)
	{
	
		if ("Left" == col.gameObject.tag) {
			
			direction = -1;
			//nextSpawn = Random.Range(1.0,3.0);
			
		} else if ("Right" == col.gameObject.tag) {
			direction = 1;
			//nextSpawn = Random.Range(1.0,3.0);
		}
	}

	void Fire ()
	{
		int shots = Random.Range (3, 8);
		for (int i = 0; i<shots; i++) {
			Instantiate (bossShot, 
				new Vector3 (transform.position.x, transform.position.y - 3, transform.position.z), Quaternion.identity);
		}
		firing = false;
	}

}
