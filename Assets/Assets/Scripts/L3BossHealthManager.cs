using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // added for health bar

public class L3BossHealthManager : MonoBehaviour
{
    //Declare ints
    public int bossHealth;
    public int pointsOnDeath;
	private int bossHalfHealth;

    //Pixel effects
    public GameObject deathEffect;

    //Audio components for boss
    public AudioClip clipDie;
    private AudioSource audioDie;

    //Animator Object
    private Animator anim;

    //Will be used to do animation when the boss is hit
    private bool bossHit;
    private float bossHitCount; //Keeps track of time for bossHit animation


    //Checks if enemy dead
    private bool isDead;

    //Borders that are set up once the player approaches the boss
    public GameObject LBorder;
    public GameObject RBorder;


	//The crates will either be active or inactive depending on the player's progress
	public GameObject LstableCrate;
	public GameObject RstableCrate;
	public GameObject LmovingCrate;
	public GameObject RmovingCrate;

    // HealthBar to inactivate
    public GameObject healthBar;

	// Amount of smaller enemies lower limit
    // Neg. floats produce enemies to the left of the boss's position.x
	public float smallEnemiesLowerAmt; 

    // Amount of smaller enemies upper limit
    // Pos. floats produce enemies to the right of the boss's position.x
    public float smallEnemiesUpperAmt;

    // Type(s) of smaller enemy
    public GameObject smallEnemy1;
	public GameObject smallEnemy2;
	//public GameObject smallEnemy3;

	//Find the player, this will be used for knockback & gunDisable
	public PlayerController player;


    // Use this for initialization
    void Start()
    {
        audioDie = GetComponent<AudioSource>();

        //Start all bools as false
        isDead = false;
        bossHit = false;

        //Start hit count at 2. 
        bossHitCount = 2;

		//Get the value of the boss health originally
		bossHalfHealth = bossHealth/2;

        //Creating animator for when boss gets angry
        anim = GetComponent<Animator>();

		//Name the player 
		//player = FindObjectOfType<PlayerController>();


    }

    // Update is called once per frame
    void Update()
    {

        // set anim for when boss is hit once
        anim.SetBool("bossHit", bossHit);

        //Timer for bossHit Animation. Once bossHit times out, 
        // it returns to regular animation.
        if (bossHit == true && bossHitCount <= 0){
            //Reset boss hit and hit count
            bossHit = false;
            bossHitCount = 2;
        }
		if (bossHit == true){
            bossHitCount -= Time.deltaTime;
        }

		//If the boss health is at or past the half way point, 
		//trigger the two moving platforms and remove the two 
		//stable platforms.
		if (bossHealth <= bossHalfHealth) {
			LstableCrate.SetActive(false);
			RstableCrate.SetActive(false);
			LmovingCrate.SetActive(true);
			RmovingCrate.SetActive(true);
		}


        //If boss is killed, use this animation and effects
        if (bossHealth <= 0)
        {
            player.gunDisabled = false;               //player's gun is activated
            player.upShootDisabled = false;           // up shooting enabled
            Instantiate(deathEffect, transform.position, transform.rotation);
            

            if (!audioDie.isPlaying && !isDead)
            {
                audioDie.PlayOneShot(clipDie);           // play dying audio
                isDead = true;
            }

			if (!audioDie.isPlaying && isDead) {
				ScoreManager.AddPoints (pointsOnDeath);             // add points
                
                
                //make smaller enemies appear
               // for (float i = smallEnemiesLowerAmt; smallEnemiesLowerAmt < smallEnemiesUpperAmt; i = i + .5f)
                //{
                 GameObject enemy = Instantiate(smallEnemy1, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
				 GameObject enemy1 = Instantiate(smallEnemy2, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
			     GameObject enemy2 = Instantiate (smallEnemy1, new Vector3 (transform.position.x + 1f, transform.position.y, transform.position.z),transform.rotation) as GameObject;
				 GameObject enemy3 = Instantiate (smallEnemy2, new Vector3 (transform.position.x + 1f, transform.position.y, transform.position.z),transform.rotation) as GameObject;
				 GameObject enemy4 = Instantiate (smallEnemy1, new Vector3 (transform.position.x - 1f, transform.position.y, transform.position.z),transform.rotation) as GameObject;
				 GameObject enemy5 = Instantiate (smallEnemy2, new Vector3 (transform.position.x - 1f, transform.position.y, transform.position.z),transform.rotation) as GameObject;
				 GameObject enemy6 = Instantiate (smallEnemy1, new Vector3 (transform.position.x + 2f, transform.position.y, transform.position.z),transform.rotation) as GameObject;
				 GameObject enemy7 = Instantiate (smallEnemy2, new Vector3 (transform.position.x + 2f, transform.position.y, transform.position.z),transform.rotation) as GameObject;
				 GameObject enemy8 = Instantiate (smallEnemy1, new Vector3 (transform.position.x - 2f, transform.position.y, transform.position.z),transform.rotation) as GameObject;
				 GameObject enemy9 = Instantiate (smallEnemy2, new Vector3 (transform.position.x - 2f, transform.position.y, transform.position.z),transform.rotation) as GameObject;
			
                //Once boss dies, disable the borders, healthbar, and moving platforms
				Destroy(gameObject);  
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
        Debug.Log("Giving Boss damage!!!!!!!!!!!!!!!!!");

        //Run the boss hit animation by setting bool to true
        bossHit = true;

		//Push the player off the vulnerable gameobject through the player object's 
		// other knockback that does not flash red.
		player.knockbackCount2 = player.knockbackLength2;

		if (player.transform.position.x < transform.position.x) {
			player.knockfromRight2 = true;
		} else {
			player.knockfromLeft2 = true;
		}

    }
	// returns current health for health bar
    public int getHealth()
    {
        return bossHealth;
    }
		
}

