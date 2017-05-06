using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script is used to create an audio source that is never destroyed throughout the game, 
 * but which stores the different sound clips that must be used for the differet levels.
 */

public class AudioPlay : MonoBehaviour {

	static bool AudioBegin = false;		// Intially false, so that the sound plays for the first time, but then isn't pleayed over and over again.
	public AudioSource audio;			// The audio source used to control the sound.

	public AudioClip level1;			// The audio clip for level 1. Set in the GUI inspector.
	public AudioClip level2;			// The audio clip for level 2. Set in the GUI inspector.
	public AudioClip level3;			// The audio clip for level 3. Set in the GUI inspector.
	public AudioClip win;				// The audio clip for the win screen. Set in the GUI inspector.


	private static AudioPlay instance;	// Static singleton instance, so there is only one AudioPlay instance so the sound isn't played over and over.

	// The function that makes sure that only one AudioPlay Instance exists
	public static AudioPlay Instance {
		get { 
			return instance ?? (instance = new GameObject("AudioPlay").AddComponent<AudioPlay>()); 
		}
	}
		
	void Awake()
	{
		// If there is no instance of the singleton AudioPlay, create it.
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
			audio = FindObjectOfType<AudioSource>();
			audio.clip = level1;
			audio.Play ();
		// If there is an instance, destroy gameObject.
		} else {
			DestroyImmediate(gameObject);
		}



	}

	void Start() {
		
	}

	void Update () {

	}

	// get for the AudioSource
	public AudioSource getAudio() {
		return audio;
	}

	// When the application quits, set the AudioBegin boolean to false so it is ready for the next gameplay.
	void OnApplicationQuit() {
		AudioBegin = false;
	}
}
