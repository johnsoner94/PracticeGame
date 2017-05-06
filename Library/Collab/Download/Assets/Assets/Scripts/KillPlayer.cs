using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script to kill player upon contact */

public class KillPlayer : MonoBehaviour {

	public LevelManager levelManager;  

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>(); //set levelManager
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {             // If player enters...
			levelManager.RespawnPlayer();     // respawn player
		}
	}
}
