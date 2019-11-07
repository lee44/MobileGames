using UnityEngine;
using System.Collections;
 
public class Shield : MonoBehaviour 
{
public int speed = 3;
public Transform ship;
public AudioClip clip;

void Update () 
{
	transform.Translate (new Vector3 (0, -speed * Time.deltaTime, 0));
	
	if(transform.position.y < -6) 
		Destroy(gameObject);
}
void OnTriggerEnter(Collider other)  
{
	if(other.tag == "Player") 
	{   
		Destroy(gameObject);
		Enemy.sh = true;    
		AudioSource.PlayClipAtPoint(clip,transform.position);
		GameManager.instance.player.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,1f);
		//GameManager.instance.player.transform.localScale = new Vector3(1.991625f,1.991625f,1.204346f);  
	} 
}

}
 