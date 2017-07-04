using UnityEngine;
using System.Collections;

public class SpinCube : MonoBehaviour 
{

public int speed;
float x = Random.value - .5f, y = .5f, z = .5f;
public static bool spin = true;

void Update () 
{
	if(spin)
	{
		transform.Rotate(new Vector3(x,y,z), speed * Time.deltaTime);
		transform.Translate(Vector3.down * Time.deltaTime, Space.World);	
	}
	else
	{
		   
	}
	if(transform.position.y < -10)
		Destroy(gameObject);

}

}
