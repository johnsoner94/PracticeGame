using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRay : MonoBehaviour {
	//private PlayerController playerController;



	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			

			//Instantiate (collectedEffect, transform.position, transform.rotation);
			//Remove coin from screen
			Destroy (gameObject);
		}
	}
}
