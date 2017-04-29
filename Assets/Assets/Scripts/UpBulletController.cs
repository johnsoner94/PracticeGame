using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBulletController : MonoBehaviour {
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
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        //		audioDie = GetComponent<AudioSource>();


        //if (player.transform.localScale.x < 0)
        //{
         //   speed = -speed;
       // }
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,- speed);
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") {
            //Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
            //Destroy (other.gameObject);
            //ScoreManager.AddPoints (pointsForKill);

            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
            //			if (other.GetComponent<EnemyHealthManager> ().enemyHealth <= 0) {
            //				audioDie.PlayOneShot (clipDie);
            //			}
        }
			
		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
    }
}

