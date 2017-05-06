using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script controls the flying, attacking enemy's behavior, the enemy attempts to 
 * run into the player to cause damage */

public class FlyingEnemyMove : MonoBehaviour {

    private PlayerController player;     // Player

    private Transform flyingEnemy;       // Enemy's Rigidbody2D

    public float moveSpeed;     // Enemy's move speed

    public float playerRange;      //area around player for enemy to attack

    public LayerMask playerLayer;   // player Layer

    public bool playerInRange;    // enemy can attack

    public bool facingAway;       // is the player facing the enemy?

    public bool followOnLookAway;  // can attack only when player isn't looking

    
                                             
    void Start () {
       
        player = FindObjectOfType<PlayerController>();  // set player

        flyingEnemy = GetComponent<Transform>();   // set enemy's transform
    }
	
	// Update is called once per frame
	void Update () {

        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);  // check if player is in range
        if (player.transform.position.x > flyingEnemy.transform.position.x)
            transform.localScale = new Vector3(-1f, 1f, 1f);       // move enemy right
                                                                  // if player's velocity is less than 0...
        else if (player.transform.position.x < flyingEnemy.transform.position.x)
            transform.localScale = new Vector3(1f, 1f, 1f);     // move enemy left


        if (!followOnLookAway)   // if followOnLookAway is not true
        {

            if (playerInRange)          // if player is in range...
            {                           // move toward player's position
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                return;
            }
        }
        // sets facingAway
        if((player.transform.position.x < transform.position.x && player.transform.localScale.x < 0) || (player.transform.position.x > transform.position.x && player.transform.localScale.x > 0))   // when player is on left side of enemy and player is facing left
                                                                                                                                                                                                     // or when player is on right side of enemy and player is facing right
        {
            facingAway = true;
        }
        else
        {
            facingAway = false;
        }
        // if facingAway, attack player
        if (playerInRange  && facingAway)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        }

    }
    // function to draw attack range
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, playerRange);
    }
}
