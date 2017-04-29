using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateToBossTrigger : MonoBehaviour {

	//These may be used to stop the player from missing the animation.
	public GameObject LBorder;
	public GameObject RBorder;
	public GameObject TopBorder;
	private bool bordersWentUp;
    public PlayerController player;   // JG added to disable upshooting
	public CrateToBoss evilCrate;


	// Use this for initialization
	void Start () {
		evilCrate = FindObjectOfType<CrateToBoss> ();
        player = FindObjectOfType<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Have animation of evil crate turning into the boss 
	// triggered by player location (when it collides with a trigger)
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			Debug.Log ("Player walking through boss animation trigger");
			evilCrate.playerInArea1 = true;
			LBorder.SetActive(true);
			RBorder.SetActive(true);
			TopBorder.SetActive(true);
			bordersWentUp = true;
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
