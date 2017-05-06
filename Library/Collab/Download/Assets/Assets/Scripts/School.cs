using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class School : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		Physics2D.IgnoreLayerCollision (9, 13, true);
	}

}
