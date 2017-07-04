using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
public AudioClip clip;
public float speed;
public Transform shield, bomb;
public static bool sh = false;
bool shotOnce;

void Update () 
{
	transform.Translate(new Vector3(0f,-speed * Time.deltaTime, 0f));
	
	if(transform.position.y < -6)
		Destroy(gameObject);
	
	if(!shotOnce && GameManager.instance.level == 2)
	{
		shotOnce = true;
		Instantiate(bomb, transform.position, Quaternion.identity);
	}
}
  
void OnTriggerEnter(Collider other)  
{ 
	if(other.tag == "Bullet")
	{
		AudioSource.PlayClipAtPoint(clip,transform.position);
		//StartCoroutine(MyMethod());
		Destroy(other.gameObject);
		//GameObject b = GameObject.FindWithTag("Enemy");
		GameManager.instance.ShipsKilled++;
		Destroy(gameObject);
		//Instantiate(clone, clone.transform.position,Quaternion.identity);
		Explosion.Instance.explode(transform.position); 
	}
	else if (other.tag == "Player" && !sh)
	{
		Destroy(gameObject);
		GameObject c = GameObject.FindWithTag("Player");
		Destroy(c); 
	}
	else if(sh && other.tag == "Player")
	{
		sh = false;
		GameManager.instance.player.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,0);
		GameManager.instance.player.GetComponent<Renderer>().material.mainTextureScale = new Vector3(.4f,.4f);
		GameManager.instance.player.transform.localScale = new Vector3(.6534f,.6534f,.6534f);
		Destroy(gameObject); 
	}
	
	if((int)Random.Range(1,5) == 1 && other.tag == "Bullet")  
		Instantiate(shield,transform.position,Quaternion.identity);  
}   

} 
