using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayerOnContact : MonoBehaviour {

	public int healthToGive;

	public GameObject collectedEffect;

	//Find the player, will be used to get current playr health
	private PlayerController player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	//If a player collects the health coin, give player health and destroy the coin.

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {

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

