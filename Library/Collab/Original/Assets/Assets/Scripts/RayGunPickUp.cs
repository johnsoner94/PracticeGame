using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunPickUp : MonoBehaviour {
	private static float powerUpDelay = 10f;


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

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
		if (other.GetComponent<PlayerController>().deathRay.activeSelf)
		{
			Debug.Log("RayGun is ON");
		}
		yield return new WaitForSeconds(powerUpDelay);
		other.GetComponent<PlayerController>().deathRay.SetActive(false);
		
			Debug.Log("rayGun is OFF");
		
	}
}       
	
