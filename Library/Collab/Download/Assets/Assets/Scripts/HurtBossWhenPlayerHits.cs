using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBossWhenPlayerHits : MonoBehaviour {

	/* This script is used to call the boss's giveDamage function 
	 * whenever the gameobject collides with the player */

	public int damageToGive;

	public L3BossHealthManager boss;

	//When the player hits the game object, damage the boss. 
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "Player")	{
			boss.giveDamage(damageToGive);
		}
	}
}