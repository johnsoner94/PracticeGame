using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {

	/* This basic script is used by any gameObject that
	 * needs to injure the player on contact. It also 
	 * knocksback the player and plays the player injured
	 * animation */

	public int damageToGive;

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			HealthManager.HurtPlayer (damageToGive);


            var player = other.GetComponent<PlayerController>();
            player.knockbackCount = player.knockbackLength;

            if (other.transform.position.x < transform.position.x)
                player.knockfromRight = true;
            else
                player.knockfromRight = false;
		}
	}
}
