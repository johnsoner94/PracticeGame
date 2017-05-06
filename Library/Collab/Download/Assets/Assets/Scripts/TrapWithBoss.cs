using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapWithBoss : MonoBehaviour {

	/* This script sets several borders, the boss, and 
	 * the boss health bad as active whenever the player 
	 * collides with a game object with the Trap With Boss
	 * script. */

	public GameObject LBorder;
	public GameObject RBorder;
	private bool bordersWentUp;
    public GameObject bossHealthBar;
	public GameObject boss;

	// Use this for initialization
	void Start () {
		bordersWentUp = false; 
	}


	// Have border trigger create a left and right border when the player
	// passes the point of no return. Set the boss as active and destroy 
	// the trigger gameobject
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
            bossHealthBar.SetActive(true);
			LBorder.SetActive(true);
			RBorder.SetActive(true);
			boss.SetActive (true);
			bordersWentUp = true;
		}

		if (bordersWentUp == true) {
			Destroy (gameObject);
		}

	}
}
