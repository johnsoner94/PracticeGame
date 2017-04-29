using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3BossProjectileController : MonoBehaviour {

	//The player
	public PlayerController player;

	//Destroy effect
	public GameObject impactEffect;

	//What are the projectiles
	public GameObject LprojectileHigher;
	public GameObject LprojectileLower;
	public GameObject RprojectileHigher;
	public GameObject RprojectileLower;
	public GameObject DLprojectileHigher;
	public GameObject DLprojectileLower;
	public GameObject DRprojectileHigher;
	public GameObject DRprojectileLower;
	public GameObject AntennaRprojectile;
	public GameObject AntennaLprojectile;

	//Where to fire from
	public Transform launchRightHigher;
	public Transform launchRightLower;
	public Transform launchLeftHigher;
	public Transform launchLeftLower;
	public Transform launchDownLeftHigher;
	public Transform launchDownLeftLower;
	public Transform launchDownRightHigher;
	public Transform launchDownRightLower;
	public Transform launchRightHigherAntenna;
	public Transform launchLeftHigherAntenna;

	//Stops it from being a constant r un of projectiles
	public float waitBetweenShooting;
	private float shotCounter;

	//Will be used to do animation when boss is looking at Player
	private bool goRight;
	private bool goLeft;


	//Animator Object
	private Animator anim; 

	// Use this for initialization
	void Start () {

		//Finds where the player is in relation to the L2 Boss
		player = FindObjectOfType<PlayerController> ();

		//Start all animation bools as false
		goRight = false;
		goLeft = false;

		//Creating animator for when boss gets angry
		anim = GetComponent<Animator>();           
	}


	// Update is called once per frame
	void Update () {
		//Decide how long between shots
		shotCounter -= Time.deltaTime;
	
		// set anim for boss to look at where the player is
		anim.SetBool ("goRight", goRight);     
		anim.SetBool ("goLeft", goLeft);    

		//If the player is to the left of the boss, have the boss shoot projectiles down and to the left
		if (player.transform.position.x < transform.position.x) {	
			goRight = false;
			goLeft = true;


			if (shotCounter < 0) {

				Instantiate (RprojectileHigher, launchLeftHigher.position, launchLeftHigher.rotation);
				Instantiate (RprojectileLower, launchLeftLower.position, launchLeftLower.rotation);

				Instantiate (DLprojectileHigher, launchDownLeftHigher.position, launchDownLeftHigher.rotation);
				Instantiate (DLprojectileLower, launchDownLeftLower.position, launchDownLeftLower.rotation);

				Instantiate (DRprojectileHigher, launchDownRightHigher.position, launchDownRightHigher.rotation);
				Instantiate (DRprojectileLower, launchDownRightLower.position, launchDownRightLower.rotation);

				//Shoot from Antennas
				//Instantiate (LprojectileHigher, launchRightHigherAntenna.position, launchRightHigherAntenna.rotation);
				Instantiate (AntennaRprojectile, launchLeftHigherAntenna.position, launchLeftHigherAntenna.rotation);

				shotCounter = waitBetweenShooting;
			} 

		} 

		//If the player is to the left of the boss, have the boss shoot projectiles down and to the right
		if (player.transform.position.x > transform.position.x ) {
			goLeft = false;
			goRight = true;

			if (shotCounter < 0) {

				Instantiate (LprojectileHigher, launchRightHigher.position, launchRightHigher.rotation);
				Instantiate (LprojectileLower, launchRightLower.position, launchRightLower.rotation);

				Instantiate (DLprojectileHigher, launchDownLeftHigher.position, launchDownLeftHigher.rotation);
				Instantiate (DLprojectileLower, launchDownLeftLower.position, launchDownLeftLower.rotation);

				Instantiate (DRprojectileHigher, launchDownRightHigher.position, launchDownRightHigher.rotation);
				Instantiate (DRprojectileLower, launchDownRightLower.position, launchDownRightLower.rotation);

				//Shoot from Antennas
				Instantiate (AntennaLprojectile, launchRightHigherAntenna.position, launchRightHigherAntenna.rotation);
				//Instantiate (RprojectileHigher, launchLeftHigherAntenna.position, launchLeftHigherAntenna.rotation);


				shotCounter = waitBetweenShooting;
			} 
		}

	}

	//Damage in the individual projectile script

}