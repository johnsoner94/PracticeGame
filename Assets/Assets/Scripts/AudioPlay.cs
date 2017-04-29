using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour {

	static bool AudioBegin = false;
	public AudioSource audio;

	public AudioClip level1;
	public AudioClip level2;
	public AudioClip level3;
	public AudioClip win;

	// Static singleton instance
	private static AudioPlay instance;

	public static AudioPlay Instance{
		get { 
			return instance ?? (instance = new GameObject("AudioPlay").AddComponent<AudioPlay>()); 
		}
	}

	void Awake()
	{
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
			audio = FindObjectOfType<AudioSource>();
			audio.clip = level1;
			audio.Play ();
		} else {
			DestroyImmediate(gameObject);
		}



	}

	void Start() {
		
	}

	void Update () {

	}

	public AudioSource getAudio() {
		return audio;
	}

	void OnApplicationQuit() {
		AudioBegin = false;
	}
}
