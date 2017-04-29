using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;

	public GameObject deathEffect;

	public int pointsOnDeath;

	public AudioClip clipDie;
	private AudioSource audioDie;

	private bool isDead;


	// Use this for initialization
	void Start () {
//		isDead = false;
		audioDie = GetComponent<AudioSource>();
		isDead = false;
		
	}
	
	// Update is called once per frame
	void Update () {
//		if (enemyHealth <= 0 && !isDead) {
		if (enemyHealth <= 0) {
			Instantiate (deathEffect, transform.position, transform.rotation);
			ScoreManager.AddPoints (pointsOnDeath);
//			isDead = true;
			if (!audioDie.isPlaying && !isDead) {
				audioDie.PlayOneShot (clipDie);
				isDead = true;
			}
			if(!audioDie.isPlaying && isDead)
				Destroy (gameObject);
		}
	}


	public void giveDamage(int damageToGive)
	{
		enemyHealth -= damageToGive;

	}

}
