using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
public AudioClip clip; 
public float speed, t;
public Transform shield, bomb;
public static bool sh = false, immune = false;
//float fireRate = 0.5f;   
//float shotOn = 0f;
bool shoot;

void Update () 
{
	//transform.position = Spline.Interp(path,.1f);
	//transform.position = Spline.MoveOnPath(path, transform.position, ref t, 5f);	     
		
	if(transform.position.y < -10)
		Destroy(gameObject);  
	
	if(GameManager.instance.level >= 2 && !shoot)
	{
		Instantiate(bomb, transform.position, Quaternion.identity);
		shoot = true;
	}
		/*
		if(Time.time > (shotOn + fireRate) && !isDead)
		{
			shotOn = Time.time;  
			if((int)Random.Range(1,4) == 1)   
				Instantiate(bomb, transform.position, Quaternion.identity);
		}*/
}    
void OnTriggerEnter(Collider other)  
{        
	if(other.tag == "Bullet")      
	{ 
		GetComponent<AudioSource>().volume = 1f;   
		AudioSource.PlayClipAtPoint(clip,new Vector3(0,0,50f));  
		//StartCoroutine(MyMethod());
		Destroy(other.gameObject);
		//GameObject b = GameObject.FindWithTag("Enemy");
		GameManager.instance.ShipsKilled++;
		Destroy(gameObject);
		//Instantiate(clone, clone.transform.position,Quaternion.identity);
		Explosion.Instance.explode(transform.position); 
	}
	else if (other.tag == "Player" && !sh && !immune)
	{
		Destroy(gameObject);
		GameObject c = GameObject.FindWithTag("Player");
		Destroy(c);
		AudioSource.PlayClipAtPoint(clip,new Vector3(0,0,50f));
		Explosion.Instance.explode(transform.position);		
	}
	else if(sh && other.tag == "Player")
	{
		sh = false;
		GameManager.instance.player.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,.5f);
		//GameManager.instance.player.renderer.material.mainTextureScale = new Vector3(.4f,.4f);
		//GameManager.instance.player.transform.localScale = new Vector3(1f,1f,.9f);
		Destroy(gameObject); 
		AudioSource.PlayClipAtPoint(clip,new Vector3(0,0,50f));
		Explosion.Instance.explode(transform.position);
	}
	
	if((int)Random.Range(1,5) == 1 && other.tag == "Bullet")  
		Instantiate(shield,transform.position,Quaternion.identity);  
}
	 

} 
