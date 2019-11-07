using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour 
{

public GUITexture t1, t2, t3, t4;      
public float speed = 3;
public Transform bullet;
float fireRate = 0.8f;   
float shotOn = 0f;
bool pause = false, showMenu;
Vector3 scale;

void Start()
{
	
	float scaleWidth = Screen.width / 347f; 
	float scaleHeight = Screen.height / 617f;
	float scaleX = .27f * Screen.width; 
	t1.pixelInset = new Rect(0,5f,128 * scaleWidth,58* scaleHeight);
	t2.pixelInset = new Rect(scaleX,5f,128 * scaleWidth,58* scaleHeight);  
	t3.pixelInset = new Rect(0, 12f,128 * scaleWidth,58* scaleHeight);
	t4.pixelInset = new Rect(-5f, -15f,65 * scaleWidth,65* scaleHeight);    
	Instantiate(t1);
	Instantiate(t2);    
	Instantiate(t3);  
	Instantiate(t4);  
}              

void OnGUI() 
{
	GUIStyle style = GUI.skin.GetStyle ("window");   
	style.fontSize = (int)(20.0f);
	
	scale.x = Screen.width/347; // calculate hor scale
	scale.y = Screen.height/617; // calculate vert scale
	scale.z = 1;
	Matrix4x4 svMat = GUI.matrix; // save current matrix
	// substitute matrix - only scale is altered from standard
	GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
	// draw your GUI controls here:
	
	if(showMenu)		
		GUI.Window(0, new Rect(347 / 2 - 80,617 / 2 - 100,150,150), PauseMenu, "Pause Menu");
	
	GUI.matrix = svMat; // restore matrix
}
void PauseMenu(int windowID)
{
	if(GUI.Button(new Rect(35,90,85,40),"Quit"))
	{
		Time.timeScale = 1;
		EnemySpawn.spawn = false;
		GameManager.started = false;
		Application.LoadLevel("Game");
	}
	if(GUI.Button(new Rect(35,35,85,40),"Resume"))
	{
		Time.timeScale = 1;
		showMenu = false;
	}
}
void Update ()   
{	/*
	//transform.position is an instance of Vector 3
	Vector3 temp = transform.position;
	temp.y = 7f; 
	transform.position = temp; 
	*/
	if(GameManager.started){
	Vector3 move = Vector3.zero;
	move.x = Input.GetAxis("Horizontal"); 
	//move.y = Input.GetAxis("Vertical");
	transform.position += move *  Time.deltaTime * speed;
	transform.position = new Vector3(Mathf.Clamp(transform.position.x,-4.6f,4.6f),Mathf.Clamp(transform.position.y,-8.662529f,5.24f),transform.position.z); 
	 
	if(Input.GetKeyDown("space") && Time.time > (shotOn + fireRate))
	{
		Vector3 temp = transform.position;
		temp.y += .5f;   
		//transform.position = temp;
		//Instantiate(bullet,temp,Quaternion.Euler(0,0,180f)); 
		Instantiate(bullet,temp,Quaternion.identity); 		
		shotOn = Time.time;
		Time.timeScale = 0;
		  
	}	
	if(Input.touches.Length > 0)
		for(int i = 0; i < Input.touchCount; i++)
		{
			if(t1.HitTest(Input.GetTouch(i).position))
			{
				if(Input.GetTouch(i).phase != TouchPhase.Ended)
				{
					Vector3 m = Vector3.zero;Time.timeScale = 1f;
					m.x -= Time.deltaTime * speed;
					transform.position += m;
					transform.position = new Vector3(Mathf.Clamp(transform.position.x,-5.047825f,5.047825f),Mathf.Clamp(transform.position.y,-8.662529f,5.24f),transform.position.z);	
				}
			}
			else if(t2.HitTest(Input.GetTouch(i).position))
			{
				if(Input.GetTouch(i).phase != TouchPhase.Ended)
				{
					Vector3 m2 = Vector3.zero;
					m2.x += Time.deltaTime * speed;
					transform.position += m2;
					transform.position = new Vector3(Mathf.Clamp(transform.position.x,-5.047825f,5.047825f),Mathf.Clamp(transform.position.y,-8.662529f,5.24f),transform.position.z);	
				}
			}
			if(t3.HitTest(Input.GetTouch(i).position))
			{
				if(Input.GetTouch(i).phase != TouchPhase.Began)
				{
					if(Time.time > (shotOn + fireRate))
					{
						Vector3 temp = transform.position;
						temp.y += .5f;   
						Instantiate(bullet,temp,Quaternion.identity);
						shotOn = Time.time;  
					}
				}
			}
			if(t4.HitTest(Input.GetTouch(i).position))
			{
				if(Input.GetTouch(i).phase != TouchPhase.Began && pause == false)   
				{
					Time.timeScale = 0;
					pause = true;
					showMenu = true ;  
				}
				else 
				{
					Time.timeScale = 1;	
					pause = false;
				}
			}
		}
}
}


}
