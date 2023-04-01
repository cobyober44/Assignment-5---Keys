using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour {

	public List<Word> words;
	public WordSpawner wordSpawner;

	private bool hasActiveWord;
	private Word activeWord;

    public AudioSource source;
    public AudioClip clip;

    public void AddWord ()
	{
		Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
		Debug.Log(word.word);
		words.Add(word);
	}

	public void TypeLetter (char letter)
	{
		if (hasActiveWord)
		{
			if (activeWord.GetNextLetter() == letter)
			{
				activeWord.TypeLetter();
                source.PlayOneShot(clip);
            }
		} else
		{
			foreach(Word word in words)
			{
				if (word.GetNextLetter() == letter)
				{
					activeWord = word;
					hasActiveWord = true;
					word.TypeLetter();
                    break;
				}
			}
		}
		if (hasActiveWord && activeWord.WordTyped())
		{
			hasActiveWord = false;
			words.Remove(activeWord);
		}
	}

	public void RemoveWord(Word wordToRemove)
	{
		if (hasActiveWord && activeWord == wordToRemove)
		{
			hasActiveWord = false;
		}
		words.Remove(wordToRemove);
	}
}
