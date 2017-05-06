using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2BossProjectileController : MonoBehaviour {

	/* This script is specifically for the L2 Boss's heart
	 * projectiles. The projectiles follow the player and grow 
	 * incrementally until reaching the maxScale. The projectiles
	 * are destroyed and injure the player when the player
	 * collides with them */

	public float speed;

	public PlayerController player;

	public GameObject impactEffect;

	public int damageToGive;

	//How the much projectile will grow and how quickly
	public float maxScale;
	public float growSpeed;    

	//Helps projectile grow slowly
	public float waitBeforeGrowing;
	private float waitingToGrow;


	// Use this for initialization
	void Start () {

		//Finds where the player is in relation to the L2 Boss
		player = FindObjectOfType<PlayerController> ();

		//If player is to the left of projectile, it will go left. Vice Versa.
		if (player.transform.position.x < transform.position.x) {	
			speed = -speed;
		}
			
		//Set the waitingtogrow time to be the time it should wait for
		waitingToGrow = waitBeforeGrowing;

	}


	// Update is called once per frame
	void Update () {
		// Decrease the waitingToGrow time with each update.
		waitingToGrow -= Time.deltaTime;

		// Move the projectile gameobject
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

		//Have the projectile follow the player
		transform.position = Vector3.Lerp (transform.position, player.transform.position,Time.deltaTime);

		//This will allow the projectile to grow as the projectile is firing
		if (transform.localScale.x < maxScale && waitingToGrow < 0) {
			transform.localScale += Vector3.one * growSpeed;
			waitingToGrow = waitBeforeGrowing;
		}
	}

	//If it collides with the player, hurt the player and destroy the projectile
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			Instantiate (impactEffect, transform.position, transform.rotation);
			Destroy (gameObject);
			HealthManager.HurtPlayer (damageToGive);
		}



	}
}