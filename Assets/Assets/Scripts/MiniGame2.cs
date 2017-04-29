using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class MiniGame2 : MonoBehaviour {

	public bool isGoing;
	public GameObject miniGameScreen;
	public LevelLoader levelLoader;

	public Text feedback;
	public Text currentLetter;
	public Text encrypted;

	private PlayerController player;

	int count;
	float waitAfterWinning;
	string encyptedMessage = "... --- -- .   ... .--. .. -.- . ...\n.- .-. .   ..-. .- -.- .";

//	string [] codeArray = new string[]  { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
	private Hashtable morseAlpha;

	public Image image1;
	public Image image2;
	bool imageVisable1;
	bool imageVisable2;

	// Use this for initialization
	void Start () {
		isGoing = true;
		miniGameScreen = GameObject.FindGameObjectWithTag ("MiniGame");

		encrypted.text = encyptedMessage;
		feedback.text = "";
		count = 0;
		waitAfterWinning = 300.0f;

		player = FindObjectOfType<PlayerController> ();
		player.gameObject.SetActive (false);

		imageVisable1 = true;
		imageVisable2 = false;
		image1.gameObject.SetActive (imageVisable1);
		image2.gameObject.SetActive (imageVisable2);

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
	}

	// Update is called once per frame
	void Update () {

		if (!isGoing) {
			waitAfterWinning -= 6.0f;
		}
		if (waitAfterWinning < 0) {
			player.gameObject.SetActive (true);
			ScoreManager.AddPoints (2000);
			levelLoader.StartLevel();
		}

	}

	public void SwitchCode() {

		imageVisable1 = !imageVisable1;
		imageVisable2 = !imageVisable2;
		image1.gameObject.SetActive (imageVisable1);
		image2.gameObject.SetActive (imageVisable2);

	}

	public void SubmitGuess(string arg0)
	{
		Debug.Log ("The user input: " + arg0);
		count++;
		arg0 = arg0.ToLower ();
		string answer = "some spikes are fake";
		encrypted.text = "";
		int inputLength = arg0.Length;
		for (var i = 0; i < answer.Length; i++) {
			if (i < inputLength) {
				//				Debug.Log ("Current letter is: " + arg0 [i] + " and the answer is: " + answer[i]);
				string currentChar = answer [i].ToString();
				if (arg0 [i] == answer [i]) {
					currentLetter.text = "";
					//					Debug.Log ("Current letter is: " + arg0 [i] + " and as a string is: " + arg0 [i].ToString ());
					currentLetter.supportRichText = true;
					currentLetter.text = "<color=#00ff00ff>"+ morseAlpha[answer [i].ToString()].ToString() + "</color>";
					encrypted.text += currentLetter.text + " ";  
				} else {
					currentLetter.text = "";
					currentLetter.text = morseAlpha[answer [i].ToString()].ToString();
					encrypted.text += currentLetter.text + " ";  
				}
			} else {
				currentLetter.text = "";
				currentLetter.text = morseAlpha[answer [i].ToString()].ToString();
				currentLetter.color = new Color (255, 255, 255);
				encrypted.text += currentLetter.text + " "; 
			}
		}

		encrypted.alignment = TextAnchor.UpperCenter;

		if (arg0.Equals (answer)) {
			feedback.text = "Well done! You cracked the code. You've earned bonus points!";
			isGoing = false;

		} else {
			feedback.text = "Keep guessing. Make sure you are consulting the guide.";
		}
	}
}

