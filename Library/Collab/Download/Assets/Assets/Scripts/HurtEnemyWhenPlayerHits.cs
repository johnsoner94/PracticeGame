using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyWhenPlayerHits : MonoBehaviour {

	/* This script injures an enemy whenever the player
	 * collides with the game object. Also, when the player
	 * collides with the game object, it knocks the player
	 * back and destroys the game object. */

	public GameObject impactEffect;

	public int damageToGive;

	public GameObject enemy;

	//Find the player, this will be used for knockback 
	private PlayerController player;


	void Start() {
		// Find the player
		player = FindObjectOfType<PlayerController>();
	}


	//When player collides with the vulnerable spot, injure the specified enemy game object.
	void OnCollisionEnter2D(Collision2D other){
		if(other.transform.tag == "Player")
		{
			//Injure enemy
			enemy.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);

			//Push the player off the vulnerable gameobject through the player object's 
			// other knockback that does not flash red and does not go far.
			player.knockbackCount2 = player.knockbackLength2;

			if (player.transform.position.x < transform.position.x) {
				player.knockfromRight3 = true;
			} else {
				player.knockfromLeft3 = true;
			}
				
			StartCoroutine (DestroyVulnerableSpot());
		}

	}

	//Delay so that Vulnerable Spot is not deleted before enemy is destroyed, 
	//because otherwise the player will land on the enemy and get hurt. 
	//The vulnerable spot is destroyed to the player cannot just stand on "nothing"
	private IEnumerator DestroyVulnerableSpot() {
		yield return new WaitForSeconds (0.7f);
		Destroy (gameObject);
	}


}
