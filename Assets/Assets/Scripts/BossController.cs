using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	// Is the player close to the boss/enemy?

	public float moveSpeed;

	public bool moveRight;

	//Well checks to see if the enemy is hitting one of the floating platforms
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatisWall;
	private bool hittingWall;



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatisWall);


		if (hittingWall)
			moveRight = !moveRight;

		if (moveRight) {

			transform.localScale = new Vector3 (-2f, 2f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			transform.localScale = new Vector3 (2f, 2f, 1f);
		}
			

	}
}
