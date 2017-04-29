using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
	private bool paused;
	private bool playerActive; 

	private PlayerController player;

	public GameObject pauseScreen;

	// Use this for initialization
	void Start () {
		paused = false;
		playerActive = true;
		player = FindObjectOfType<PlayerController> ();
//		player.gameObject.SetActive (playerActive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PushPause() {
		paused = !paused;
		playerActive = !playerActive;
		player.gameObject.SetActive (playerActive);
		pauseScreen.SetActive (paused);

		if(paused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void volumeChange(float num) {
		AudioListener.volume = num;
		
	}


	public void LoadMainMenu() {
		Application.LoadLevel("MainMenu");  
	}
}
