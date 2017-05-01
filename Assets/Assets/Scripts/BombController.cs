using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {
	public int damageToGive;                // how much damage bomb gives
	public GameObject impactEffect;         // particle effect for bomb

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {               // If bomb hits player
			
			HealthManager.HurtPlayer (damageToGive);    // Hurt player
		}
        Instantiate(impactEffect, transform.position, transform.rotation);   // Make particle effect
        Destroy(gameObject);    // destroy bomb
       
        
    }
    
}
