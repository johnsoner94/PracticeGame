using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* not commented */

public class CoinPickup : MonoBehaviour {

    //Declare int
	public int pointsToAdd;
  
    public AudioSource audioCoin;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null)
            return;
        
        ScoreManager.AddPoints(pointsToAdd);
        audioCoin.Play();      // play audio
        Destroy(gameObject);
        
    }
}