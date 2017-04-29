using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuietSound : MonoBehaviour {

	AudioSource currentAudio;

	private AudioPlay[] nextLevels;
	public AudioSource playingAudio;

	// Use this for initialization
	void Start () {

		nextLevels = FindObjectsOfType<AudioPlay> ();
		currentAudio = gameObject.GetComponent<AudioSource> ();
//		Debug.Log ("The other object is: " + otherObject.name);


		for (var i = 0; i < nextLevels.Length; i++) {
			playingAudio = nextLevels [i].audio;
//			Debug.Log ("The audio that's currently playing is: " + playingAudio.name);
//			Debug.Log ("The audio playing?: " + playingAudio.isPlaying);
			if (playingAudio.isPlaying) {
				playingAudio.mute = true;
				i = nextLevels.Length;
			}
		}


	}

	// Update is called once per frame
	void Update () {

	}
		

	void OnDestroy() {
		currentAudio.Stop ();
		playingAudio.mute = false;
	}
}
