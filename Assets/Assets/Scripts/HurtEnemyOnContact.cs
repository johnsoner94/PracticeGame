//NOTE!!!! IT SEEMS AS IF THIS CODE IS NOT USED. IF SO, THIS SHOULD BE DELETED.
//NOTE!!!! IT SEEMS AS IF THIS CODE IS NOT USED. IF SO, THIS SHOULD BE DELETED.
//NOTE!!!! IT SEEMS AS IF THIS CODE IS NOT USED. IF SO, THIS SHOULD BE DELETED.
//NOTE!!!! IT SEEMS AS IF THIS CODE IS NOT USED. IF SO, THIS SHOULD BE DELETED.
//NOTE!!!! IT SEEMS AS IF THIS CODE IS NOT USED. IF SO, THIS SHOULD BE DELETED.
//NOTE!!!! IT SEEMS AS IF THIS CODE IS NOT USED. IF SO, THIS SHOULD BE DELETED.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour {

    public int damageToGive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		//Debug.Log("Something is being hit!");
		//Debug.Log ("The " + gameObject + " is colliding with: " + other.name);
		if (other.tag == "Boss") {
			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
		}

		if (other.tag == "Enemy") {
			Debug.Log ("The player is colliding with: " + other.tag);
			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
			//Debug.Log ("ENEMY IS HIT");
		}

		
	}


}
