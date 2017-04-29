using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMove : MonoBehaviour {

    private PlayerController player;

    private Transform flyingEnemy;       // Enemy's Rigidbody2D

    public float moveSpeed;

    public float playerRange;

    public LayerMask playerLayer;

    public bool playerInRange;

    public bool facingAway;

    public bool followOnLookAway;

    
                                             
    void Start () {
       
        player = FindObjectOfType<PlayerController>();

        flyingEnemy = GetComponent<Transform>();   // set enemy's transform
    }
	
	// Update is called once per frame
	void Update () {

        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
        if (player.transform.position.x > flyingEnemy.transform.position.x)
            transform.localScale = new Vector3(-1f, 1f, 1f);       // move enemy right
                                                                  // if player's velocity is less than 0...
        else if (player.transform.position.x < flyingEnemy.transform.position.x)
            transform.localScale = new Vector3(1f, 1f, 1f);     // move enemy left


        if (!followOnLookAway)
        {

            if (playerInRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                return;
            }
        }
        if((player.transform.position.x < transform.position.x && player.transform.localScale.x < 0) || (player.transform.position.x > transform.position.x && player.transform.localScale.x > 0))   // when player is on left side of enemy and player is facing left
                                                                                                                                                                                                     // or when player is on right side of enemy and player is facing right
        {
            facingAway = true;
        }
        else
        {
            facingAway = false;
        }

        if (playerInRange  && facingAway)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, playerRange);
    }
}
