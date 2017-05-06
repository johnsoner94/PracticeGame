/* 
 * This script controls the morse code minigame used in level 2.
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class MiniGame2 : MonoBehaviour {

	public bool isGoing;
	public LevelLoader levelLoader;

	public Text feedback;
	public Text currentLetter;
	public Text encrypted;
	public string answer;

	private PlayerController player;
	private Hashtable morseAlpha;

	float waitAfterWinning;

	public Image image1;
	public Image image2;
	bool imageVisable1;
	bool imageVisable2;

	// Use this for initialization
	void Start () {
		isGoing = true;				// Sets that the minigame is ongoing. Used once the game is completed.
		feedback.text = "";			// Set feedback text to an empty string initially.
		waitAfterWinning = 300.0f;	// Sets how long the delay is for the transition minigame screen to the next level screen.


		//Finds and disables the player during the minigame so your player controls aren't used.
		player = FindObjectOfType<PlayerController> ();
		player.gameObject.SetActive (false);

		// This switches the morse code key from alphabet or morse sorted.
		imageVisable1 = true;
		imageVisable2 = false;
		image1.gameObject.SetActive (imageVisable1);
		image2.gameObject.SetActive (imageVisable2);


		// Creates the morse/alphabet hash.
		morseAlpha = new Hashtable ();
		morseAlpha.Add("a",".-");
		morseAlpha.Add("b","-...");
		morseAlpha.Add("c","-.-.");
		morseAlpha.Add("d","-..");
		morseAlpha.Add("e",".");
		morseAlpha.Add("f","..-.");
		morseAlpha.Add("g","--.");
		morseAlpha.Add("h","....");
		morseAlpha.Add("i","..");
		morseAlpha.Add("j",".---");
		morseAlpha.Add("k","-.-");
		morseAlpha.Add("l",".-..");
		morseAlpha.Add("m","--");
		morseAlpha.Add("n","-.");
		morseAlpha.Add("o","---");
		morseAlpha.Add("p",".--.");
		morseAlpha.Add("q","--.-");
		morseAlpha.Add("r",".-.");
		morseAlpha.Add("s","...");
		morseAlpha.Add("t","-");
		morseAlpha.Add("u","..-");
		morseAlpha.Add("v","...-");
		morseAlpha.Add("w",".--");
		morseAlpha.Add("x","-..-");
		morseAlpha.Add("y","-.--");
		morseAlpha.Add("z","--..");
		morseAlpha.Add(" "," ");

		// Creates the morse code cypher
		for (var i = 0; i < answer.Length; i++) {
			currentLetter.text = "";
			currentLetter.text = morseAlpha[answer [i].ToString()].ToString();
			currentLetter.color = new Color (255, 255, 255);
			encrypted.text += currentLetter.text + " "; 

		}

		// Puts the curser in the input field.
		InputField lInputField = FindObjectOfType<InputField> ();
		lInputField.Select();
		lInputField.ActivateInputField();
	}

	// Update is called once per frame
	void Update () {

		// Once the minigame is over the timer for the delay of the transition from the minigame screen begins.
		if (!isGoing) {
			waitAfterWinning -= 6.0f;
		}

		// Once the timer has run down, the player is set active again, the points are added, and the next level is loaded.
		if (waitAfterWinning < 0) {
			player.gameObject.SetActive (true);
			levelLoader.StartLevel();
		}

	}

	/*
	 * This function switches between the two different key images. When clicked it sets the images active or inactive.
	 */ 
	public void SwitchCode() {

		imageVisable1 = !imageVisable1;
		imageVisable2 = !imageVisable2;
		image1.gameObject.SetActive (imageVisable1);
		image2.gameObject.SetActive (imageVisable2);

	}

	/*
	 * This function takes the string that the user inputed and then compares it to the answer variable.
	 * If it is correct, then the morse code displayed color changes to green, if it is incorrect then the morse code is white.
	 * The morse code character is accessed by using latin character as the key in the morse-alphabet dictionary.
	 * There is also a feedback text field that is updated depending on if the users input is correct or not.
	 * @param arg0	the string that the user inputs in the inputField. Everytime the inputfield is changed this is called.
	 */
	public void SubmitGuess(string arg0)
	{
		arg0 = arg0.ToLower ();
		encrypted.text = "";
		int inputLength = arg0.Length;
		for (var i = 0; i < answer.Length; i++) {
			string currentChar = answer [i].ToString();
			if (i < inputLength) {
				if (arg0 [i] == answer [i]) {
					currentLetter.text = "";
					currentLetter.supportRichText = true;
					currentLetter.text = "<color=#00ff00ff>" + morseAlpha[currentChar].ToString() + "</color>";
					encrypted.text += currentLetter.text + " ";  
				} else {
					currentLetter.text = "";
					currentLetter.text = morseAlpha[currentChar].ToString();
					encrypted.text += currentLetter.text + " ";  
				}
			} else {
				currentLetter.text = "";
				currentLetter.text = morseAlpha[currentChar].ToString();
				currentLetter.color = new Color (255, 255, 255);
				encrypted.text += currentLetter.text + " "; 
			}
		}

		if (arg0.Equals (answer)) {
			feedback.text = "Well done! You cracked the code. You've earned bonus points!";
			isGoing = false;
			ScoreManager.AddPoints (2000);

		} else {
			feedback.text = "Keep guessing. Make sure you are consulting the guide.";
		}
	}
}

