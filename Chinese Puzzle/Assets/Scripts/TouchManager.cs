using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Touch manager used for hardcore Mode.
/// </summary>
public class TouchManager : MonoBehaviour 
{
	Vector2 touchDeltaPosition;
	Vector3 touchmove;
	GameObject[] temp = new GameObject[2];
	int t;
	GameObject scoreObject;
	bool add, cont;
	public GameObject returnRetry, greatJob, retryorReturn;
	public static GameObject b;
	
	void Start()
	{
		scoreObject = GameObject.Find("MenuButton");
	}
	void Update () 
	{

		if(Input.touches.Length > 0 && !GameMenu.isMenu)			
			if(Input.GetTouch(0).phase == TouchPhase.Moved)
		{     
			//Converts the input touches position to world coordinates
			Ray ray = Camera.main.ScreenPointToRay( Input.touches[0].position );
			RaycastHit hitInfo;
			
			if (Physics.Raycast( ray, out hitInfo))
				switch(hitInfo.collider.tag)
				{
					case "1":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);
					break;
					case "2":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "3":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "4":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "5":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "6":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "7":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "8":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "9":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "10":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "11":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "12":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "13":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "14":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "15":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "16":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "17":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "18":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "19":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "20":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "21":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "22":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "23":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "24":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);break;
					case "25":
					touchDeltaPosition = Input.GetTouch(0).deltaPosition; 
					touchmove = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 14.41f);
					if(hitInfo.collider.GetComponent <InputOnBoxes>().canMoveRight || hitInfo.collider.GetComponent <InputOnBoxes>().canMoveLeft ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveUp ||hitInfo.collider.GetComponent <InputOnBoxes>().canMoveDown)
						move(moveDirection(touchmove), hitInfo);	
						break;				    
				}
		}
		solved();
	}
	public string moveDirection(Vector3 v)
	{ 
		if(v.y > -v.x && v.y < v.x)
			return "right";
		else if(v.y < -v.x && v.y > v.x)
			return "left";
		else if(v.y > v.x && v.y > -v.x)
			return "up";
		else if(v.y < -v.x && v.y < v.x)
			return "down";

		return "nothing";
	}
	public void move(string dir, RaycastHit ray)
	{
		if(dir.Equals("right") && ray.collider.GetComponent <InputOnBoxes>().canMoveRight)
		{
			ray.collider.transform.position += new Vector3( LoadImage.move,0,0);
			ray.collider.GetComponent <InputOnBoxes>().canMoveRight = false;resetMove();
			swapObjects(ray);
			setMove ();
			add = true;
		}
		else if(dir.Equals("left") && ray.collider.GetComponent <InputOnBoxes>().canMoveLeft)
		{
			ray.collider.transform.position -= new Vector3( LoadImage.move,0,0);
			ray.collider.GetComponent <InputOnBoxes>().canMoveLeft = false;resetMove();
			swapObjects(ray);
			setMove ();
			add = true;
		}
		else if(dir.Equals("down") && ray.collider.GetComponent <InputOnBoxes>().canMoveDown)
		{
			ray.collider.transform.position -= new Vector3( 0,LoadImage.move,0);
			ray.collider.GetComponent <InputOnBoxes>().canMoveDown = false;resetMove();
			swapObjects(ray);
			setMove ();
			add = true;
		}
		else if(dir.Equals("up") && ray.collider.GetComponent <InputOnBoxes>().canMoveUp)
		{
			ray.collider.transform.position += new Vector3( 0,LoadImage.move,0);	
			ray.collider.GetComponent <InputOnBoxes>().canMoveUp = false;resetMove();
			swapObjects(ray);
			setMove ();
			add = true;
		}
		if(add)
		{	scoreObject.GetComponent <Score>().count++;add = false;}
	}
	public void solved()
	{
		if(t < (LoadImage.difficultyVariable - 1)*(LoadImage.difficultyVariable - 1))
			for(int k = 1; k < LoadImage.difficultyVariable; k++)
				for(int j = 1; j < LoadImage.difficultyVariable; j++)
					if(string.Equals(LoadImage.gameObjectNames[k - 1,j - 1].GetComponent<InputOnBoxes>().pic, LoadImage.texture[t]) )
						t++;		
					else
						t = 0;
		if(t == (LoadImage.difficultyVariable - 1)*(LoadImage.difficultyVariable - 1) && cont)
		{
			GameMenu.isMenu = true;

			b = GameObject.Find ("Button");
			b.SetActive(false);

			scoreObject.GetComponent <Score>().storeHighScore();
			
			greatJob = (GameObject)Instantiate(Resources.Load ("Prefabs/GreatJob",typeof(GameObject)));
			greatJob.transform.SetParent(GameObject.FindGameObjectWithTag("Background").transform.parent, false);
			
			retryorReturn = (GameObject)Instantiate(Resources.Load ("Prefabs/RetryorReturn",typeof(GameObject)));
			retryorReturn.transform.SetParent(GameObject.FindGameObjectWithTag("Background").transform.parent, false);

			cont = false;
		}
	}
	public void setMove()
	{
		for(int k = 1; k < LoadImage.difficultyVariable; k++)
			for(int j = 1; j < LoadImage.difficultyVariable; j++)
			{	
				if(LoadImage.gameObjectNames[k-1,j-1].GetComponent <InputOnBoxes>().emptyBox)
				{
					if((j-1) != 0)//left 
						LoadImage.gameObjectNames[k-1,j-2].GetComponent <InputOnBoxes>().canMoveRight = true;
					if((k-1) != 0)//top
						LoadImage.gameObjectNames[k-2,j-1].GetComponent <InputOnBoxes>().canMoveDown = true;
					if((j-1) != 2)//right
						LoadImage.gameObjectNames[k-1,j].GetComponent <InputOnBoxes>().canMoveLeft = true;
					if((k-1) != 2)//bot
						LoadImage.gameObjectNames[k,j-1].GetComponent <InputOnBoxes>().canMoveUp = true;					
				}
			}
	}
	public void resetMove()
	{
		for(int k = 1; k < LoadImage.difficultyVariable; k++)
			for(int j = 1; j < LoadImage.difficultyVariable; j++)
				if(LoadImage.gameObjectNames[k-1,j-1].GetComponent <InputOnBoxes>().emptyBox)
				{
					if((j-1) != 0)//left 
						LoadImage.gameObjectNames[k-1,j-2].GetComponent <InputOnBoxes>().canMoveRight = false;
					if((k-1) != 0)//top
						LoadImage.gameObjectNames[k-2,j-1].GetComponent <InputOnBoxes>().canMoveDown = false;
					if((j-1) != 2)//right
						LoadImage.gameObjectNames[k-1,j].GetComponent <InputOnBoxes>().canMoveLeft = false;
					if((k-1) != 2)//bot
						LoadImage.gameObjectNames[k,j-1].GetComponent <InputOnBoxes>().canMoveUp = false;
				}
	}
	public void swapObjects(RaycastHit ray)
	{
		for(int k = 1; k < LoadImage.difficultyVariable; k++)
			for(int j = 1; j < LoadImage.difficultyVariable; j++)
				if(LoadImage.gameObjectNames[k - 1,j - 1].tag.Equals(ray.collider.tag))
					temp[0] = LoadImage.gameObjectNames[k - 1,j - 1];
				else if(LoadImage.gameObjectNames[k - 1,j - 1].GetComponent <InputOnBoxes>().emptyBox)
					temp[1] = LoadImage.gameObjectNames[k - 1,j - 1];

		for(int k = 1; k < LoadImage.difficultyVariable; k++)
			for(int j = 1; j < LoadImage.difficultyVariable; j++)	
				if(LoadImage.gameObjectNames[k - 1,j - 1].tag.Equals(ray.collider.tag))
					LoadImage.gameObjectNames[k - 1,j - 1] = temp[1];
				else if(LoadImage.gameObjectNames[k - 1,j - 1].GetComponent <InputOnBoxes>().emptyBox)
					LoadImage.gameObjectNames[k - 1,j - 1] = temp[0];				
	}
}
