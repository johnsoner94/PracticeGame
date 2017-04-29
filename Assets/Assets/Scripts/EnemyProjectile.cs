using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {


	//For Right Enemy Projectiles
	public float speed;

	public PlayerController player;

	public GameObject impactEffect;

	public int damageToGive;




	// Use this for initialization
	void Start () {

		//Defines the player
		player = FindObjectOfType<PlayerController> ();
		speed = -speed;

	}


	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

	}

	//If hits player, hurt player
	void OnTriggerEnter2D(Collider2D other)
	{

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