using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerController player;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public int pointPenaltyOnDeath;

	public float respawnDelay;

	private CameraController camera;

	private float gravityStore;

	public HealthManager healthManager;


	//audio
	AudioSource currentAudio;
	private AudioPlay nextLevels;
	public AudioSource playingAudio;
	bool hitChk4;
	//audio

	//respawn crumble boxes
	GameObject[] crumbleBoxes;
	//respawn crumble boxes

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		camera = FindObjectOfType<CameraController> ();

		healthManager = FindObjectOfType<HealthManager> ();


		// audio
		nextLevels = FindObjectOfType<AudioPlay> ();
		currentAudio = gameObject.GetComponent<AudioSource> ();
		hitChk4 = false;
		//audio

		//respawn crumble boxes
		crumbleBoxes = GameObject.FindGameObjectsWithTag("CrumbleBox");
		//respawn crumble boxes

		/*if (crumbleBoxes.Length > 0) {
			
			Debug.Log ("we had crumble boxes. type: " + crumbleBoxes [0].GetType ().ToString ());
			Debug.Log ("we had crumble boxes. type: " + crumbleBoxes [0].gameObject.GetComponent<SpriteRenderer>().sprite.name);
			for (var i = 0; i < crumbleBoxes.Length; i++) {
				Debug.Log ("i:" + i + " name:" + crumbleBoxes[i].name + " (" + crumbleBoxes [i].transform.position.x + ", " + crumbleBoxes [i].transform.position.y + ")");
			}
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		if (currentCheckpoint.name == "Spikes Checkpoint") {
			camera.distance = 5.0F;
		} else if(currentCheckpoint.name == "Checkpoint (1) L3" || currentCheckpoint.name == "Checkpoint (2) L3") {
			camera.distance = 1.0F;
		} else {
			camera.distance = 4.0F;
		}

		if (currentCheckpoint.tag == "BossTrigger" && !hitChk4) {
//			Debug.Log ("Got here! Gonna play the bossL3 music.");
			hitChk4 = true;
			startBossL3Music ();

		}
		
		
	}

	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo()
	{
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer> ().enabled = false;
		camera.isFollowing = false;
		//gravityStore = player.GetComponent<Rigidbody2D> ().gravityScale;
		//player.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		//player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (respawnDelay);
		//player.GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		player.GetComponent<Renderer> ().enabled = true;
        player.rapidFire = false; 
		player.knockbackCount = 0f;
		healthManager.FullHealth ();
		healthManager.isDead = false;
		camera.isFollowing = true;
		player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);

		if (crumbleBoxes.Length > 0) {
//			Debug.Log ("we had crumble boxes.");
			for (var i = 0; i < crumbleBoxes.Length; i++) {
//				Debug.Log ("i:" + i + " name:" + crumbleBoxes[i].name + " x:" + crumbleBoxes [i].transform.position.x);
				crumbleBoxes[i].SetActive (true);
				crumbleBoxes [i].GetComponent<DestroyObjectOverTime> ().startDestroy = false;
			}
		} /*else {
			Debug.Log ("NO crumble boxes.");
		}*/
	}
	void startBossL3Music() {
		// audio
		playingAudio = nextLevels.audio;
//		Debug.Log ("The audio that's currently playing is: " + playingAudio.name);
//		Debug.Log ("The audio playing?: " + playingAudio.isPlaying);
		if (playingAudio.isPlaying && playingAudio.clip.name == "ThemeMusicL3") {
			playingAudio.clip = currentAudio.clip;
			playingAudio.Play ();
		}
		//audio
	}
		
}
