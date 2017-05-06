using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootingEnemyControl : MonoBehaviour {
	/* Script for enemies that walk and continually shoot
	 * projectiles from both sides */


	// Set the speed of the enemy
	public float moveSpeed;

	//The way the enemy starts to walk
	public bool moveRight;

	//Checks for if enemy hits wall
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatisWall;
	private bool hittingWall;

	//Checks for if enemy hits edge
	private bool notAtEdge;
	public Transform edgeCheck;

	//Checks for if enemy hits player
	public Transform playerCheck;
	public float playerCheckRadius;
	public LayerMask whatisPlayer;
	private bool hittingPlayer;


	//VALUES FOR SHOOTING
	// Is the player close to the enemy?
	public float playerRange;

	//Projectiles that will go at speed 4
	public GameObject RprojectileSlow;
	public GameObject LprojectileSlow;

	//Projectiles that will go at speed 8
	public GameObject RprojectileFast;
	public GameObject LprojectileFast;

	//Find the player
	public PlayerController player;

	//Where to fire from
	public Transform launchPoint;
	public Transform launchPoint2;

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

		//Uses the values above to see if enemy has come in contact with anything
		hittingPlayer = Physics2D.OverlapCircle (playerCheck.position, playerCheckRadius, whatisPlayer);
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatisWall);
		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatisWall);


		//See the fire trajectory
		Debug.DrawLine (new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));

		//Decide how long between shots
		shotCounter -= Time.deltaTime;

		//If the enemy has hit something, reverse the enemy
		if (hittingWall || !notAtEdge || hittingPlayer)
			moveRight = !moveRight;

		//Flip the enemy the other way
		if (moveRight) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}

		//If the enemy is going left and its time to shoot, shoot the right projectile from the rightmost launch point,
		//the left projectile from the leftmost launchpoint.
		if (shotCounter < 0 && !moveRight) {
			Instantiate (LprojectileSlow, launchPoint2.position, launchPoint2.rotation);
			Instantiate (RprojectileFast, launchPoint.position, launchPoint.rotation);
			shotCounter = waitBetweenShooting;
		} 

		//If the enemy is going right and its time to shoot, shoot the right projectile from the newly rightmost 
		//launch point, and shoot the left projectile from the newly leftmost launch point (since the enemy has
		//been flipped).
		if (shotCounter < 0 && moveRight) { 
			Instantiate (RprojectileSlow, launchPoint2.position, launchPoint2.rotation);
			Instantiate (LprojectileFast, launchPoint.position, launchPoint.rotation);
			shotCounter = waitBetweenShooting;
		}


	}
}