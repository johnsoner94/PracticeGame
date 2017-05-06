using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	/* This script is a basic enemy health manager. 
	 * It sets the enemy's health, gives damage to
	 * the enemy's health, and destroys the enemy / 
	 * gives the player points when the enemy runs
	 * out of health. */

	//How much health the enemy has
	public int enemyHealth;

	// Particle effect for death
	public GameObject deathEffect;

	//How many points the player gets for defeating the enemy
	public int pointsOnDeath;

	// Audio for enemy death
	public AudioClip clipDie;
	private AudioSource audioDie;

	//Checks if enemy is out of health
	private bool isDead;


	// Use this for initialization
	void Start () {
		audioDie = GetComponent<AudioSource>();
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (enemyHealth <= 0) {
			Instantiate (deathEffect, transform.position, transform.rotation);
			ScoreManager.AddPoints (pointsOnDeath);

			if (!audioDie.isPlaying && !isDead) {
				audioDie.PlayOneShot (clipDie);
				isDead = true;
			}
			if (!audioDie.isPlaying && isDead)
				Destroy (gameObject);
		}
	}

	public void giveDamage(int damageToGive)
	{
		enemyHealth -= damageToGive;

	}

}
