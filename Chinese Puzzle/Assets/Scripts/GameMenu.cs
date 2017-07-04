using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour 
{
	public static bool isMenu, hardCoreMode;
	public Canvas menu;
	public GameObject b, inputManager, loadImageObject, obj;
	int i = 0;
	
	public void quitGame()
	{
		Application.LoadLevel("Menu");
		Destroy(GameObject.Find ("Settings"));
	}
	public void loadMenu()
	{
		isMenu = true;
		menu.enabled = true;
		b.SetActive(false);

		//for(int k = 1; k < LoadImage.difficultyVariable; k++)
		//	for(int j = 1; j < LoadImage.difficultyVariable; j++)
		//		LoadImage.gameObjectNames[k-1,j-1].GetComponent <MeshRenderer>().enabled = false;
	}
	public void resume()
	{
		isMenu = false;
		menu.enabled = false;
		b.SetActive(true);
		
		//for(int k = 1; k < LoadImage.difficultyVariable; k++)
		//	for(int j = 1; j < LoadImage.difficultyVariable; j++)
		//		if(!LoadImage.gameObjectNames[k-1,j-1].GetComponent <InputOnBoxes>().emptyBox)
		//			LoadImage.gameObjectNames[k-1,j-1].GetComponent <MeshRenderer>().enabled = true;	
	}
	public void retry()
	{
		if(LoadImage.hardCore)
		{
			hardCoreMode = true;
			for(int k = 1; k < 4; k++)
				for(int j = 1; j < 4; j++)
					Destroy(GameObject.Find ("Row " + k + ", Column " + j +"(Clone)"));
		}
		else
			hardCoreMode = false;

		Destroy(GameObject.Find("InputManager(Clone)"));		
		
		inputManager = (GameObject)Instantiate(Resources.Load ("Prefabs/InputManager",typeof(GameObject)));

		if(hardCoreMode)
			inputManager.GetComponent <TouchManager>().enabled = true;
		else
			inputManager.GetComponent <InputManager>().enabled = true;
		
		if(!hardCoreMode)	
			for(int k = 1; k < 4; k++)
				for(int j = 1; j < 4; j++)
				{			
					LoadImage.gameObjectNames[k-1, j-1].GetComponent <InputOnBoxes>().pic = LoadImage.textureCopy[LoadImage.numbers[i]];
					
					Texture2D inputTexture = (Texture2D)Resources.Load(LoadImage.textureCopy[LoadImage.numbers[i++]], typeof(Texture2D));  
					LoadImage.gameObjectNames[k-1, j-1].GetComponent<Renderer>().material.mainTexture = inputTexture;	
				}
		else
		{
			for(int k = 1; k < 4; k++)
				for(int j = 1; j < 4; j++)
					obj = (GameObject)Instantiate(LoadImage.gameObjectNamesCopy[k-1, j-1], LoadImage.gameObjectNamesCopy[k-1, j-1].transform.position, LoadImage.gameObjectNamesCopy[k-1, j-1].transform.rotation);	
		}
		i = 0;
		
		resume();
	}
}
