using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyControl : MonoBehaviour {
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatisGround;
	public float jumpHeight;
	private Animator anim;
	private bool grounded;
      
    //Stops it from being a constant run of jumps
    public float waitBetweenJumping;
    private float jumpCounter;

    void Start () {
		anim = GetComponent<Animator>();
        jumpCounter = waitBetweenJumping;
        
    }

	void FixedUpdate() {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatisGround);
       
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);

        //Decide how long between jumps
        

       jumpCounter -= Time.deltaTime;
        
        if (grounded  && jumpCounter < 0)
        {
            //Debug.Log("2");
            Jump();           
            jumpCounter = waitBetweenJumping;
            //Debug.Log("3");
        }
       

        
    }
        

	public void Jump()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}

    

}
