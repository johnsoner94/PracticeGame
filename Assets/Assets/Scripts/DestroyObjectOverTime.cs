using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOverTime : MonoBehaviour {

	//This seems to only work for crumble boxes
    public float lifetime;
	public bool startDestroy;

	public GameObject deathEffect;

	float dyingTime;

	// Use this for initialization
	void Start () {

		dyingTime = lifetime;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (startDestroy) {

			dyingTime -= Time.deltaTime;

			if (dyingTime < 0) {
				Instantiate (deathEffect, transform.position, transform.rotation);
				gameObject.SetActive (false);
				dyingTime = lifetime;
			}
		}
	}
}
