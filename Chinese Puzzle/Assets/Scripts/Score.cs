using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	public int count;
	GameObject score;
	public static GameObject highScore;

	void Start()
	{
		score = GameObject.Find ("Score Text");
		highScore = GameObject.Find("Number Score Text");
		count = 0;

		highScore.GetComponent <Text>().text = "" + PlayerPrefs.GetInt("HighScore");		
	}
	void Update () 
	{
		score.GetComponent <Text>().text = "" + count;
	}
	public void storeHighScore()
	{
		if(LoadImage.cars)
		{
			int oldHighscore = PlayerPrefs.GetInt("carsHighScore");   
			if(PlayerPrefs.GetInt("carsHighScore") == 0)
				PlayerPrefs.SetInt("carsHighScore", count);	
			else if(count < oldHighscore)		        
				PlayerPrefs.SetInt("carsHighScore", count);
			highScore.GetComponent <Text>().text = "" + PlayerPrefs.GetInt("carsHighScore");
		}
		else if(LoadImage.celebrities)
		{
			int oldHighscore = PlayerPrefs.GetInt("celebritiesHighScore");   
			if(PlayerPrefs.GetInt("celebritiesHighScore") == 0)
				PlayerPrefs.SetInt("celebritiesHighScore", count);	
			else if(count < oldHighscore)		        
				PlayerPrefs.SetInt("celebritiesHighScore", count);
			highScore.GetComponent <Text>().text = "" + PlayerPrefs.GetInt("celebritiesHighScore");
		}
		else if(LoadImage.models)
		{
			int oldHighscore = PlayerPrefs.GetInt("modelsHighScore");   
			if(PlayerPrefs.GetInt("modelsHighScore") == 0)
				PlayerPrefs.SetInt("modelsHighScore", count);	
			else if(count < oldHighscore)		        
				PlayerPrefs.SetInt("modelsHighScore", count);
			highScore.GetComponent <Text>().text = "" + PlayerPrefs.GetInt("modelsHighScore");
		}	
		else if(LoadImage.basketball)
		{
			int oldHighscore = PlayerPrefs.GetInt("basketballHighScore");   
			if(PlayerPrefs.GetInt("basketballHighScore") == 0)
				PlayerPrefs.SetInt("basketballHighScore", count);	
			else if(count < oldHighscore)		        
				PlayerPrefs.SetInt("basketballHighScore", count);
			highScore.GetComponent <Text>().text = "" + PlayerPrefs.GetInt("basketballHighScore");
		}	
		else if(LoadImage.anime)
		{
			int oldHighscore = PlayerPrefs.GetInt("animeHighScore");   
			if(PlayerPrefs.GetInt("animeHighScore") == 0)
				PlayerPrefs.SetInt("animeHighScore", count);	
			else if(count < oldHighscore)		        
				PlayerPrefs.SetInt("animeHighScore", count);
			highScore.GetComponent <Text>().text = "" + PlayerPrefs.GetInt("animeHighScore");
		}	
		else if(LoadImage.animals)
		{
			int oldHighscore = PlayerPrefs.GetInt("animalsHighScore");   
			if(PlayerPrefs.GetInt("animalsHighScore") == 0)
				PlayerPrefs.SetInt("animalsHighScore", count);	
			else if(count < oldHighscore)		        
				PlayerPrefs.SetInt("animalsHighScore", count);
			highScore.GetComponent <Text>().text = "" + PlayerPrefs.GetInt("animalsHighScore");
		}
	}
}
