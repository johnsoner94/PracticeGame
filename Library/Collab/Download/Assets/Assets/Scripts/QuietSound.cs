using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Used in the lose screen to silence whatever other audio might be playing so only the lose audio is playing.*/

public class QuietSound : MonoBehaviour {

	AudioSource currentAudio;

	private AudioPlay[] nextLevels;		// Creates array of AudioPlay objects. 
	public AudioSource playingAudio;	// Creates an AudioSource to store the currently playing AudioSource.

	// Use this for initialization
	void Start () {
		// Finds all of the AudioPlays
		nextLevels = FindObjectsOfType<AudioPlay> ();
		// Gets the current AudioSource component.
		currentAudio = gameObject.GetComponent<AudioSource> ();


		// Checks all of the AudioPlay objects for whatever AudioSource is currently playing.
		// Mutes whatever audiosouce was currently playing.
		for (var i = 0; i < nextLevels.Length; i++) {
			playingAudio = nextLevels [i].audio;
			if (playingAudio.isPlaying) {
				playingAudio.mute = true;
				i = nextLevels.Length;
			}
		}


	}

	// Update is called once per frame
	void Update () {

	}
		
	// When the lose screen is over, the lose music stops playing and the singleton AudioSource is unmuted.
	void OnDestroy() {
		currentAudio.Stop ();
		playingAudio.mute = false;
	}
}
