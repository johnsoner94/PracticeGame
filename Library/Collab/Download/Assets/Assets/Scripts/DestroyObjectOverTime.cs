using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOverTime : MonoBehaviour {

	/* This script is used to destroy CrumbleBox objects
	 * after a short period of time, making it seem like
	 * they are crumbling away. */

    public float lifetime;
	public bool startDestroy;

	public GameObject deathEffect;

	float dyingTime;

	// Use this for initialization
	void Start () {
		
		//Set the length of the dyingTime to the box's lifetime.
		dyingTime = lifetime;
		
	}
	
	// Update is called once per frame
	void Update () {

		// If player has come in contact with the crumble box
		if (startDestroy) {

			// Begin counting down the time
			dyingTime -= Time.deltaTime;

			// When the dying time runs out, begin crumbling through deatheffects. 
			if (dyingTime < 0) {
				Instantiate (deathEffect, transform.position, transform.rotation);

				// Deactivate the crumble box
				gameObject.SetActive (false);

				//Reset the dying time in case the player dies and the box needs to reactivate
				dyingTime = lifetime;
			}
		}
	}
}
