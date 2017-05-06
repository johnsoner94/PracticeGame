using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour {

	/* This script is used by the RayGun. It gives damage to 
	 * the enemies and bosses if it collides with them. */

    public int damageToGive;

    void OnTriggerEnter2D(Collider2D other)
    {

		if (other.tag == "Boss") {
			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
		}

		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
		}

		
	}


}
