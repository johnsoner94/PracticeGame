using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelLoader : MonoBehaviour {


    private bool playerInZone;     // determines if player is in trigger-zone


    public string levelToLoad;     // next level 

//	private AudioPlay[] nextLevels;
//	private AudioSource[] nextLevels;

	private static AudioPlay currentAudioPlay;

//	private List<AudioPlay> audioList = new List<AudioPlay>();
//	private List<AudioSource> audioList = new List<AudioSource>();

	public GameObject miniGameScreen;

	AudioSource currentAudio;

    //public float waitBetweenLevels;  // time waiting at between levels scene

	// Use this for initialization
	void Start () {
        playerInZone = false;           // player begins out of trigger-zone
		//AudioBegin = PlayerPrefs.GetInt("AudioBegin", 0);


		currentAudioPlay = FindObjectOfType<AudioPlay> ();

		/*nextLevels = FindObjectsOfType<AudioPlay> ();

		for (var i = 0; i < nextLevels.Length; i++) {
			audioList.Add (nextLevels [i]);
		}

		Debug.Log ("The next level is: " + levelToLoad);
		for (var i = 0; i < audioList.Count; i++) {
			try {
				Debug.Log (i + " " + audioList [i] + " name of clip: " + audioList [i].audio.clip.name + " is playing: " + audioList [i].audio.isPlaying);
			}
			catch {
			}
		}*/

		if (levelToLoad == "Level1") {			
			currentAudio = currentAudioPlay.getAudio();
//			Debug.Log (currentAudio.name + " " + currentAudio.clip.name + " " + currentAudio.isPlaying);
			if (currentAudio.clip.name == "Won") {
//				Debug.Log ("The current audio is: " + currentAudio.clip.name);
				currentAudio.clip = currentAudioPlay.level1;
				currentAudio.Play ();
			}
			
		}
		else if (levelToLoad == "Level 2") {
			currentAudio = currentAudioPlay.audio;
			if (currentAudio.clip.name == "L1 Theme") {
//				Debug.Log ("The current audio is: " + currentAudio.clip.name);
				currentAudio.clip = currentAudioPlay.level2;
				currentAudio.Play ();
			}

		}
		else if (levelToLoad == "Level3") {
			currentAudio = currentAudioPlay.audio;
			if (currentAudio.clip.name == "ThemeMusicL2" && currentAudio.isPlaying) {
//				Debug.Log ("The current audio is: " + currentAudio.clip.name);
				currentAudio.clip = currentAudioPlay.level3;
				currentAudio.Play ();
			}

		}	
		else if (levelToLoad == "MainMenu") {
			currentAudio = currentAudioPlay.audio;
//			Debug.Log (currentAudio.clip.name + " " + currentAudio.isPlaying);
//			Debug.Log ("Current audio name" + currentAudio.clip.name + " is it playing? " + currentAudio.isPlaying);
			if ((currentAudio.clip.name == "ThemeMusicL3" || currentAudio.clip.name == "L3 Boss") && currentAudio.isPlaying) {
//				Debug.Log ("The current audio is: " + currentAudio.clip.name);
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
		if (Input.GetAxisRaw("Horizontal") > 0 && playerInZone)   // If left or up is pressed at trigger-zone
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
