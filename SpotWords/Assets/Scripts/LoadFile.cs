using UnityEngine;
using System.Collections;
using System.IO;

public class LoadFile : MonoBehaviour 
{

StringReader reader = null; 
int randomWord;
string txt, text;
public static ArrayList characters = new ArrayList();
public static ArrayList words = new ArrayList();
ArrayList library = new ArrayList();
Letter w;
string[] files = new string[]{"3LetteredWords","4LetteredWords","5LetteredWords","6LetteredWords","7LetteredWords","8LetteredWords","9LetteredWords","10LetteredWords"};

void Start()
{	
	TextAsset puzdata = (TextAsset)Resources.Load(files[0], typeof(TextAsset));
	reader = new StringReader(puzdata.text);

	if( reader == null )
	{
		Debug.Log("Text Not Found");
	} 
	else
	{
		while((txt = reader.ReadLine()) != null)
			library.Add(txt);
		
		randomWord = Random.Range(0,library.Count);
		//w = (Word)words[randomWord];
		//text = w.getWord();
		
		text = (string)library[randomWord];
		//characters = new string[text.Length];
		string letter;
		for (int a = 0; a < text.Length; a++)
		{
			letter = System.Convert.ToString(text[a]);
			characters.Add(new Letter(letter, false));  
		}
			
		
		Debug.Log (text);
		characters.Sort(new CompareLetters());
	}
}
void Update()
{
	
}

}

class CompareLetters : IComparer 
{
	public int Compare(object one, object two)
	{
		return string.Compare(((Letter)(one)).getLetter(),((Letter)(two)).getLetter());
	}
}

public class Letter
{
	string letter;
	bool touched;

	public Letter(string letter, bool touched)
	{
		this.letter = letter;
		this.touched = touched;
	}
	public string getLetter()
	{
		return letter;
	}
	public void setTouched(bool t)
	{
		touched = t;
	}
	public bool isTouched()
	{
		return touched;
	}

}
