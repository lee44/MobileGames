using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	
	int speed = 3;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	  transform.Translate (new Vector3 (0, -speed * Time.deltaTime, 0));
	}
	
	void OnCollisionEnter (Collision col)
	{
		if ("Bottom" == col.gameObject.tag) {
			Destroy (gameObject);	
		} 
		
	
	}
}
