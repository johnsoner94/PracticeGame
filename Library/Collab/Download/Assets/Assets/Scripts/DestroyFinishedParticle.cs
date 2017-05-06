using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script is used to destroy particle effects */

public class DestroyFinishedParticle : MonoBehaviour {

	private ParticleSystem thisParticleSystem;


	// Use this for initialization
	void Start () {
		thisParticleSystem = GetComponent<ParticleSystem> ();   // sets particle system
	}
	
	// Update is called once per frame
	void Update () {
		if (thisParticleSystem.isPlaying)       //if the particle is playing...
			return;                           // let play 

		Destroy (gameObject);          // else, destroy    
	}


	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
