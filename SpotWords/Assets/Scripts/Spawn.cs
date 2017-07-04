using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour 
{
   
public float speed = 1, nextSpawn = 1.0f, lastSpawn, count = 1;
int i = 0;
 
public Transform[] letters;
bool right;
Letter w;

void Update () 
{
	if(right && transform.position.x < 4.8f)
		transform.Translate(new Vector3(speed * Time.deltaTime,0f,0f));	
	else
		right = false;   
		       
	if(!right && transform.position.x > -4.8f)
		transform.Translate(new Vector3(-speed * Time.deltaTime,0f,0f));  
	else
		right = true;
		
	if(Time.time > (lastSpawn + nextSpawn))      
	{
		lastSpawn = Time.time + nextSpawn;

		if(i < LoadFile.characters.Count)
		{	
			w = (Letter)LoadFile.characters[i];
			string letter = w.getLetter(); 
			switch(letter)
			{
				case "a" : Instantiate(letters[0],transform.position,Quaternion.identity);goto default;
				case "b" : Instantiate(letters[1],transform.position,Quaternion.identity);goto default;
				case "c" : Instantiate(letters[2],transform.position,Quaternion.identity);goto default;
				case "d" : Instantiate(letters[3],transform.position,Quaternion.identity);goto default;
				case "e" : Instantiate(letters[4],transform.position,Quaternion.identity);goto default;
				case "f" : Instantiate(letters[5],transform.position,Quaternion.identity);goto default;
				case "g" : Instantiate(letters[6],transform.position,Quaternion.identity);goto default;
				case "h" : Instantiate(letters[7],transform.position,Quaternion.identity);goto default;
				case "i" : Instantiate(letters[8],transform.position,Quaternion.identity);goto default;
				case "j" : Instantiate(letters[9],transform.position,Quaternion.identity);goto default;
				case "k" : Instantiate(letters[10],transform.position,Quaternion.identity);goto default;
				case "l" : Instantiate(letters[11],transform.position,Quaternion.identity);goto default;
				case "m" : Instantiate(letters[12],transform.position,Quaternion.identity);goto default;
				case "n" : Instantiate(letters[13],transform.position,Quaternion.identity);goto default;
				case "o" : Instantiate(letters[14],transform.position,Quaternion.identity);goto default;
				case "p" : Instantiate(letters[15],transform.position,Quaternion.identity);goto default;
				case "q" : Instantiate(letters[16],transform.position,Quaternion.identity);goto default;
				case "r" : Instantiate(letters[17],transform.position,Quaternion.identity);goto default;
				case "s" : Instantiate(letters[18],transform.position,Quaternion.identity);goto default;
				case "t" : Instantiate(letters[19],transform.position,Quaternion.identity);goto default;
				case "u" : Instantiate(letters[20],transform.position,Quaternion.identity);goto default;
				case "v" : Instantiate(letters[21],transform.position,Quaternion.identity);goto default;
				case "w" : Instantiate(letters[22],transform.position,Quaternion.identity);goto default;
				case "x" : Instantiate(letters[23],transform.position,Quaternion.identity);goto default;   
				case "y" : Instantiate(letters[24],transform.position,Quaternion.identity);goto default;
				case "z" : Instantiate(letters[25],transform.position,Quaternion.identity);goto default;
				default : break;//Instantiate(letters[(int)Random.Range(0,26)],transform.position + new Vector3(2.2f,2f,0),Quaternion.identity);break;
			}			
			i++;
		}
	}
}
	
}


