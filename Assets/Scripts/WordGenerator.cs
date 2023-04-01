using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordGenerator : MonoBehaviour {

	private static string[] wordList; 
	
	static WordGenerator()
	{
        string path = "Assets/Words/1000RandomWords.txt";
		wordList = File.ReadAllLines(path);
    }

	public static string GetRandomWord ()
	{
		int randomIndex = Random.Range(0, wordList.Length);
		string randomWord = wordList[randomIndex];

		return randomWord;
	}

}
