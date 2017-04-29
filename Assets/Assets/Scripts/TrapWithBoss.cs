using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapWithBoss : MonoBehaviour {

	public GameObject LBorder;
	public GameObject RBorder;
	private bool bordersWentUp;
    public GameObject bossHealthBar;
	public GameObject boss;
	// Use this for initialization
	void Start () {
		bordersWentUp = false; 

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Have border trigger create a left border when the player
	// passes the point of no return
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			Debug.Log ("Player walking through trigger");
            bossHealthBar.SetActive(true);
			LBorder.SetActive(true);
			RBorder.SetActive(true);
			boss.SetActive (true);
			bordersWentUp = true;

		}

		if (bordersWentUp == true) {
			Destroy (gameObject);
			Debug.Log ("destroying " + gameObject);
		}

	}
}
