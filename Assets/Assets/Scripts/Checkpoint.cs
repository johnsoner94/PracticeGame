﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public LevelManager levelManager;
	public ShowGUI instructions;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			levelManager.currentCheckpoint = gameObject;
			Debug.Log ("Activated Checkpoint: " + transform.position + " Checkpoint name: " + transform.name);
			//Debug.Log ("Current instructions: " + instructions);
		}
	}
}