using UnityEngine;
using System.Collections;

public class Animator : MonoBehaviour 
{
	public float xStartPosition = -1.0f;
	public float xEndPosition = 0.5f;
	public float speed = 1.0f;
	float startTime;
	
	void Start () 
	{
		startTime = Time.time;
	}
	void Update () 
	{
		//pg 358. Mathf.Lerp is used to increase a value gradually to a specified final value. In our case, the value increasing is the position of GUITexture. The rate the value
		//is increasing depends on Time.time-startTime)*speed
		Vector3 pos = new Vector3(Mathf.Lerp(xStartPosition, xEndPosition,(Time.time-startTime)*speed), transform.position.y,transform.position.z);
		transform.position = pos;
	}
}