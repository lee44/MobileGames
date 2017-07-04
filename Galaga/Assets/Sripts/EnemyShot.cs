using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour 
{
public float speed = 1f;	
	              
void Update () 
{
	transform.Translate(new Vector3(0f,-speed *Time.deltaTime,0f));
	
	if(transform.position.y < -4.4)
		Destroy(gameObject);
}
void OnTriggerEnter(Collider other)  
{
	if (other.tag == "Player")
	{
		Destroy(other.gameObject);
		Destroy(gameObject); 
	}
}

}
