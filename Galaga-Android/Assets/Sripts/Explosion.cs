using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour 
{

public static Explosion Instance;
public ParticleSystem smokeEffect;
public ParticleSystem fireEffect;

void Awake()
{
	Instance = this;
}
	
public void explode(Vector3 position)
{
	instantiate(smokeEffect, position);
	instantiate(fireEffect, position);
}
private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
{
		ParticleSystem newParticleSystem = Instantiate(	prefab,	position,Quaternion.identity) as ParticleSystem;
		Destroy(newParticleSystem.gameObject,newParticleSystem.startLifetime);
		
		return newParticleSystem;
	}
}
