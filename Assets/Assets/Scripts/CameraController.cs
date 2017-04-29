using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController player;

	public bool isFollowing;

	public float xOffset;
	public float yOffset;

	private bool loweredView;


	//From online suggestion
	float result;
	float t = 0.0F;
	float speed = 5.0F;
	public float distance;
	//End online suggestion


	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();

		isFollowing = true;

		loweredView = false;

		transform.position = new Vector3 (player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
		distance = 4.0F;
	}
	
	// Update is called once per frame
	void Update () {

		if (isFollowing && !loweredView) {
			transform.position = new Vector3 (player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
		} 

		if (Input.GetButton("Fire3")) {
			if (transform.position.y >= player.transform.position.y - distance) {
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
