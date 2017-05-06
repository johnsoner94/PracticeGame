using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {
    /* Script for the lighting that hits the player, "breaking the gun" */

    public PlayerController player;

    //Particle Effect
    public GameObject impactEffect;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

	//When lightning hits player, destroy lighting with particle effect
	void OnCollisionEnter2D(Collision2D other) {
	
		if (other.transform.tag == "Ground") {
           
			//Disable the player's gun compeletly once the lightning hits the ground
			player.gunDisabled = true;

			//Instead of destroying the lightning, change it to being inactive. 
			gameObject.SetActive(false);
			Instantiate (impactEffect, transform.position, transform.rotation);


		}
	}
}
