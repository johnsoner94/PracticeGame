using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script so player walks in front of the school  
public class School : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
		Physics2D.IgnoreLayerCollision (9, 13, true);
	}

}
