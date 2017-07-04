using UnityEngine;
using System.Collections;

public class fadeWhite : MonoBehaviour 
{
	void Start()
	{
		//pg 338
		Rect currentRes = new Rect(-Screen.width * 0.5f, -Screen.height * 0.5f, Screen.width, Screen.height);
		GetComponent<GUITexture>().pixelInset = currentRes;
		StartCoroutine("Destroy");
	}
	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
