using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyHealthManager : MonoBehaviour {

	public int bossHealth;
	public int pointsOnDeath;

	public GameObject deathEffect;

	//Audio components for boss
	public AudioClip clipDie;
	private AudioSource audioDie;

	//Animator Object
	private Animator anim;  

	//Will be used to see number of hits
	private bool hitOnce;
	private bool hitTwice;

	//Checks if enemy dead
	private bool isDead;

	//Borders that are set up once the player approaches the boss
	public GameObject LBorder;
	public GameObject RBorder;

    // HealthBar to inactivate
    public GameObject healthBar;

    // Use this for initialization
    void Start () {
		audioDie = GetComponent<AudioSource>();

		//Start all bools as false
		isDead = false;
		hitOnce = false;
		hitTwice = false;

		//Creating animator for when boss gets angry
		anim = GetComponent<Animator>();           
	}

	// Update is called once per frame
	void Update () {

	

		//Set up animation bools for various anger of character
		anim.SetBool ("hitOnce", hitOnce);     // set anim for when boss is hit once
		anim.SetBool ("hitTwice", hitTwice);   // set anim for when boss is hit twice, now its mad

		//If boss is killed, use this animation and effects
		if (bossHealth <= 0) {
			Instantiate (deathEffect, transform.position, transform.rotation);
			
		
			if (!audioDie.isPlaying && !isDead) {
				audioDie.PlayOneShot (clipDie);
				isDead = true;
			}

            if (!audioDie.isPlaying && isDead)
            {
                ScoreManager.AddPoints(pointsOnDeath);
                Destroy(gameObject);

                //Once boss dies, disable the borders and healthbar
                LBorder.SetActive(false);
                RBorder.SetActive(false);
                healthBar.SetActive(false);
            }
        }
	}


	public void giveDamage(int damageToGive)
	{
		//When boss is hit with projectiles, reduce health.
		bossHealth -= damageToGive;
		Debug.Log ("boss health is" + bossHealth);

		if (bossHealth == 12) {
			Debug.Log ("hitting boss once, bosshealth is" + bossHealth);
			hitOnce = true;

		}
		if (bossHealth <= 8) {
			hitOnce = true;
			hitTwice = true;
			Debug.Log("hitting boss twice, bosshealth is" + bossHealth);
		}



	}
    public int getHealth()
    {
        return bossHealth;
    }

}
