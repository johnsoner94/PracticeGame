using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script is used the change from scene to scene in our game.*/
public class LevelLoader : MonoBehaviour {


    private bool playerInZone;						// determines if player is in trigger-zone


    public string levelToLoad;     					// next level 
	private static AudioPlay currentAudioPlay;		// the current audio that is playing

	public GameObject miniGameScreen;				// The minigame screen that needs to be loaded.

	AudioSource currentAudio;						// The current audio souce. Used the change the current clip.

	// Use this for initialization
	void Start () {
        playerInZone = false;						// player begins out of trigger-zone


		currentAudioPlay = FindObjectOfType<AudioPlay> ();	// Find the instance of AudioPlay to use later.

		// Plays the level 1 music when switching from the win screen to the main menu. This is to allow the music to be in a loop.
		if (levelToLoad == "Level1") {			
			currentAudio = currentAudioPlay.getAudio();
			if (currentAudio.clip.name == "Won") {
				currentAudio.clip = currentAudioPlay.level1;
				currentAudio.Play ();
			}
			
		}
		// Plays the level 2 music when switching from level 1 to level 2.
		else if (levelToLoad == "Level 2") {
			currentAudio = currentAudioPlay.audio;
			if (currentAudio.clip.name == "L1 Theme") {
				currentAudio.clip = currentAudioPlay.level2;
				currentAudio.Play ();
			}

		}
		// Plays the level 3 music when switching from level 2 to level 3.
		else if (levelToLoad == "Level3") {
			currentAudio = currentAudioPlay.audio;
			if (currentAudio.clip.name == "ThemeMusicL2" && currentAudio.isPlaying) {
				currentAudio.clip = currentAudioPlay.level3;
				currentAudio.Play ();
			}

		}
		// Loads the win music when switching from level 3 to the win screen.
		else if (levelToLoad == "MainMenu") {
			currentAudio = currentAudioPlay.audio;
			if ((currentAudio.clip.name == "ThemeMusicL3" || currentAudio.clip.name == "L3 Boss") && currentAudio.isPlaying) {
				currentAudio.clip = currentAudioPlay.win;
				currentAudio.Play ();
			} else if (currentAudio.clip.name == "L1 Theme" && !currentAudio.isPlaying) {
				currentAudio.clip = currentAudioPlay.win;
				currentAudio.Play ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Transitions the screen when the player hits the level exit trigger.
		// If going from level 1 to 2, or level 2 to 3, it sets the minigame screen to active.
		if (Input.GetAxisRaw("Horizontal") > 0 && playerInZone)   // If left or up is pressed at trigger-zone
        {
			if (levelToLoad == "Level1to2" || levelToLoad == "Level2to3") {
				miniGameScreen.SetActive (true);
			}
			else
				StartLevel();           		 // loads loading screen
        }
			
                 
	}
    // Changes level using start level button
	public void StartLevel(){

		Application.LoadLevel (levelToLoad);

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")         // if Collider2D is player...
        {
            playerInZone = true;           // player is in trigger-zone
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")         // if Collider2D is player...
        {
            playerInZone = false;           // player is out of trigger-zone
        }
    }
}
