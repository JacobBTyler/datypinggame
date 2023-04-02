using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

	public List<Word> words;

	public WordSpawner wordSpawner;

	private bool hasActiveWord;
	private Word activeWord;

	public AudioSource typeSFX;

	public void AddWord ()
	{
		Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
		Debug.Log(word.word);

		words.Add(word);
		tracker.wordsUsed++;
	}

	public void TypeLetter (char letter)
	{
		if (hasActiveWord)
		{
			if (activeWord.GetNextLetter() == letter)
			{
				tracker.correctlyTyped++;
				tracker.charsTyped++;
				AudioSource typer = typeSFX.GetComponent<AudioSource>();
				typer.Play();
				activeWord.TypeLetter();
			}
			else {
				tracker.charsTyped++;
			}
		} else
		{
			foreach(Word word in words)
			{
				if (word.GetNextLetter() == letter)
				{
					activeWord = word;
					hasActiveWord = true;
					AudioSource typer = typeSFX.GetComponent<AudioSource>();
					typer.Play();
					word.TypeLetter();
					tracker.charsTyped++;
					tracker.correctlyTyped++;
					break;
				}
				else {
					tracker.charsTyped++;
				}
			}
		}

		if (hasActiveWord && activeWord.WordTyped())
		{
			hasActiveWord = false;
			words.Remove(activeWord);
		}
	}

}
