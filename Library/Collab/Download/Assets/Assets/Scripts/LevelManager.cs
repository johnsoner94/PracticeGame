using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	/* This script handles player respawns. The player is deactivated
	 * after death until it respawns to the most recent checkpoint.
	 * At which point, the player is reactivated. This script also 
	 * handles some audio aspects, such as the level 3 boss music,
	 * becaase it has script involving the current checkpoint. It 
	 * also controls the respawning of crumble boxes. */ 


	//Locate current checkpoint and particle effects
	public GameObject currentCheckpoint;
	public GameObject deathParticle;
	public GameObject respawnParticle;

	//respawn crumble boxes
	GameObject[] crumbleBoxes;

	//Declare ints and floats
	public int pointPenaltyOnDeath;
	public float respawnDelay;
	private float gravityStore;

	//Locate specific gameobjects with 
	//Controller or manager scripts.
	private CameraController camera;
	public HealthManager healthManager;
	private PlayerController player;


	//audio
	AudioSource currentAudio;
	private AudioPlay nextLevels;
	public AudioSource playingAudio;
	bool hitChk4;


	// Use this for initialization
	void Start () {

		//Locate the player, camera, and health manager. 
		player = FindObjectOfType<PlayerController> ();
		camera = FindObjectOfType<CameraController> ();
		healthManager = FindObjectOfType<HealthManager> ();

		// audio
		nextLevels = FindObjectOfType<AudioPlay> ();
		currentAudio = gameObject.GetComponent<AudioSource> ();
		hitChk4 = false;


		//Respawn crumble boxes at the beginning
		crumbleBoxes = GameObject.FindGameObjectsWithTag("CrumbleBox");
	}
	
	// Update is called once per frame
	void Update () {

		// Alter the view of the camera depending on the various parts of the game.
		// (Some for some portions of the game, we want the player to be able 
		// to view more or less below them.)
		if (currentCheckpoint.name == "Spikes Checkpoint") {
			camera.distance = 5.0F;
		} else if(currentCheckpoint.name == "Checkpoint (1) L3" || currentCheckpoint.name == "Checkpoint (2) L3") {
			camera.distance = 1.0F;
		} else {
			camera.distance = 4.0F;
		}

		//Trigger the boss music in Level 3 to start playing
		if (currentCheckpoint.tag == "BossTrigger" && !hitChk4) {
			hitChk4 = true;
			startBossL3Music ();
		}
		
		
	}

	public void RespawnPlayer()
	{
		//Begin the RespawnPlayer coroutine - this is done so we
		//can use built in commands, such as WaitForSeconds, which
		//can only be done in Coroutines. 
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo()
	{
		// Disable the player and play the death effect.
		// This stops the player from being seen and stops
		// the camera from following the player after death.
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer> ().enabled = false;
		camera.isFollowing = false;

		//Subtract points because the player died, wait before respawning
		//at a checkpoint.
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		yield return new WaitForSeconds (respawnDelay);

		// Move the player's position to the most recent check point and
		// reactivate the player.
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		player.GetComponent<Renderer> ().enabled = true;
       
		// Reset the player's health, knockbackcount, and
		// rapidFire powerup boolean.
		player.rapidFire = false; 
		player.knockbackCount = 0f;
		healthManager.FullHealth ();
		healthManager.isDead = false;

		// Put the camera back on the player, play respawn effect.
		camera.isFollowing = true;
		player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);

		// Reset the crumble boxes.
		// This is done in case the player died on the crumble boxes
		// and respawned at a checkpoint behind them. 
		if (crumbleBoxes.Length > 0) {
			for (var i = 0; i < crumbleBoxes.Length; i++) {
				crumbleBoxes[i].SetActive (true);
				crumbleBoxes [i].GetComponent<DestroyObjectOverTime> ().startDestroy = false;
			}
		} 
	}

	//Function to play the Level 3 boss music 
	void startBossL3Music() {
		playingAudio = nextLevels.audio;
		if (playingAudio.isPlaying && playingAudio.clip.name == "ThemeMusicL3") {
			playingAudio.clip = currentAudio.clip;
			playingAudio.Play ();
		}

	}
		
}
