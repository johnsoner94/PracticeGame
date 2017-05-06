using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This scripts contols the behavior of a stationary jumping enemy */

public class JumpingEnemyControl : MonoBehaviour {

	public Transform groundCheck;               // enemy's groundCheck

	public float groundCheckRadius;        // radius to determine ground

	public LayerMask whatisGround;        // defines ground

	public float jumpHeight;              // height of enemy's jump

	private Animator anim;               // enemy's animation

	private bool grounded;                // true if on ground
      
    //Stops it from being a constant run of jumps
    public float waitBetweenJumping;         // amount of time between jumps
    private float jumpCounter;               // counter for waitingBetweenJumping

    void Start () {
		anim = GetComponent<Animator>();         // set anim
        jumpCounter = waitBetweenJumping;        // set JumpCounter
        
    }

	void FixedUpdate() {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatisGround);  // checks to see if grounded
       
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);     // plays anim

        jumpCounter -= Time.deltaTime;          // counts down
        
        if (grounded  && jumpCounter < 0)      // if onGround & jumpCounter is 0...
        {
            Jump();                          // jump          
            jumpCounter = waitBetweenJumping;  // reset jumpCounter
        }
     
    }
        
	// Jump function
	public void Jump()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);  // makes enemy move vertically jumpHeight
	}
		
}
