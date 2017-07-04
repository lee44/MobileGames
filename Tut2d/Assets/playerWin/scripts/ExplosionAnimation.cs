using UnityEngine;
using System.Collections;

public class ExplosionAnimation : MonoBehaviour
{
	
	public int currentFrame = 1;
	float animationSpeed = 0.2f;
	float nextFrame;
	
	// Use this for initialization
	void Start ()
	{
		nextFrame = Time.time + animationSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextFrame && currentFrame<40) {
			
			float nf = renderer.material.mainTextureOffset.y - 0.04f;
			if (currentFrame % 2 == 0) {
				renderer.material.mainTextureOffset = new Vector2 (0.0f, nf);
			} else
				renderer.material.mainTextureOffset = new Vector2 (0.5f, nf);
			currentFrame++;
			nextFrame = Time.time + animationSpeed;
		}
		
		if (currentFrame>=22) {
			Destroy (GameObject.Find("EnemyPlanet"));
			Destroy (GameObject.Find("Earth"));
		}
	}
}
