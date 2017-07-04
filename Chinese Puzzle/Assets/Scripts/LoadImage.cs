using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour 
{
	public static bool normal, hardCore, anime, animals, cars, celebrities, models, basketball;
	public static string[] texture;
	string[,] loadGameObject;
	public static GameObject[,] gameObjectNames, gameObjectNamesCopy;
	ArrayList list = new ArrayList();
	ArrayList numbersUsed;
	public static int index, num, ind, difficultyVariable, v;
	public string [] animeCategory = new string[10], animalsCategory = new string[10], carsCategory = new string[10], celebritiesCategory = new string[10], modelsCategory = new string[10], BasketballCategory = new string[10];	
	public static float move;
	public static string[] textureCopy;
	public static int[] numbers;
	int i = 0;
	//Note: For static variables, insert values in them in a class so that other classes may have access to them. Do not create static variables in a class and insert values in
	//then in another class. 

	void Start () 
	{
		loadGameObject = new string[5,5];
		gameObjectNames = new GameObject[5,5];
		gameObjectNamesCopy = new GameObject[5,5];
		texture = new string[25];
		numbersUsed = new ArrayList();
		textureCopy = new string[25];
		numbers = new int[25];
		v = 0;
		
		normal = GameObject.Find("Settings").GetComponent <Settings>().normal;
		hardCore = GameObject.Find("Settings").GetComponent <Settings>().hardCore;
		anime = GameObject.Find("Settings").GetComponent <Settings>().anime.isOn;
		animals = GameObject.Find("Settings").GetComponent <Settings>().animals.isOn;
		cars = GameObject.Find("Settings").GetComponent <Settings>().cars.isOn;
		celebrities = GameObject.Find("Settings").GetComponent <Settings>().celebrities.isOn;
		models = GameObject.Find("Settings").GetComponent <Settings>().models.isOn;
		basketball = GameObject.Find("Settings").GetComponent <Settings>().basketball.isOn;
		
			difficultyVariable = 4;
			move = 20.3f;				
			
			for(int k = 1; k < 4; k++)
				for(int j = 1; j < 4; j++)
					loadGameObject[k-1, j-1] = "Prefabs/3 by 3/Row " + k + ", Column " + j;
			
			string fileLocation = loadTextureArray();
			for(int i = 1; i < 10; i++)
				texture[i-1] = "Images/3 by 3/" + fileLocation + "/1 (" + i + ")";
			
			for(int z = 0; z < 9; z++)
				list.Add(z);		
			
			for(int k = 1; k < 4; k++)
				for(int j = 1; j < 4; j++)
			{
				GameObject obj = (GameObject)Resources.Load(loadGameObject[k-1, j-1], typeof(GameObject));
				gameObjectNames[k-1, j-1] = (GameObject)Instantiate(obj, obj.transform.position,obj.transform.rotation);
				ind++;
			}
			for(int k = 1; k < 4; k++)
				for(int j = 1; j < 4; j++)
			{
				num = RandomGenerator();
				numbers[i] = num;

				gameObjectNames[k-1, j-1].GetComponent <InputOnBoxes>().pic = texture[num];
				textureCopy[i++] = texture[num];

				Texture2D inputTexture = (Texture2D)Resources.Load(texture[num], typeof(Texture2D));  
				gameObjectNames[k-1, j-1].GetComponent<Renderer>().material.mainTexture = inputTexture;
				
				list.RemoveAt(index);
			}
			if(hardCore)
			{			i = 0;
			
				gameObjectNames[1,1].GetComponent <MeshRenderer>().enabled = false;
				gameObjectNames[1,1].GetComponent <MeshCollider>().enabled = false;
			
				gameObjectNames[1,1].GetComponent <InputOnBoxes>().emptyBox = true;
				gameObjectNames[1,0].GetComponent <InputOnBoxes>().canMoveRight = true;
				gameObjectNames[0,1].GetComponent <InputOnBoxes>().canMoveDown = true;
				gameObjectNames[2,1].GetComponent <InputOnBoxes>().canMoveUp = true;
				gameObjectNames[1,2].GetComponent <InputOnBoxes>().canMoveLeft = true;
			
				for(int k = 1; k < 4; k++)
					for(int j = 1; j < 4; j++)
						gameObjectNamesCopy[k-1, j-1] = gameObjectNames[k-1, j-1];
			
				GameObject.Find("InputManager(Clone)").GetComponent <TouchManager>().enabled = true;
				GameObject.Find("InputManager(Clone)").GetComponent <InputManager>().enabled = false;	
			}
			else
			{			i = 0;
			
				gameObjectNames[1,1].GetComponent <MeshRenderer>().enabled = true;
				gameObjectNames[1,1].GetComponent <MeshCollider>().enabled = true;

				GameObject.Find("InputManager(Clone)").GetComponent <TouchManager>().enabled = false;
				GameObject.Find("InputManager(Clone)").GetComponent <InputManager>().enabled = true;
			}
		
	}
	public string loadTextureArray()
	{
		int rand = Random.Range(0, 7);

		if(anime)
			return animeCategory[rand];
		else if(animals)
			return animalsCategory[rand];
		else if(cars)
			return carsCategory[rand];
		else if(models)
			return modelsCategory[rand];
		else if(celebrities)
			return celebritiesCategory[rand];
		else if(basketball)
			return BasketballCategory[rand];
		return "";
			
	}
	int RandomGenerator()
	{	
		index = Random.Range(0, list.Count);
		while(numbersUsed.Contains(index))
		{
			index = Random.Range(0, list.Count);
			
			if(numbersUsed.Contains(index))
				break;
		}

		numbersUsed.Add(index);
		int value = (int)list[index];
		
		return value;
	}
	
}
	