/* 
 * This script controls the shift cypher minigame used in level 1.
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class MiniGame : MonoBehaviour {

	public bool isGoing;				// Stores whether or not the minigame is on going or not.
	public LevelLoader levelLoader;		// Will load the next level of the game.

	public Text feedback;				// Feedback for the player letting them know if their guess is correct or not.
	public Text decoder;				// The text that is used to help the user decode the message.
	public Text sliderNum;				// Displays the slider number.
	public Text currentLetter;			// Never displayed, but is used to go through the users guess and determine which of the characters are correct.
	public Text encrypted;				// The text object that is encrypted.
	public string answer;				// The answer that is set in the GUI interface.
	public string encyptedMessage;		// The encrypted message that is set in the GUI interface.

	private PlayerController player;	// The PlayerController script.

	public Image redArrow;				// The image that is used to draw attention to the slider tool to aid the user in solving the cypher.

	float waitAfterWinning;				// Sets the amount of time a that is takes the minigame screen to transition to the next level.
	float waitForArrow;					// Sets the amount of time that it takes for the red arrow to appear.
	bool over;							// Keeps track of whether or not the arrow counter is activiated.

	// An array of the alphabet used in the cypher decoder.
	string [] codeArray = new string[]  { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};



	// Use this for initialization
	void Start () {
		isGoing = true;									// Sets that the minigame is ongoing. Used once the game is completed.

		encrypted.text = encyptedMessage;				// Sets the encrypted Text object to the public string set in the Minigame Object inspector.
		feedback.text = "Start typing to get a clue.";	// Initial text in the feedback Text object.
		decoder.text = "abcdefghijklmnopqrstuvwxyz";	// The decoder Text object which does not change.
		sliderNum.text = "00";							// Initial value of the slider number.
		waitAfterWinning = 300.0f;						// The length of the delay to transition to the next level screen once the minigame is completed. 
		waitForArrow = 1800.0f;							// The length of the delay before the arrow is set to active and can be seen.
		over = false;

		//Finds and disables the player during the minigame so your player controls aren't used.
		player = FindObjectOfType<PlayerController> ();
		player.gameObject.SetActive (false);

		//Sets the red arrow initally to inactive so that it can appear after the timer has finished.
		redArrow.gameObject.SetActive (false);

		// Puts the curser in the input field.
		InputField lInputField = FindObjectOfType<InputField> ();
		lInputField.Select();
		lInputField.ActivateInputField();
	}

	// Update is called once per frame
	void Update () {

		// Once the minigame is over the tranistion timer for the delay of the transition from the minigame screen begins.
		if (!isGoing) {
			waitAfterWinning -= 6.0f;
		}
		// Initially the over boolean is set to false so that the arrow timer countdown can begin.
		if (over == false) {
			waitForArrow -= 1.0f;
		}
		// Once the arrow timer has run down, over boolean is set to true, and the red arrow is set as active, as an aid to the player.
		if (waitForArrow < 0) {
			over = true;
			redArrow.gameObject.SetActive (true);
		}
		// Once the transition timer has run down, the player is set active again, the points are added, and the next level is loaded.
		if (waitAfterWinning < 0) {
			player.gameObject.SetActive (true);
			levelLoader.StartLevel();
		}
				
	}

	/*
	 * This function takes the string that the user inputed and then compares it to the answer variable.
	 * If it is correct, then the encrypted message characters that are correct are changed to green, if it is incorrect then the character is white.
	 * The character is accessed by using the index of the character in the different strings.
	 * There is also a feedback text field that is updated depending on if the users input is correct or not.
	 * @param arg0	the string that the user inputs in the inputField. Everytime the inputfield is changed this is called.
	 */
	public void SubmitGuess(string arg0)
	{
		arg0 = arg0.ToLower ();
		encrypted.text = "";
		int inputLength = arg0.Length;

		for (var i = 0; i < encyptedMessage.Length; i++) {
			if (i < inputLength) {
				if (arg0 [i] == answer [i]) {
					currentLetter.text = "";
					currentLetter.supportRichText = true;
					currentLetter.text = "<color=#00ff00ff>"+encyptedMessage [i].ToString () + "</color>";
					encrypted.text += currentLetter.text; 
				} else {
					currentLetter.text = "";
					currentLetter.text = encyptedMessage [i].ToString ();
					encrypted.text += currentLetter.text; 
				}
			} else {
				currentLetter.text = "";
				currentLetter.text = encyptedMessage [i].ToString ();
				currentLetter.color = new Color (255, 255, 255);
				encrypted.text += currentLetter.text; 
			}
		}

		if (arg0.Equals(answer)) {
			feedback.text = "Well done! You cracked the code. You've earned bonus points!";
			isGoing = false;
			ScoreManager.AddPoints (2000);

		} else {
			feedback.text = "You don't have it yet. Keep guessing.";
			
		}
	}

	/*
	 * This function updates everytime the slider changes. It sets the sliderNum Text object to whatever the value is.
	 * This function also sets the first row of the decoder based on the value, the j value is sent to the value, and then by going through a for-loop
	 * for 26 iterations, once the j value reaches 26, it is set back to 0 and the rest of the alphabet is filled in.
	 * @param value	the current float value of the slider
	 */
	public void CaptureSlider(float value)
	{
		string encrypted = "";
		var numStr = value.ToString();
		if (numStr.Length < 2) {
			sliderNum.text = "0" + numStr;
		} else {
			sliderNum.text = numStr;
		}
		int j = (int)value;
		for (var i = 0; i < 26; i++) {
			if (j == 26) {
				j = 0;
			}
			encrypted += codeArray [j];
			j++;
		}
		decoder.text = encrypted;
	}
}

