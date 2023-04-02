using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordInput : MonoBehaviour {

	public WordManager wordManager;

	bool paused = false;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("escape")) {
			if(!paused) {
				paused = true;
				Time.timeScale = 0.0f;
			}
			else {
				paused = false;
				Time.timeScale = 1.0f;
			}
		}
		if(Input.GetKeyDown("end")) {
			SceneManager.LoadScene("End");
		}
		foreach (char letter in Input.inputString)
		{
			wordManager.TypeLetter(letter);
		}
	}

}
