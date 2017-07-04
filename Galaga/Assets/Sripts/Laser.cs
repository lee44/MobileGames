using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour 
{
	 
public float speed = 20;	

void Update () 
{
	transform.Translate(new Vector3(0f,speed *Time.deltaTime,0f));
	
	if(transform.position.y >6)
		Destroy(gameObject);
}

} 
