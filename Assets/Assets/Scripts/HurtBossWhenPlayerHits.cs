using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBossWhenPlayerHits : MonoBehaviour {

	public GameObject impactEffect;

	public int damageToGive;

	public L3BossHealthManager boss;
	public PlayerController player;

	// Use this for initialization
	void Start () {
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log ("SOMETHING HIT GAME OBJECT");

		if(other.transform.tag == "Player")
		{
			Debug.Log ("PLAYER HIT BOSS!");
			boss.giveDamage(damageToGive);

		}
			
	}
}