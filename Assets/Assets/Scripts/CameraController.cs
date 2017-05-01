using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController player;   // player

	public bool isFollowing;       // to tell if following player

	public float xOffset;       // camera offset x
	public float yOffset;       // camera offset y

	private bool loweredView;        // to tell if in lowered view


	//From online suggestion
	float result;
	float t = 0.0F;
	float speed = 5.0F;
	public float distance;
	//End online suggestion


	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();  // find & set player

		isFollowing = true;               // set isFollowing true

		loweredView = false;              // set loweredView false

		transform.position = new Vector3 (player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);  // set camera position
		distance = 4.0F;                  // set distance
	}
	
	// Update is called once per frame
	void Update () {

		if (isFollowing && !loweredView) {  // If normal view...
			transform.position = new Vector3 (player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);  // camera follows player
		} 

		if (Input.GetButton("Fire3")) {     // If button pressed...
			if (transform.position.y >= player.transform.position.y - distance) {   // camera position goes to loweredView
				//From online suggestion
				t += Time.fixedDeltaTime;
				result = Mathf.Lerp (0, 100, t / speed);
//				result = Mathf.Lerp (0, 100, speed);
				//End online suggestion

				transform.position = new Vector3 (player.transform.position.x + xOffset, transform.position.y - result, transform.position.z);

			}
//			transform.position = new Vector3 (transform.position.x, transform.position.y-5, transform.position.z); // This works but is jarring.
			if (transform.position.y <= player.transform.position.y - distance) {
				loweredView = true;
//				Debug.Log ("This is t: " + t);
			}
		}

		if ((!Input.GetKey (KeyCode.DownArrow)) && (transform.position.y < (player.transform.position.y + yOffset)) && loweredView) {
//			Debug.Log ("This is t: " + t);
			if (t > 0.25f){
				t = 0.0f;
			}

			if (transform.position.y != (player.transform.position.y + yOffset)) {
				//From online suggestion
				t += Time.fixedDeltaTime;
				result = Mathf.Lerp (0, 100, t / speed);
//				result = Mathf.Lerp (0, 100, speed);
				//End online suggestion

				transform.position = new Vector3 (player.transform.position.x + xOffset, transform.position.y + result, transform.position.z);
			} 
		}

		if (transform.position.y >= (player.transform.position.y + yOffset) && loweredView) {
			transform.position = new Vector3 (player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
			t = 0;
			loweredView = false;
		}





			
	}
}
