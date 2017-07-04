using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class TargetCollision : MonoBehaviour 
{
	bool beenHit = false;
	Animation targetRoot;
	public AudioClip hitSound;
	public AudioClip resetSound;
	public float resetTime = 3.0f;
	
	void Start()
	{
		targetRoot = transform.parent.transform.parent.GetComponent<Animation>();
		targetRoot.Play("up");
	}
	void Update () 
	{
	
	}
	void OnCollisionEnter(Collision theObject) 
	{
		if(beenHit == false && theObject.gameObject.tag == "Coconut")
		{
			StartCoroutine("targetHit");
		}
	}
	IEnumerator targetHit()
	{
		GetComponent<AudioSource>().PlayOneShot(hitSound);
		targetRoot.Play("down");
		beenHit=true;
		CoconutWin.targets++;

		yield return new WaitForSeconds(resetTime);

		GetComponent<AudioSource>().PlayOneShot(resetSound);
		targetRoot.Play("up");
		beenHit=false;
		CoconutWin.targets--;
	}
}
