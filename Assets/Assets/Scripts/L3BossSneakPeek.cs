using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3BossSneakPeek : MonoBehaviour {

	//These are used to let the player continue with level 3.
	public GameObject LBorder;
	public GameObject RBorder;
	public GameObject TopBorder;
	public GameObject Lightning;

	//Pixel Effect
	public GameObject deathEffect;

	public AudioClip clipLaugh;     // sound for laugh
	public AudioSource audioLaugh;

	void Start() { 
		audioLaugh = GetComponent<AudioSource> ();
		audioLaugh.playOnAwake = true;
	}


	// Update is called once per frame
	void Update () {

		//As soon as L3 Sneak Peak Boss is set active, begin
		//the coroutine that will destroy the Sneak Peak Boss
		//once the animation completes and the Coroutine that
		//will create the lightning.
		StartCoroutine (KillOnAnimationEnd ());
		StartCoroutine (startLightning ());

	}

	//If the animation for the L3 boss sneak peek is over, destroy it.
	//Also destroy the borders that kept the player in one area.
	private IEnumerator startLightning() {
		yield return new WaitForSeconds (1.2f);
		TopBorder.SetActive(false);
		Lightning.SetActive(true);
	}

	//If the animation for the L3 boss sneak peek is over, destroy it.
	//Also destroy the borders that kept the player in one area.
	private IEnumerator KillOnAnimationEnd() {
		yield return new WaitForSeconds (3.8f);
		LBorder.SetActive(false);
		RBorder.SetActive(false);
		Destroy(gameObject);
		Destroy (Lightning);
	}


}
