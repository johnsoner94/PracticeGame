using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectileOverTime : MonoBehaviour {

	public float lifetime;

	public GameObject deathEffect;

	// Update is called once per frame, destroy projectiles after their lifetime 
	// from the point of being initiated ends.
	void Update () {

		lifetime -= Time.deltaTime;

		if (lifetime < 0) {
			Instantiate (deathEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}

	}
}