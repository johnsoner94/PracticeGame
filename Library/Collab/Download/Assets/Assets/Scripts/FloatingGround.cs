using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloatingGround : MonoBehaviour {

	/* Script for floating ground platform. 
	 * It hovers above ground and flips depending on the 
	 * direction, much like walking enemies */

	public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatisWall;
	private bool hittingWall;


	// Update is called once per frame
	void Update () {

		//Check if have hit other side
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatisWall);

		//If hitting other side, switch directions
		if (hittingWall)
			moveRight = !moveRight;

		//How direction is switched
		if (moveRight) {
			transform.localScale = new Vector3 (-2f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			transform.localScale = new Vector3 (2f, 1f, 1f);
		}

	}
}

