using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour 
{
public int speed;
bool right = true;
public Transform enemy;
float nextSpawn = 1, lastSpawn;
GameManager manager;
public static bool isOn = true;
public static bool spawn;
public Transform boss; 
bool Boss_Spawn;

void Start()
{
	//gets a reference to GameManager Script or GameManager class
	//manager = GetComponent<GameManager>();
}
void Update () 
{

if(isOn && spawn)
{ 
	if(right && transform.position.x < 5.24f)
		transform.Translate(new Vector3(speed * Time.deltaTime,0f,0f));	
	else
		right = false;

	if(!right && transform.position.x > -5.24f)
		transform.Translate(new Vector3(-speed * Time.deltaTime,0f,0f));
	else
		right = true; 

	if(Time.time > (lastSpawn + nextSpawn -.15*GameManager.instance.level))      
	{
		lastSpawn = Time.time + nextSpawn;
		Instantiate(enemy,transform.position,Quaternion.identity);
		GameManager.instance.TotalShips++;
	} 
 
}

if(GameManager.instance.level == 3 && !Boss_Spawn)
{
	spawn = false;
	Instantiate(boss, new Vector3(-0.2194162f,7f,-2.898f), Quaternion.Inverse(boss.rotation));
	Boss_Spawn = true;
}
}

}
