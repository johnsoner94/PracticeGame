using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This script creates the player health system.
 * It controls how much health the player has, removes health,
 * and gives health.  It also contols the HealthBar Slider.*/

public class HealthManager : MonoBehaviour {

	public static HealthManager healthManager;	// sets the current healthManager

	public static int playerHealth;				// current health

	public int maxPlayerHealth;					// max health

	public Slider healthBar;					// health bar

	private LevelManager levelManager;			// current levelManager

	public bool isDead;							// is player dead?

	private LifeManager lifeSystem;				// lifeManager handles the life system.

	void Awake() {
		healthManager = this;					// Sets healthManager
	}

	// Use this for initialization
	void Start () {
		healthBar = GetComponent<Slider>();								// sets health bar

		playerHealth = maxPlayerHealth;									// sets health to max

		levelManager = FindObjectOfType<LevelManager> ();				// sets levelmanager

		lifeSystem = FindObjectOfType<LifeManager> ();					// sets lifeSystem

		playerHealth = PlayerPrefs.GetInt ("health", maxPlayerHealth);	// gets current health 

		isDead = false;													// not dead
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) {								// if player is out of health
			
			playerHealth = 0;
			levelManager.RespawnPlayer ();								// respawn player
			lifeSystem.TakeLife ();										// adjust lifeSystem
			isDead = true;												// is dead

		}
        // makes it so player health cannot go greater than max health
        if (playerHealth > maxPlayerHealth)    
            playerHealth = maxPlayerHealth;

		
		healthBar.value = playerHealth;									// adjust health bar
	}
    // removes health from player health
	public static void HurtPlayer(int damageToGive){
		playerHealth -= damageToGive;
	}

	//Added by Casie. This heals the player whenever they run into a firewall increase coin.
	public static void HealPlayer(int healthToGive){
		playerHealth += healthToGive;
	}
    // checks if health is full
	public static bool isHealthFull(){

		if (playerHealth >= healthManager.maxPlayerHealth) {
			return true;
		} else {
			return false;
		}
	}
    // makes player health full
	public void FullHealth(){
		playerHealth = maxPlayerHealth;
	}
    // set health when destroyed
	void OnDestroy() {
		PlayerPrefs.SetInt ("health", playerHealth);
	}
    // resets health
	void OnApplicationQuit() {
		FullHealth ();
	}
}
