using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunPickUp : MonoBehaviour {
    /* Script for activating RayGun, waiting a set amount of time, deactivating ray Gun, and destroying pickUp */
	private static float powerUpDelay = 10f;


	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			other.GetComponent<PlayerController>().StartCoroutine(Countdown(other));
			Destroy(gameObject);
		}
	}

	public static IEnumerator Countdown(Collider2D other)
	{
		other.GetComponent<PlayerController>().deathRay.SetActive(true);		
		yield return new WaitForSeconds(powerUpDelay);
		other.GetComponent<PlayerController>().deathRay.SetActive(false);				
	}
}       
	
