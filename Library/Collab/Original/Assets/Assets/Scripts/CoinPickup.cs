using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    //Declare int
	public int pointsToAdd;


	//public GameObject impactEffect;

    //Audio components for boss
  
    public AudioSource audioCoin;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null)
            return;
        
        ScoreManager.AddPoints(pointsToAdd);
        audioCoin.Play();      // play audio
        //Instantiate (impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}