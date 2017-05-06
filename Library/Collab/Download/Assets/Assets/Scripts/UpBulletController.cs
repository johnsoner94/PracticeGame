using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script controls the behavior of bullets that travel upward*/

public class UpBulletController : MonoBehaviour {
    public float speed;      // speed of bullet

    public PlayerController player;    // player

    public GameObject enemyDeathEffect;   // enemy death particle effect

    public GameObject impactEffect;      // bullet particle effect

    public float lifeTime;     // lifetime of bullet

    public int pointsForKill;    // points for killing

    public int damageToGive;      // amount of damage it gives


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
       
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame              
    void Update()                             // makes bullet travel upward
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,- speed);
    }

    // If enemy is hit, give damage and destroy bullet
	void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Enemy") {
           
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
           
        }
			
		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
    }
}

