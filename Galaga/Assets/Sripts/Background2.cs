using UnityEngine;
using System.Collections;

public class Background2 : MonoBehaviour 
{
	public float speed;
	
void Update () 
{
	float amountToMove = speed * Time.deltaTime;
	transform.Translate (Vector3.down * amountToMove, Space.World);

	if(transform.position.y <= -17.04)
	{
		transform.position = new Vector3(transform.position.x, 20.8f, transform.position.z);
	}
}  
}  
