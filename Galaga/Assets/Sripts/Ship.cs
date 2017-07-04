using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour 
{
public float speed = 1;
public Transform bullet;
float fireRate = 0.2f; 
float shotOn = 0f;

void Update () 
{	/*
	//transform.position is an instance of Vector 3
	Vector3 temp = transform.position;
	temp.y = 7f; 
	transform.position = temp; 
	*/
	if(GameManager.started){
	Vector3 move = Vector3.zero;
	move.x = Input.GetAxis("Horizontal"); 
	move.y = Input.GetAxis("Vertical");
	transform.position += move *  Time.deltaTime * speed;
	transform.position = new Vector3(Mathf.Clamp(transform.position.x,-5.24f,5.24f),Mathf.Clamp(transform.position.y,-5.24f,5.24f),transform.position.z); 
	 
	if(Input.GetKeyDown("space") && Time.time > (shotOn + fireRate))
	{
		Vector3 temp = transform.position;
		temp.y += .5f;   
		//transform.position = temp;
		Instantiate(bullet,temp,Quaternion.identity);  
		shotOn = Time.time;
		 
	}
}
} 
}
