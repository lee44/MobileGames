using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class RetryReturn : MonoBehaviour 
{
	bool hardCoreMode;
	GameObject inputManager;
	void Awake()
	{
		if(Advertisement.isSupported)
			Advertisement.Initialize ("49045", true);
	}
	public void Return()
	{
		if(Advertisement.IsReady())
			Advertisement.Show(null, new ShowOptions 
			{
				resultCallback = result => 
				{
					Application.LoadLevel("Menu");				
				}
			});
	}
	public void Retry()
	{
		if(LoadImage.hardCore)
		{
			hardCoreMode = true;
			TouchManager.b.SetActive(true);
		}
		else
		{
			hardCoreMode = false;
			InputManager.b.SetActive(true);
		}
		Destroy(GameObject.Find("ImageManager(Clone)"));
		Destroy(GameObject.Find("InputManager(Clone)"));
		Destroy(GameObject.Find("RetryorReturn(Clone)"));
		Destroy(GameObject.Find("GreatJob(Clone)"));
		
		for(int k = 1; k < 4; k++)
			for(int j = 1; j < 4; j++)
				Destroy(GameObject.Find ("Row " + k + ", Column " + j +"(Clone)")); 

		Instantiate(Resources.Load ("Prefabs/ImageManager",typeof(GameObject)));
		inputManager = (GameObject)Instantiate(Resources.Load ("Prefabs/InputManager",typeof(GameObject)));
		
		if(hardCoreMode)
			inputManager.GetComponent <TouchManager>().enabled = true;
		else
			inputManager.GetComponent <InputManager>().enabled = true;
		
		gameObject.SetActive(false);

		GameMenu.isMenu = false;

		GameObject.Find ("MenuButton").GetComponent <Score>().count = 0;
	}
}
