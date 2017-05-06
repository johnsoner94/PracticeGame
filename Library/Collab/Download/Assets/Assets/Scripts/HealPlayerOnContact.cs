using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayerOnContact : MonoBehaviour {
	/* This script is used for health coin gameObjects.
	 * When the player collides with the health coins,
	 * the player is healed and the coin is destroyed-
	 * but only if the player is in need of health. */

	public int healthToGive;

	public GameObject collectedEffect;

	//Find the player, will be used to get current playr health
	private PlayerController player;

	// If a player collides with the health coin, 
	// give player health and destroy the coin.

	void OnTriggerEnter2D(Collider2D other){

		if (other.name == "Player") {

			// If the player's health is not already full, heal the player
			// and destroy the coin
			if (!HealthManager.isHealthFull()) {

				//Give health
				HealthManager.HealPlayer (healthToGive);

				Instantiate (collectedEffect, transform.position, transform.rotation);
		
				//Remove coin from screen
				Destroy (gameObject);
			}
		}
	}
}

