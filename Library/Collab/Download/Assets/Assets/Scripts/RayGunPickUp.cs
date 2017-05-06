using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script for activating RayGun, waiting a set amount of time, deactivating ray Gun, and destroying pickUp */

public class RayGunPickUp : MonoBehaviour {
   

	private static float powerUpDelay = 10f;  // how long ray gun lasts

    // if player enters raygun pick up,  perform CoRoutine, destroy pickup
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			other.GetComponent<PlayerController>().StartCoroutine(Countdown(other));
			Destroy(gameObject);
		}
	}
    // CoRoutine to Activate Ray, wait delay time, and deactivate
	public static IEnumerator Countdown(Collider2D other)
	{
		other.GetComponent<PlayerController>().deathRay.SetActive(true);		
		yield return new WaitForSeconds(powerUpDelay);
		other.GetComponent<PlayerController>().deathRay.SetActive(false);				
	}
}       
	
