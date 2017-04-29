using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {
	public int damageToGive;
	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			
			HealthManager.HurtPlayer (damageToGive);
		}
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
       
        
    }
    
}
