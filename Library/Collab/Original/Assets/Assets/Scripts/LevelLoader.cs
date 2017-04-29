using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelLoader : MonoBehaviour {


    private bool playerInZone;     // determines if player is in trigger-zone


    public string levelToLoad;     // next level 

	private AudioPlay[] nextLevels;

	public GameObject miniGameScreen;

	public AudioSource currentAudio;

    //public float waitBetweenLevels;  // time waiting at between levels scene

	// Use this for initialization
	void Start () {
        playerInZone = false;           // player begins out of trigger-zone
		//AudioBegin = PlayerPrefs.GetInt("AudioBegin", 0);

		nextLevels = FindObjectsOfType<AudioPlay> ();

		Debug.Log ("The next level is: " + levelToLoad);
//		for (var i = 0; i < nextLevels.Length; i++) {
//			Debug.Log (i + " " + nextLevels [i]);
//		}
			

		if (levelToLoad == "Level1") {
			for (var i = 0; i < nextLevels.Length; i++) {
				Debug.Log (nextLevels[i].audio.clip.name + " " + nextLevels[i].audio.isPlaying + " " + nextLevels[i].nextLevel);
				currentAudio = nextLevels [i].audio;
				if (currentAudio.clip.name == "Won") {
					Debug.Log ("The current audio is: " + currentAudio.clip.name);
					currentAudio.clip = nextLevels [i].level1;
					currentAudio.Play ();
				}
			}
		}
		else if (levelToLoad == "Level 2") {
			for (var i = 0; i < nextLevels.Length; i++) {
				Debug.Log (nextLevels[i].audio.clip.name + " " + nextLevels[i].audio.isPlaying + " " + nextLevels[i].nextLevel);
				currentAudio = nextLevels [i].audio;
				if (currentAudio.clip.name == "L1 Theme") {
					Debug.Log ("The current audio is: " + currentAudio.clip.name);
					currentAudio.clip = nextLevels [i].level2;
					currentAudio.Play ();
				}
			}
		}
		else if (levelToLoad == "Level3") {
			for (var i = 0; i < nextLevels.Length; i++) {
				Debug.Log (nextLevels[i].audio.clip.name + " " + nextLevels[i].audio.isPlaying + " " + nextLevels[i].nextLevel);
				currentAudio = nextLevels [i].audio;
				if (nextLevels [i].audio.clip.name == "ThemeMusicL2" && nextLevels[i].audio.isPlaying) {
					Debug.Log ("The current audio is: " + currentAudio.clip.name);
					nextLevels [i].audio.clip = nextLevels [i].level3;
					nextLevels [i].audio.Play ();
				}
			}
		}	
		else if (levelToLoad == "MainMenu") {
			for (var i = 0; i < nextLevels.Length; i++) {
				Debug.Log (nextLevels[i].audio.clip.name + " " + nextLevels[i].audio.isPlaying + " " + nextLevels[i].nextLevel);
				Debug.Log ("I am here.");
				currentAudio = nextLevels [i].audio;
				Debug.Log ("Current audio name" + currentAudio.clip.name + " is it playing? " + currentAudio.isPlaying);
				if ((nextLevels [i].audio.clip.name == "ThemeMusicL3" || nextLevels [i].audio.clip.name == "L3 Boss") && nextLevels [i].audio.isPlaying) {
					Debug.Log ("The current audio is: " + currentAudio.clip.name);
					nextLevels [i].audio.clip = nextLevels [i].win;
					nextLevels [i].audio.Play ();
				} else if (currentAudio.clip.name == "L1 Theme" && !currentAudio.isPlaying) {
					currentAudio.clip = nextLevels[i].win;
					currentAudio.Play ();
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && playerInZone)   // If left or up arrow is pressed at trigger-zone
        {
			if (levelToLoad == "Level1to2" || levelToLoad == "Level2to3") {
				miniGameScreen.SetActive (true);
			}
			else
	            Application.LoadLevel(levelToLoad);            // loads loading screen
        }
			
                 
	}
    // Changes level using start level button
	public void StartLevel(){
		
		if (levelToLoad == "MainMenu") {
			for (var i = 0; i < nextLevels.Length; i++) {
				if (nextLevels [i].audio.clip.name == "Won" && nextLevels [i].audio.isPlaying) {
					nextLevels [i].audio.clip = nextLevels [i].level1;
					nextLevels [i].audio.Play();
				}
			}
		}

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
