using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileLeft : MonoBehaviour {


	//For Right Enemy Projectiles
	public float speed;

	public PlayerController player;

	public GameObject impactEffect;

	public int damageToGive;



	// Use this for initialization
	void Start () {

		//Finds where the player is in relation to the L2 Boss
		player = FindObjectOfType<PlayerController> ();

		//If player is to the left of projectile, it will go left. Vice Versa.
	//	if (player.transform.position.x < transform.position.x) {	
			speed = -speed;
	//	}
	}


	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, -GetComponent<Rigidbody2D> ().velocity.y);

	}

	//If hits player, hurt player
	void OnTriggerEnter2D(Collider2D other)
	{
		//THIS IS THE CODE THAT WORKS
		//If it hits the plater
		if (other.name == "Player") {
			HealthManager.HurtPlayer (damageToGive);
			Instantiate (impactEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		if (other.tag == "Ground") {
			Destroy (gameObject);

		}


	}
}