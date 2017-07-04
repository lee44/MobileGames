using UnityEngine;
using System.Collections;

public class BossBomb : MonoBehaviour 
{	

float offset; 
float nextFrameTime;
public float animationSpeed = .1f; 
public static int speed = 1;
Vector3 angle;

void Start()
{
	angle = transform.eulerAngles;
	angle.z = Random.Range(125,225);
	transform.eulerAngles = angle;  
}
void Update () 
{
	if(Time.time > nextFrameTime)
	{
		offset = GetComponent<Renderer>().material.mainTextureOffset.y;
		offset -= .25f;
		
		if(offset < 0)
			offset = .75f;

		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,offset);
		nextFrameTime = Time.time + animationSpeed;
	}
	
	transform.Translate(new Vector3(0, speed * Time.deltaTime,0));
	if(transform.position.y < -10)
		Destroy(gameObject); 
	
}

void OnTriggerEnter(Collider other)  
{
	if(other.tag == "Bullet") 
	{	
		Destroy(gameObject);
		Destroy(other.gameObject);
	}
	if (other.tag == "Player" && !Enemy.sh)
	{
		Destroy(gameObject);
		GameObject c = GameObject.FindWithTag("Player");
		Destroy(c); 
	} 
	else if(Enemy.sh && other.tag == "Player")
	{
		Enemy.sh = false;
		GameManager.instance.player.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,.5f);
		Destroy(gameObject); 
	}
}

}
