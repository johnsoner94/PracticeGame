using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The properites of the main menu screen are unquie, so it required its own script to control movement and sound.*/

public class MainMenu : MonoBehaviour {

	public string levelToLoad;			// starting  level 

    public string creditLevel;			// credit level

	public string instructionsLevel;	// instructions level

    public int playerLives;				// keeps track of amt. of lives
	public int maxPlayerHealth;         // keeps track of amt. of maxHealth


	AudioSource currentAudio;			// Current AudioSource
	AudioPlay currentAudioPlay;			// Current AudioPlay

	public void Start() {
		currentAudioPlay = FindObjectOfType<AudioPlay> ();		// Gets the current AudioPlay

		bool nothingsPlaying = true;							// Nothing is playing intially, so nothingsPlaying is true.


		currentAudio = currentAudioPlay.getAudio ();			// Gets the current AudioSource from the current AudioPlay
		
		if (levelToLoad == "Level1") {							// When in the mainMenu... (where the next scene is level 1)
			if (currentAudio.isPlaying) {						// If the audio is playing, set nothingsPlaying to false.
				nothingsPlaying = false;
			}
			if (currentAudio.clip.name != "L1 Theme") {			// If the audio playing isn't the level 1 theme, play the level 1 theme.
				currentAudio.clip = currentAudioPlay.level1;
				currentAudio.Play ();
			}
			if (nothingsPlaying) {								// If no audio is playing, play the audio
				currentAudio.Play ();
			}
		}
	}

	// Changes level using start level button
	public void StartLevel(){	

        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);	// set initial amt. of player lives
		PlayerPrefs.SetInt("CurrentPlayerScore", 0);			// set initial score
		PlayerPrefs.SetInt ("health", maxPlayerHealth);			// set max number of health
        Application.LoadLevel(levelToLoad);						// load the next scene
    }

	// Loads the credits scene.
    public void Credits()
    {
        Application.LoadLevel(creditLevel);
    }

	// Loads the instructions scene.
	public void Instructions()
	{
		Application.LoadLevel(instructionsLevel);
	}
		
}