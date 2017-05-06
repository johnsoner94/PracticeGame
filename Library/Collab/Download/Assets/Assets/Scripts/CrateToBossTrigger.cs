using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateToBossTrigger : MonoBehaviour {

	/* This script is used to put up borders around the player, 
	 * disable the player's gun, and begin playing the crate
	 * to boss animation */


	//These borders used to stop the player from missing the animation.
	public GameObject LBorder;
	public GameObject RBorder;
	public GameObject TopBorder;
	private bool bordersWentUp;
    public PlayerController player;   // JG added to disable upshooting
	public CrateToBoss evilCrate;


	// Use this for initialization
	void Start () {

		// Locate the gameobjects
		evilCrate = FindObjectOfType<CrateToBoss> ();
        player = FindObjectOfType<PlayerController>();
	}


	// Have animation of evil crate turning into the boss 
	// triggered by player location (when it collides with a trigger)
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {

			//Activate the CrateToBoss boolean, playerInArea1
			evilCrate.playerInArea1 = true;

			//Put up borders
			LBorder.SetActive(true);
			RBorder.SetActive(true);
			TopBorder.SetActive(true);
			bordersWentUp = true;

			//Disable player's ability to shoot up
            player.upShootDisabled = true;
		}

		//If the borders have gone up, destroy the trigger so the borders
		//cannot be put up again.
		if (bordersWentUp == true) {
			Destroy (gameObject);
			Debug.Log ("destroying " + gameObject);
		}
	}

}
