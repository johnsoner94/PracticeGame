using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script to add lives to the life manager though a life pickup object*/

public class lifePickup : MonoBehaviour {

    private LifeManager lifeSystem;   // lifemanager

	// Use this for initialization
	void Start () {
        lifeSystem = FindObjectOfType<LifeManager>();   // set lifesystem
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")              // if player collides with life pickup...
        {
            lifeSystem.GiveLife();           // give life
            Destroy(gameObject);            // destroy pickup

        }

    }
}
