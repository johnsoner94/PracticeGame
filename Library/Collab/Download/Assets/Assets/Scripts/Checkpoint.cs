using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script sets checkpoints for respawning */

public class Checkpoint : MonoBehaviour {

	public LevelManager levelManager;						// Current LevelManager
	public ShowGUI instructions;							// Show the assigned GUI 

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();	// Get LevelManager
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {						// If player hits checkpoint
			levelManager.currentCheckpoint = gameObject;	// Make this current checkpoint
			
		}
	}
}
