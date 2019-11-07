using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour 
{
public float speed = 1f;	
public static bool immune = false;

void Update () 
{
	transform.Translate(new Vector3(0f,-speed *Time.deltaTime,0f));
	
	if(transform.position.y < -10)
		Destroy(gameObject);
}
void OnTriggerEnter(Collider other)  
{
	if (other.tag == "Player" && !immune)
	{
		Destroy(other.gameObject);
		Destroy(gameObject); 
	}
}

}
