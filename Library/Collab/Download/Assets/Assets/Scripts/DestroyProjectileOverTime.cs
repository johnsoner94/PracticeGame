using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectileOverTime : MonoBehaviour {

	/* This script is used to destroy projectile objects
	 * after a period of time. */

	//Time before projectile is destroyed after activation
	public float lifetime;
	public GameObject deathEffect;

	void Update () {

		// Destroy projectiles after their lifetime 
		// from the point of being initiated ends.
		lifetime -= Time.deltaTime;

		if (lifetime < 0) {
			Instantiate (deathEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}

	}
}