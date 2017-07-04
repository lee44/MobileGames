using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour 
{
	public float speed;
	
void Update () 
{
	float amountToMove = speed * Time.deltaTime;
	//Space.World finds what direction down is after axis is rotated 
	transform.Translate (Vector3.down * amountToMove, Space.World);
	
	if(transform.position.y <= -9.946022)
	{
		transform.position = new Vector3(transform.position.x, 11.26f, transform.position.z);
	}
}
}
