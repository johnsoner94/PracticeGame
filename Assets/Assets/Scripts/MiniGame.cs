using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class MiniGame : MonoBehaviour {

	public bool isGoing;
	public GameObject miniGameScreen;
	public LevelLoader levelLoader;

	public Text feedback;
	public Text decoder;
	public Text sliderNum;
	public Text currentLetter;
	public Text encrypted;

	private PlayerController player;

	public Image redArrow;

	float waitAfterWinning;
	float waitForArrow;
	bool over;
	string encyptedMessage = "zvokco ckfo dro mywzedob";

	string [] codeArray = new string[]  { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};



	// Use this for initialization
	void Start () {
		isGoing = true;
		miniGameScreen = GameObject.FindGameObjectWithTag ("MiniGame");

		encrypted.text = encyptedMessage;
		feedback.text = "";
		decoder.text = "abcdefghijklmnopqrstuvwxyz";
		sliderNum.text = "00";
		waitAfterWinning = 300.0f;
		waitForArrow = 1800.0f;
		over = false;

		player = FindObjectOfType<PlayerController> ();
		player.gameObject.SetActive (false);
		redArrow.gameObject.SetActive (false);
		InputField lInputField = FindObjectOfType<InputField> ();
		lInputField.Select();
		lInputField.ActivateInputField();
	}

	// Update is called once per frame
	void Update () {

		if (!isGoing) {
			waitAfterWinning -= 6.0f;
		}
		if (over == false) {
			waitForArrow -= 1.0f;
		}
		if (waitForArrow < 0) {
			over = true;
			redArrow.gameObject.SetActive (true);
		}
		if (waitAfterWinning < 0) {
			player.gameObject.SetActive (true);
			ScoreManager.AddPoints (2000);
			levelLoader.StartLevel();
		}
				
	}

	public void SubmitGuess(string arg0)
	{
//		Debug.Log ("The user input: " + arg0);
		arg0 = arg0.ToLower ();
		string answer = "please save the computer";
		encrypted.text = "";
		int inputLength = arg0.Length;

		for (var i = 0; i < encyptedMessage.Length; i++) {
			if (i < inputLength) {
//				Debug.Log ("Current letter is: " + arg0 [i] + " and the answer is: " + answer[i]);
				if (arg0 [i] == answer [i]) {
					currentLetter.text = "";
//					Debug.Log ("Current letter is: " + arg0 [i] + " and as a string is: " + arg0 [i].ToString ());
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

		} else {
			feedback.text = "You don't have it yet. Keep guessing.";
			
		}
	}


	public void CaptureSlider(float value)
	{
//		Debug.Log ("The slider value: " + value);
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

