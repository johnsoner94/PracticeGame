using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script to tell if player is on a ladder object*/

public class LadderZone : MonoBehaviour {

    private PlayerController thePlayer;    //player

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();  // set player
	}
	
    // If player enters ladder zone, player is onLadder
	void OnTriggerEnter2D (Collider2D other)
    {
        if(other.name == "Player")                     
        {
            thePlayer.onLadder = true;
        }
    }

    // If player exits ladder zone, player is not onLadder
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            thePlayer.onLadder = false;
        }
    }
}
