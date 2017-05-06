using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* When the pause button is pressed, this script is executed which stops the game time, effectly pausing the game play
 * and sets the player to inactive so that the players sound effects are not heard in the pause screen.
 * In the pause screen the volume level of all audio in the game can be changed.
 */

public class Pause : MonoBehaviour {
	private bool paused;				// Stores if the game is paused.
	private bool playerActive;			// Stores if the the player is active.

	private PlayerController player;	// Stores the current instance of the PlayerController.

	public GameObject pauseScreen;		// Stores the pause screen that will be displayed.

	// Use this for initialization
	void Start () {
		paused = false;									// Initially the game is not paused.
		playerActive = true;							// Initially the player is active.
		player = FindObjectOfType<PlayerController> ();	// Finds the current instance of the PlayerController.
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Called when the pause button is pressed.
	public void PushPause() {
		paused = !paused;							// If the pause boolean is true - set to false. If false - set to true.
		playerActive = !playerActive;				// If the playerActive boolean is true - set to false. If false - set to true.
		player.gameObject.SetActive (playerActive);	// Sets the player to active or inactive using the playerActive boolean.
		pauseScreen.SetActive (paused);				// Sets the pause screen to active or inactive using the paused boolean.

		// If paused is true, set the timeScale to 0, pausing gameplay
		// If puased is false, set the timeScale to 1, resuming gameplay 
		if(paused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}


	// Changes the volume level of all audio in the game, proportional to the original ratios.
	public void volumeChange(float num) {
		AudioListener.volume = num;
		
	}

	// Loads the main menu scene.
	public void LoadMainMenu() {
		Application.LoadLevel("MainMenu");  
	}
}
