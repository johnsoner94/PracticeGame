using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContol : MonoBehaviour {

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



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//Uses the values above to see if enemy has come in contact with anything
		hittingPlayer = Physics2D.OverlapCircle (playerCheck.position, playerCheckRadius, whatisPlayer);
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatisWall);
		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatisWall);

		//If it has, reverse the enemy
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

        
	}
}
