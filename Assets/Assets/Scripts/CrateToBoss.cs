using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateToBoss : MonoBehaviour {

	//Will be used to do animation when the boss is hit
	public bool playerInArea1;

	//Animator Object
	private Animator anim;

	//Pixel effects, other crates, and bossSneakPeak objects
	public GameObject deathEffect;
	public GameObject bossSneakPeak;
	public GameObject secondBox;
	public GameObject thirdBox;


	// Use this for initialization
	void Start () {
		
		//Start all bools as false
		playerInArea1 = false;

		//Creating animator for the crate to transform
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

		// set anim for when boss is hit once
		anim.SetBool("playerInArea1", playerInArea1);

		//Once the animation has begun, start the coroutine.
		if (playerInArea1) {
			StartCoroutine (KillOnAnimationEnd ());
		}
	}

	//If animation is over, destroy the crate.
	private IEnumerator KillOnAnimationEnd() {
		yield return new WaitForSeconds (3.0f);
		Instantiate(deathEffect, transform.position, transform.rotation);

		//While the crates disappear, have the boss appear.
		bossSneakPeak.SetActive (true);
		Destroy (secondBox);
		Destroy (thirdBox);
		Destroy (gameObject);
	}
}
