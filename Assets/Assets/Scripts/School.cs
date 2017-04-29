using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class School : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Physics.IgnoreLayerCollision (9, 13, true);
		Physics2D.IgnoreLayerCollision (9, 13, true);
	}

	//Physics.IgnoreLayerCollision(13, 9, true);
	//public static void IgnoreLayerCollision(int layer13, int layer9, bool ignore);
}
