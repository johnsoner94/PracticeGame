//summary
//Main menu
//Attached to Main Camera
//summary

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string levelToLoad ;     // starting  level 

    public string creditLevel;  // credit level

	public string instructionsLevel;  // instructions level

    public int playerLives;             // keeps track of amt. of lives
	public int maxPlayerHealth;         // keeps track of amt. of maxHealth
	//public float waitBetweenLevels;  // time waiting at between levels scene


	private AudioPlay[] nextLevels;
	AudioSource currentAudio;
	AudioPlay currentAudioPlay;

	public void Start() {
		currentAudioPlay = FindObjectOfType<AudioPlay> ();

		nextLevels = FindObjectsOfType<AudioPlay> ();
		bool nothingsPlaying = true;


		currentAudio = currentAudioPlay.getAudio ();
		/*try {
			Debug.Log (currentAudio + " name of clip: " + currentAudio.clip.name + " is playing: " + currentAudio.isPlaying);
		}
		catch {
		}

		for (var i = 0; i < nextLevels.Length; i++) {
			Debug.Log (i + " " + nextLevels [i] + " is playing: " + nextLevels [i].audio.isPlaying);
		}*/
		
		if (levelToLoad == "Level1") {
//			Debug.Log (currentAudio.clip.name + " " + currentAudio.isPlaying + " The current audio is: " + currentAudio.clip.name);
			if (currentAudio.isPlaying) {
				nothingsPlaying = false;
			}
			if (currentAudio.clip.name != "L1 Theme") {
				currentAudio.clip = currentAudioPlay.level1;
				currentAudio.Play ();
//				Debug.Log (currentAudio.clip.name + " -- " + currentAudio.isPlaying + " The current audio is: " + currentAudio.clip.name);
			}
			if (nothingsPlaying) {
				currentAudio.Play ();
			}
		}
	}

	// Changes level using start level button
	public void StartLevel(){	

        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);   // set initial amt. of player lives
        PlayerPrefs.SetInt("CurrentPlayerScore", 0);
		PlayerPrefs.SetInt ("health", maxPlayerHealth);
        Application.LoadLevel(levelToLoad);
    }

    public void Credits()
    {
        Application.LoadLevel(creditLevel);
    }

	public void Instructions()
	{
		Application.LoadLevel(instructionsLevel);
	}
		
}