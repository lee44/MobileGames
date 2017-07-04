using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour  
{  
public AudioClip clip;
public int health = 100;
float offset, frameHeight = 0.025641f; 
float nextFrameTime;
public float animationSpeed = .1f; 
bool firing = false, exploded = true;
public float speed = 1.5f;
bool right = true;
public Transform bomb;
float nextShot;
bool Played;

void Update () 
{    
	if(health < 0)
	{
		Destroy(gameObject);
		Application.LoadLevel("GameOver");
	}
	if(firing == false)   
	{
		if(transform.position.y <= 4.144331)
		{
			if(!Played)
			{
				Played = true;
				AudioSource.PlayClipAtPoint(clip,transform.position);
			}
			
			if(right && transform.position.x < 3.802621f)
				transform.Translate(new Vector3(-speed * Time.deltaTime,0f,0f));	
			else
				right = false;
			if(!right && transform.position.x > -3.802621f)
				transform.Translate(new Vector3(speed * Time.deltaTime,0f,0f));
			else
				right = true;
		}
		else
		{
			transform.Translate(new Vector3(0,1f * Time.deltaTime,0f)); 			
		}

		if(Time.time > nextFrameTime)
		{
			offset = GetComponent<Renderer>().material.mainTextureOffset.y;
			offset -= .02564f;
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,offset);

			if(GetComponent<Renderer>().material.mainTextureOffset.y < .6412 && health >= 50) 
			{
				GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, .97436f);
					
				
			}
				
			if(health < 50 && exploded)
			{
				GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,1 - (15 * frameHeight));
				exploded = false;
				speed = 3;
				BossBomb.speed = 3;	
			}
			if(GetComponent<Renderer>().material.mainTextureOffset.y <= 0)
					GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,1 - (32 * frameHeight));

			nextFrameTime = Time.time + animationSpeed;       
		}
	}

if(Time.time > nextShot && transform.position.y <= 4.144331)
{
	nextShot = Time.time + Random.Range(2,5);
	shoot();  
}

}

void OnTriggerEnter(Collider other)  
{
	if(other.tag == "Bullet")
	{
		health -=10;  
		Destroy(other.gameObject);
	}
}

void shoot()
{
	int shoot = Random.Range(3,8);
	for(int i = 0; i <= shoot; i++)
	{
		Instantiate(bomb, new Vector3(transform.position.x,transform.position.y - 1.2f,transform.position.z), Quaternion.identity);
	}
	firing = false;
}

// 1/(39 frames) gives us the tiling of each frame
// The offset increases the tiling to go to the next frame which is 1/39. In other words the offset adds 1/39 each time, totaling a value of 1 which goes thru all frames

// at frame 14, boss attacks so the offset is  1 - (1/36 * 14) = .35896
// frame 15-31 boss blows up
// frame 31 -39 the boss' heart beats
}