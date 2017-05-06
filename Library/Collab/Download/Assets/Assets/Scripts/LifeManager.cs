using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {
	/* This script handles the number of lives that 
	 * the player collects (or loses) and displays them
	 * on the HUD. It also triggers the game over screen
	 * when the player has lost all of their lives. */

	//Text seen by the user on the HUD
	private Text theText;

	// Declare the gaveover screen and the player
	public GameObject gameOverScreen;
	public PlayerController player;

	//Declare strings, ints, and floats before using them.
	public string mainMenu;
	private int lifeCounter;
	public float waitAfterGameOver;

	// Use this for initialization
	void Start () {

		//Get the text
		theText = GetComponent<Text> ();

		//Find the player and the player's current lives
		lifeCounter = PlayerPrefs.GetInt ("PlayerCurrentLives");
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {

		// If the player has lost all of their lives,
		// display the game over screen and deactivate the
		// player.
		if (lifeCounter < 0) {
			gameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);
		}

		//This will display an "x" and the number of lives the player has.
		theText.text = "x " + lifeCounter;

		// If the game over screen is active, wait for some 
		// time, so the user can see that they lost,
		// before ending the game and going back to the main menu.
		if (gameOverScreen.activeSelf) {
			waitAfterGameOver -= Time.deltaTime;
		}
		if (waitAfterGameOver < 0) {
			Application.LoadLevel (mainMenu);
		}
	}

	// If the player has collided with the life coin, 
	// add to the life count and add it to the Player's current lives.
	public void GiveLife(){
		lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives",lifeCounter);
	}

	// If the player dies, decrease the life count.
	public void TakeLife() {
		lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }
		
	void OnDestroy() {
		PlayerPrefs.SetInt ("lifeCounter", lifeCounter);
	}
}
