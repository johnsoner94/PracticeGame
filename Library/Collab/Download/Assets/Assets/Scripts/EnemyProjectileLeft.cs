using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileLeft : MonoBehaviour {

	/* This is a basic script for enemy projectiles that 
	 * shoot left. The projectile goes left until 
	 * hitting the ground or injuring the player */

	public float speed;

	public PlayerController player;

	public GameObject impactEffect;

	public int damageToGive;


	// Use this for initialization
	void Start () {

		//Finds where the player is
		player = FindObjectOfType<PlayerController> ();

		//Sets starting speed 
		speed = -speed;

	}


	// Update is called once per frame
	void Update () {

		// Begin the projectile's velocity
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, -GetComponent<Rigidbody2D> ().velocity.y);

	}

	//If hits player, hurt player
	void OnTriggerEnter2D(Collider2D other)
	{
		//If it hits the player, injure the player and destroy the object
		if (other.name == "Player") {
			HealthManager.HurtPlayer (damageToGive);
			Instantiate (impactEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		//If it hits the ground, just destroy the object
		if (other.tag == "Ground") {
			Destroy (gameObject);
		}



	}
}