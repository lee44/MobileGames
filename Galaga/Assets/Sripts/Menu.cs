using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{  

public GameObject t1,t2,t3;
TextMesh mesh;

void Start()
{
        //GameManager.started = true;
        //mesh = t1.GetComponent<TextMesh>();
        //mesh.text = "Hello";
    }
void Update () 
{
	if(Input.touches.Length > 0)
	{
		//Converts the input touches position to world coordinates
		Ray ray = Camera.main.ScreenPointToRay( Input.touches[0].position );
		RaycastHit hitInfo;
		
		if (Physics.Raycast( ray, out hitInfo ))   
		{
			Vector3 worldSpaceHitPoint = hitInfo.point;
			
			if((worldSpaceHitPoint.x >= -3.6f && worldSpaceHitPoint.x <= 3.9f) && (worldSpaceHitPoint.y >= .8f && worldSpaceHitPoint.y <= 1.9f))
			{  
				GameManager.started = true;
				Destroy(t1);Destroy(t2);Destroy(t3);
			}
			else if((worldSpaceHitPoint.x >= -3.6f && worldSpaceHitPoint.x <= 2.3f) && (worldSpaceHitPoint.y >= -.6f && worldSpaceHitPoint.y <= .4f))
			{
				Application.LoadLevel("Options");  
			}
			else if((worldSpaceHitPoint.x >= -3.6f && worldSpaceHitPoint.x <= -.44f) && (worldSpaceHitPoint.y >= -2.14f && worldSpaceHitPoint.y <= -1.2f))
			{
				System.Diagnostics.Process.GetCurrentProcess().Kill(); 	
			}
		}
		//Input.touches[0].position gives the position of the pixel touched on the screen
		//Debug.Log(Input.touches[0].position);
	}
}

}
