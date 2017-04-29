using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2BossProjectileController : MonoBehaviour {

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
		//This doesnt seem to work.....
		if (player.transform.position.x < transform.position.x) {	
			speed = -speed;
		}
			

		//Set the waitingtogrow time to be the time it should wait for
		waitingToGrow = waitBeforeGrowing;

	}


	// Update is called once per frame
	void Update () {
		waitingToGrow -= Time.deltaTime;

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

		//Have the projectile follow the player
		transform.position = Vector3.Lerp (transform.position, player.transform.position,Time.deltaTime);

		//This will allow the projectile to grow as the projectile is firing
		if (transform.localScale.x < maxScale && waitingToGrow < 0) {
			transform.localScale += Vector3.one * growSpeed;
			waitingToGrow = waitBeforeGrowing;
		}
	}

	//If hits player, hurt player
	void OnTriggerEnter2D(Collider2D other)
	{
		//If it hits the plater
		if (other.name == "Player") {
			Instantiate (impactEffect, transform.position, transform.rotation);
			Destroy (gameObject);
			HealthManager.HurtPlayer (damageToGive);
		}



	}
}