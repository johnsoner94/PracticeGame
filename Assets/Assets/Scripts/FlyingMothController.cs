using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMothController : MonoBehaviour {

	// Set the speed of the enemy
	public float moveSpeed;

	//The way the enemy starts to walk
	public bool moveRight; 

	public Transform wallCheck;

	public float wallCheckRadius;

	public LayerMask whatisWall;

	private bool hittingWall;

    private PlayerController player;

	public Transform firePoint;

	public GameObject bomb;

	public float playerRange;

	public LayerMask playerLayer;

	public bool playerInRange;

    //Stops it from being a constant run of projectiles
    public float waitBetweenShooting;
    private float shotCounter;


    // Use this for initialization
    void Start()
    {

        shotCounter = waitBetweenShooting;
        player = FindObjectOfType<PlayerController>();

        
    }
    

    // Update is called once per frame
    void Update()
    {
        //Decide how long between shots
        shotCounter -= Time.deltaTime;
        // Check if player in range
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
        // Check if hitting wall
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatisWall);
        // Change direction if hitting wall
		if (hittingWall)
			moveRight = !moveRight;

		//Flip the enemy the other way
		if (moveRight) {

			transform.localScale = new Vector3 (-2f, 2f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			transform.localScale = new Vector3 (2f, 2f, 1f);
		}
        // If player is in range, drop bombs
        if (shotCounter < 0 && playerInRange)
        {
            
            Instantiate(bomb, firePoint.position, firePoint.rotation);
            shotCounter = waitBetweenShooting;

        }  

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, playerRange);
    }
   
}


