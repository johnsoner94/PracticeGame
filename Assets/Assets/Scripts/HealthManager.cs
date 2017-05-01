using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public static HealthManager healthManager;

	public static int playerHealth;

	public int maxPlayerHealth;

	//Text text;

	public Slider healthBar;

	private LevelManager levelManager;

	public bool isDead;

	private LifeManager lifeSystem;

	void Awake() {
		healthManager = this;
	}

	// Use this for initialization
	void Start () {
		//text = GetComponent<Text> ();
		healthBar = GetComponent<Slider>();

		playerHealth = maxPlayerHealth;

		levelManager = FindObjectOfType<LevelManager> ();

		lifeSystem = FindObjectOfType<LifeManager> ();

		playerHealth = PlayerPrefs.GetInt ("health", maxPlayerHealth);

		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) {
			
			playerHealth = 0;
			levelManager.RespawnPlayer ();
			lifeSystem.TakeLife ();
			isDead = true;

		}

        if (playerHealth > maxPlayerHealth)
            playerHealth = maxPlayerHealth;

		//text.text = "" + playerHealth;
		healthBar.value = playerHealth;
	}

	public static void HurtPlayer(int damageToGive){
		playerHealth -= damageToGive;
	}

	//Added by Casie. This heals the player whenever they run into a firewall increase coin.
	public static void HealPlayer(int healthToGive){
		playerHealth += healthToGive;
	}

	public static bool isHealthFull(){

		if (playerHealth >= healthManager.maxPlayerHealth) {
			return true;
		} else {
			return false;
		}
	}

	public void FullHealth(){
		playerHealth = maxPlayerHealth;
	}

	void OnDestroy() {
		PlayerPrefs.SetInt ("health", playerHealth);
	}

	void OnApplicationQuit() {
		FullHealth ();
	}
}
