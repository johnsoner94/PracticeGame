using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	/* Controller for L2 Boss that has it loosely hover between 
	 * floating platforms */

	public float moveSpeed;

	public bool moveRight;

	//Well checks to see if the enemy is hitting one of the floating platforms
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatisWall;
	private bool hittingWall;


	// Update is called once per frame
	void Update () {

		//Check if there is an overlap
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatisWall);

		// Switch directions if hitting a wall
		if (hittingWall) {
			moveRight = !moveRight;
		}

		// Make the boss gameobject move right or left depending on the boolean
		if (moveRight) {
			transform.localScale = new Vector3 (-2f, 2f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			transform.localScale = new Vector3 (2f, 2f, 1f);
		}
			

	}
}
