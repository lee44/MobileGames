using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//// <summary>
/// Input manager used for Normal Mode.
/// </summary>
public class InputManager : MonoBehaviour 
{
	int i, t;	
	int[] Kcoordinates = new int[4], Jcoordinates = new int[4];
	string []picNames = new string[2];
	GameObject scoreObject, greatJob, retryorReturn;
	public static GameObject b;
	bool cont = true;	
	
	void Start()
	{
		scoreObject = GameObject.Find("MenuButton");
	}
	void Update () 
	{
		if(Input.touches.Length > 0 && !GameMenu.isMenu)			
			if(Input.GetTouch(0).phase == TouchPhase.Ended && Input.GetTouch(0).tapCount == 1)
		{     
			//Converts the input touches position to world coordinates
			Ray ray = Camera.main.ScreenPointToRay( Input.touches[0].position );
			RaycastHit hitInfo;
			
			if (Physics.Raycast( ray, out hitInfo))
				switch(hitInfo.collider.tag)
			{
				case "1": LoadImage.gameObjectNames[0,0].GetComponent <InputOnBoxes>().isTouch = true; break;
				case "2": LoadImage.gameObjectNames[0,1].GetComponent <InputOnBoxes>().isTouch = true;break;
				case "3": LoadImage.gameObjectNames[0,2].GetComponent <InputOnBoxes>().isTouch = true;break;
				case "4": LoadImage.gameObjectNames[1,0].GetComponent <InputOnBoxes>().isTouch = true;break;
				case "5": LoadImage.gameObjectNames[1,1].GetComponent <InputOnBoxes>().isTouch = true;break;
				case "6": LoadImage.gameObjectNames[1,2].GetComponent <InputOnBoxes>().isTouch = true;break;
				case "7": LoadImage.gameObjectNames[2,0].GetComponent <InputOnBoxes>().isTouch = true;break;
				case "8": LoadImage.gameObjectNames[2,1].GetComponent <InputOnBoxes>().isTouch = true;break;
				case "9": LoadImage.gameObjectNames[2,2].GetComponent <InputOnBoxes>().isTouch = true;break;
			}
		}

		for(int k = 1; k < 4; k++)
			for(int j = 1; j < 4; j++)
				if(LoadImage.gameObjectNames[k - 1,j - 1].GetComponent <InputOnBoxes>().isTouch && i <= 1 && LoadImage.gameObjectNames[k - 1,j - 1].GetComponent <InputOnBoxes>().hasBeenStored)
				{	
					picNames[i] = LoadImage.gameObjectNames[k - 1,j - 1].GetComponent <InputOnBoxes>().pic;

					Kcoordinates[i] = k - 1;
					Jcoordinates[i++] = j - 1;
				
					LoadImage.gameObjectNames[k - 1,j - 1].GetComponent <InputOnBoxes>().isTouch = false;
					LoadImage.gameObjectNames[k - 1,j - 1].GetComponent <InputOnBoxes>().hasBeenStored = false;
					
					if(i == 2)
					{	
						Texture2D inputTexture = (Texture2D)Resources.Load(picNames[1], typeof(Texture2D));  
						LoadImage.gameObjectNames[Kcoordinates[0], Jcoordinates[0]].GetComponent<Renderer>().material.mainTexture = inputTexture;
						LoadImage.gameObjectNames[Kcoordinates[0], Jcoordinates[0]].GetComponent <InputOnBoxes>().hasBeenStored = true;
						LoadImage.gameObjectNames[Kcoordinates[0], Jcoordinates[0]].GetComponent <InputOnBoxes>().pic = picNames[1];

						Texture2D inputText = (Texture2D)Resources.Load(picNames[0], typeof(Texture2D));  
						LoadImage.gameObjectNames[Kcoordinates[1], Jcoordinates[1]].GetComponent<Renderer>().material.mainTexture = inputText;
						LoadImage.gameObjectNames[Kcoordinates[1], Jcoordinates[1]].GetComponent <InputOnBoxes>().hasBeenStored = true;
						LoadImage.gameObjectNames[Kcoordinates[1], Jcoordinates[1]].GetComponent <InputOnBoxes>().pic = picNames[0];
										
						i = 0;
						
						scoreObject.GetComponent <Score>().count++;
					}
				}

		if(t < 9)
			for(int k = 1; k < 4; k++)
				for(int j = 1; j < 4; j++)
					if(string.Equals(LoadImage.gameObjectNames[k - 1,j - 1].GetComponent<InputOnBoxes>().pic, LoadImage.texture[t]) )
						t++;
					else
						t = 0;
						
			if(t == 9 && cont)
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
}

