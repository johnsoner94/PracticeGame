using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // added for health bar

/* This script controls the NinjaStar(Bullet) behavior */

public class NinjaStarController : MonoBehaviour {

	public float speed;               // speed of projectile

	public PlayerController player;    // player

	public GameObject enemyDeathEffect;  // enemy death particle

	public GameObject impactEffect;     // ninja star particle

	public float lifeTime;    // life of projectile

	public int pointsForKill;    // points rewarded

	public int damageToGive;      // damage given



    // Use this for initialization
    void Start () {
		player = FindObjectOfType<PlayerController> ();
       

		if (player.transform.localScale.x < 0) {	 //adjust left or right shooting
			speed = -speed;
		}
		Destroy (gameObject, lifeTime);            // destoy bullet after lifetime
	}
	
	// Update is called once per frame           
	void Update () {                                        // move projectile
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")                     // if an enemy is hit...
		{                                            // give damage to enemy

			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);

		}
                                         // if a boss is hit, give damage
		if (other.tag == "Boss") {
			other.GetComponent<BossEnemyHealthManager> ().giveDamage (damageToGive);
		}



		Instantiate (impactEffect, transform.position, transform.rotation);      // create impactEffect
		Destroy (gameObject);                          // destroy bullet
	}
}
