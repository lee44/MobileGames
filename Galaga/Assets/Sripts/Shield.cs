using UnityEngine;
using System.Collections;
 
public class Shield : MonoBehaviour 
{
public int speed = 3;
public Transform ship;

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
		//Debug.Log (Enemy.sh);
		GameManager.instance.player.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,.4f);
		GameManager.instance.player.GetComponent<Renderer>().material.mainTextureScale = new Vector3(.6f,.6f);
		GameManager.instance.player.transform.localScale = new Vector3(1.2f,1.2f,1.2f); 
	} 
}

}
