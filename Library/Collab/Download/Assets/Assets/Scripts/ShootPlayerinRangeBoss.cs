using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootPlayerinRangeBoss : MonoBehaviour {
		/* Script for L2 boss to shoot heart projectiles at 
		 * the player when the player is within the current range.
		 * It continually shoot when player is nearby */

		// Is the player close to the boss
		public float playerRange;

		//What is the projectile
		public GameObject projectile;

		//Find the player
		public PlayerController player;

		//Where to fire from
		public Transform launchPoint;

		//Stops it from being a constant run of projectiles
		public float waitBetweenShooting;
		private float shotCounter;

		// Use this for initialization
		void Start () {
			player = FindObjectOfType<PlayerController> ();
			shotCounter = waitBetweenShooting;
		}

		// Update is called once per frame
		void Update () {

			//See the fire trajectory
			Debug.DrawLine (new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));

			shotCounter -= Time.deltaTime;


			//Depending on where the player is in reference to the boss, fire for launch point 1.
			if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0) {

				Instantiate (projectile, launchPoint.position, launchPoint.rotation); //shoots from launchpoint 1 when enemy is walking to the right
				shotCounter = waitBetweenShooting;
			}

			if (launchPoint.transform.localScale.x > 0 && player.transform.position.x < launchPoint.transform.position.x && player.transform.position.x > launchPoint.transform.position.x - playerRange && shotCounter < 0) {
				Instantiate (projectile, launchPoint.position, launchPoint.rotation); //shoots from launchpoint 1 when enemy going left
				shotCounter = waitBetweenShooting;
			}

		}
	}

