using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // added for health bar


public class NinjaStarController : MonoBehaviour {

	public float speed;

	public PlayerController player;

	public GameObject enemyDeathEffect;

	public GameObject impactEffect;

	public float lifeTime;

	public int pointsForKill;

	public int damageToGive;

   
//	public AudioClip clipDie;
//	private AudioSource audioDie;


    // Use this for initialization
    void Start () {
		player = FindObjectOfType<PlayerController> ();
       
//		audioDie = GetComponent<AudioSource>();


		if (player.transform.localScale.x < 0) {	
			speed = -speed;
		}
		Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{

			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
//			if (other.GetComponent<EnemyHealthManager> ().enemyHealth <= 0) {
//				audioDie.PlayOneShot (clipDie);
//			}
		}

		if (other.tag == "Boss") {
			other.GetComponent<BossEnemyHealthManager> ().giveDamage (damageToGive);
		}

//		if (other.tag == "L3Boss") {
//            other.GetComponent<L3BossHealthManager>().giveDamage(damageToGive);
//        }

		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
