using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;            // variable for player speed
	private float moveVelocity;        // variable for player movement
	public float jumpHeight;           // variable for player jump height

	public Transform groundCheck;        // transform object for detecting ground
	public float groundCheckRadius;      // size of groundCheck
	public LayerMask whatisGround;       // layer for what is ground
	private bool grounded;               // tells if on ground

	private bool doubleJumped;          // tells if doubleJumping
    public bool gunDisabled;            // tells if gun is operational
    public bool upShootDisabled;        // tells if up shooting is operational
	private Animator anim;             // animator object

	public Transform upperFirePoint;        // transform object for detecting where to shoot from
	public Transform firePoint;        // transform object for detecting where to shoot from
	public GameObject ninjaStar;       // ninjaStar object
    public GameObject upBullet;       // upBullet object
    public GameObject machineGunBullet;       // machineGunBullet object
	public GameObject deathRay;         // deathRay object

	public float shotDelay;             // float for delay between shots
	private float shotDelayCounter;     // counter for shots

    public float knockback;             // determines knockback
    public float knockbackLength;       // determines length of knockBack
    public float knockbackCount;        // counter for knockBacks
    public bool knockfromRight;         // determines if being knockedBackfromRight
    public bool knockedBack;            // tells if being knockedBack

	public float knockback2;             // determines knockback for boss (without hurt health & go far)
	public float knockback3;             // determines knockback for boss (without hurt health & go not far)
	public float knockbackLength2;       // determines length of knockBack (without hurt health)
	public float knockbackCount2;        // counter for knockBacks (without hurt health)
	public bool knockfromRight2;         // determines if being knockedBackfromRight (without hurt health & go far)
	public bool knockfromRight3;         // determines if being knockedBackfromRight (without hurt health & go not far)
	public bool knockfromLeft2;         // determines if being knockedBackfromLeft (without hurt health & go far)
	public bool knockfromLeft3;         // determines if being knockedBackfromLeft (without hurt health & go not far)
	public bool knockedBack2;            // tells if being knockedBack (without hurt health)


	private Rigidbody2D myrigidbody2D;       // Player's Rigidbody2D

	public bool rapidFire;        // tells if in rapid fire

    public bool onLadder;         // Variables to climb ladder
    public bool movingOnLadder;   // bool for ladder animation
    public float climbSpeed;      // how fast the player move's on the ladder
    private float climbVelocity;   // adjusts the player's velocity on ladder
    private float gravityStore;    // saves player's gravity setting

    public bool speedMode;      // variable to tell if speedMode is active 
    public float speedUp;        // variable to set speedMode speed

	

	/// <summary>
	/// Audio stuff
	/// </summary>
	
	public AudioClip clipJetPack;   // sound for doublejump
    public AudioClip clipKnock;     // sound for knockback
	private AudioSource audioJump;
    private AudioSource audioKnock;


	public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol) { 
		AudioSource newAudio = gameObject.AddComponent<AudioSource>();
		newAudio.clip = clip; 
		newAudio.loop = loop;
		newAudio.playOnAwake = playAwake;
		newAudio.volume = vol; 
		return newAudio; 
	}

	public void Awake(){
		// add the necessary AudioSources:
		//audioShoot = AddAudio(clipShot, false, false, 0.7F);
		audioJump = AddAudio(clipJetPack, false, false, 1F);
        audioKnock = AddAudio(clipKnock, false, false, 1F);
	}


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();           // set anim to Animator for player

		myrigidbody2D = GetComponent<Rigidbody2D> ();   // set myrigidbody2D to player Rigidbody2D

		knockbackCount = 0;							// Emily added this so that the character doesn't knockback at the load of the scene.
		knockbackCount2 = 0;
		grounded = true;                    // set grounded true
		doubleJumped = false;               // set doublejump false
        gunDisabled = false;                // set gun active
        upShootDisabled = false;            // set upshooting active
		rapidFire = false;                  // set rapid fire inactive
        speedMode = false;                  // set speedMode inactive
        gravityStore = myrigidbody2D.gravityScale;        // Stores gravity for climbing ladders 


	}

	// Establishes if grounded
	void FixedUpdate() {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatisGround);   // checks to see if grounded
	}
	// Update is called once per frame
	void Update () {
		
		if (grounded) {                            // if grounded...
			doubleJumped = false;	             // cannot doubleJump
			audioJump.Stop();

		} 

		anim.SetBool ("Grounded", grounded);         // set anim for grounded
		anim.SetBool ("DoubleJump", doubleJumped);   // set anim for doubleJumped
		anim.SetBool("knockedBack", knockedBack);   // set anim for knockedBack
		anim.SetBool("knockedBack2", knockedBack2);   // set anim for knockedBack (without health damage)
		anim.SetBool("onLadder", onLadder);         // set anim for onLadder Idle
		anim.SetBool("movingOnLadder", movingOnLadder);  // set anim for moving on Ladder

		if (Input.GetButtonDown("Jump") && grounded) {                  //if up arrow is pressed and player is grounded...
			Jump ();                                                           // perform jump

		}
			

		if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded) {     // if up is pressed and player is not doubleJumped or grounded...		
			Jump ();               // perform jump(doubleJump)
			doubleJumped = true;       // player is doubleJumping
			audioJump.Play();

		}
        

	

        if (speedMode == true)           // if speedMode is active
        {

            moveVelocity = speedUp * Input.GetAxisRaw("Horizontal");        // speed up settings
        }

        else
        {
            // Code to move left and right
           

            moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");  // normal speed
        }
        

        // if knockback is 0 or less...

        if (knockbackCount <= 0) {
			myrigidbody2D.velocity = new Vector2(moveVelocity, myrigidbody2D.velocity.y);      //adjust y velocity
            knockedBack = false;
        }
		// if knockback is greater than 0...
        else  {
            knockedBack = true;
            
            if (knockfromRight)
				myrigidbody2D.velocity = new Vector2(- knockback,knockback);          // if knocked from right, push player left and vertically
            if(!knockfromRight)
				myrigidbody2D.velocity = new Vector2(knockback, knockback);          // if knocked from left, push player right and vertically
            audioKnock.Play();
            knockbackCount -= Time.deltaTime;                                        // reduce knockbackCount
        }
			

		// if knockback is 0 or less, stop knocking back (without hurting health)
		if (knockbackCount2 <= 0) {
			myrigidbody2D.velocity = new Vector2(moveVelocity, myrigidbody2D.velocity.y);      //adjust y velocity
			knockedBack2 = false;
			knockfromLeft3 = false;
			knockfromRight3 = false;
			knockfromLeft2 = false;
			knockfromRight2 = false;
		}

		//Continue the knocking back action
		else {
			knockedBack2 = true;

			if (knockfromRight2){
				myrigidbody2D.velocity = new Vector2(- 60,20);          // if knocked from right, push player left and vertically
				Debug.Log ("kr2 " + myrigidbody2D.velocity);

			}
			if (knockfromLeft2) {
				myrigidbody2D.velocity = new Vector2 (60, 20);          // if knocked from left, push player right and vertically
				Debug.Log ("kL2 " + myrigidbody2D.velocity);
	
			} 
			if (knockfromRight3){
				myrigidbody2D.velocity = new Vector2(- 2,10);          // if knocked from right, push player left and vertically
				Debug.Log ("kr3 " + myrigidbody2D.velocity);

			}
			if(knockfromLeft3){
				myrigidbody2D.velocity = new Vector2(2, 10);          // if knocked from left, push player right and vertically
				Debug.Log ("kL3 " + myrigidbody2D.velocity);

			}

			audioKnock.Play();
			knockbackCount2 -= Time.deltaTime;                                        // reduce knockbackCount
		}



		anim.SetFloat ("Speed", Mathf.Abs (myrigidbody2D.velocity.x));                     // Set anim speed


		// if player's velocity is greater than 0...

		if (myrigidbody2D.velocity.x > 0)
			transform.localScale = new Vector3 (1f, 1f, 1f);       // move player right
		// if player's velocity is less than 0...
		else if (myrigidbody2D.velocity.x < 0)
			transform.localScale = new Vector3 (-1f, 1f, 1f);     // move player left

		// if right alt, left alt, return, or space are pressed... (single fire)
		if (rapidFire == false && gunDisabled == false) {
			
			if (Input.GetButtonDown ("Fire1")) {
				Instantiate (ninjaStar, firePoint.position, firePoint.rotation);                 // make ninjaStar and fire
				shotDelayCounter = shotDelay;                                                 // adjust shotDelayCounter
				Instantiate (ninjaStar, firePoint.position, firePoint.rotation);        // make ninjaStar and fire
			}
            if(upShootDisabled == false) {

                if (Input.GetButtonDown("Fire2"))
                {
                    Instantiate(upBullet, upperFirePoint.position, upperFirePoint.rotation);                 // make ninjaStar and fire
                    shotDelayCounter = shotDelay;                                                 // adjust shotDelayCounter
                    Instantiate(upBullet, upperFirePoint.position, upperFirePoint.rotation);        // make ninjaStar and fire
                }
			}
            
		} else if(rapidFire == true){
				// if right alt, left alt, return, or space are pressed... (auto fire)
				if ((Input.GetButton("Fire1"))) {
			
					shotDelayCounter -= Time.deltaTime;                                          // adjust shotDelayCounter

					// if shotDelayCounter is less than 0...
					if (shotDelayCounter <= 0) {
						shotDelayCounter = shotDelay;                                           // adjust shotDelayCounter
					Instantiate (machineGunBullet, firePoint.position, firePoint.rotation);        // make ninjaStar and fire
						//audioShoot.Play ();
					}
				}
        
	     }
       
        if(onLadder && (myrigidbody2D.velocity.y > 0))    // If moving up or down on Ladder, for anim
        {
            movingOnLadder = true;
        }
        // Code for climbing ladders JG 3/24/17
        if (onLadder)                                 // if onLadder...
        {
            myrigidbody2D.gravityScale = 0f;      // No Gravity
            doubleJumped = false;             // cannot double jump
            grounded = true;                  // grounded for animation purposes
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");     // set velocity

            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, climbVelocity);  // move up or down
           

                   
        }
        if (!onLadder)                          // if exiting ladder...
        {
            myrigidbody2D.gravityScale = gravityStore;   // restore gravity
        }

	}

	// makes player jump
	public void Jump()
	{
		myrigidbody2D.velocity = new Vector2 (myrigidbody2D.velocity.x, jumpHeight);    // change player's y to +jumpHeight
	}


	// Makes player stay still on a moving platform...

	// or if destroy terrian
	void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log ("The player is colliding with: " + other.transform.tag);
		if(other.transform.tag == "MovingPlatform")    // if player enters a tagged "MovingPlatform"
		{
			transform.parent = other.transform;         // player becomes child of platform
		}

		if (other.transform.tag == "CrumbleBox")     // if player enters a crumblebox
		{
			other.transform.GetComponent<DestroyObjectOverTime> ().startDestroy = true;   // start destorying box
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform")   // if player exits a tagged "MovingPlatform"
		{
			transform.parent = null;          // player is no longer child of platform
		}
	}
		

}