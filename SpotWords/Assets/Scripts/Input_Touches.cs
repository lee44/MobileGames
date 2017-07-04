using UnityEngine;
using System.Collections;

public class Input_Touches : MonoBehaviour 
{
string []alphabet = new string[10];
Letter w ;
string word;
int c;
bool match;

void Update () 
{
	if(Input.touches.Length > 0)			
		if(Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).tapCount == 1)
		{     
			//Converts the input touches position to world coordinates
			Ray ray = Camera.main.ScreenPointToRay( Input.touches[0].position );
			RaycastHit hitInfo;
		
			if (Physics.Raycast( ray, out hitInfo) && c < GameManager.level)   
				switch(hitInfo.collider.tag)
				{
					case "A" : alphabet[c] = "a";goto default;
					case "B" : alphabet[c] = "b";goto default;
					case "C" : alphabet[c] = "c";goto default;
					case "D" : alphabet[c] = "d";goto default;
					case "E" : alphabet[c] = "e";goto default;
					case "F" : alphabet[c] = "f";goto default;
					case "G" : alphabet[c] = "g";goto default;
					case "H" : alphabet[c] = "h";goto default;
					case "I" : alphabet[c] = "i";goto default;
					case "J" : alphabet[c] = "j";goto default;
					case "K" : alphabet[c] = "k";goto default;
					case "L" : alphabet[c] = "l";goto default;
					case "M" : alphabet[c] = "m";goto default;
					case "N" : alphabet[c] = "n";goto default;
					case "O" : alphabet[c] = "o";goto default;
					case "P" : alphabet[c] = "p";goto default;
					case "Q" : alphabet[c] = "q";goto default;
					case "R" : alphabet[c] = "r";goto default;
					case "S" : alphabet[c] = "s";goto default;
					case "T" : alphabet[c] = "t";goto default;
					case "U" : alphabet[c] = "u";goto default;
					case "V" : alphabet[c] = "v";goto default;
					case "W" : alphabet[c] = "w";goto default;
					case "X" : alphabet[c] = "x";goto default;
					case "Y" : alphabet[c] = "y";goto default;
					case "Z" : alphabet[c] = "z";goto default;
					default : c++; break;
				}

			if(c == GameManager.level)
			for(int i = 0; i < c; i++)
			{
				w = (Letter)LoadFile.characters[i];
				word = w.getLetter();

				if(alphabet[i].Equals(word))
					match = true;
				else 
					match = false;
			}
			if(match)
			{
				GameManager.score += 10;
				for(int i = 0; i < c; i++)
				{
					alphabet[i] = " ";
				}
			}

		}	
}

}
