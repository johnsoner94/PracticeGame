using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script to add points to player's score level when 
 * picking up a coin (metal) */

public class CoinPickup : MonoBehaviour {

    //Declare int
	public int pointsToAdd;
    
    // Coin sound
    public AudioSource audioCoin;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null)      //If anything other
            return;                                         // than a player hits the coin
                                                             // return
        ScoreManager.AddPoints(pointsToAdd);       // otherwise, add points
        audioCoin.Play();      // play audio  
        Destroy(gameObject);   // destroy coin
        
    }
}