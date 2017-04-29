using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // added for health bar

public class BossHealthBarController : MonoBehaviour {

    public static BossHealthBarController bossHealthBar;

    public GameObject  L3Boss;  // the enemy
    // Slider for boss health bar
    public Slider healthBar;
    
    private L3BossHealthManager bossController;
    //public int health;
    // Use this for initialization
    void Awake()
    {        
        bossHealthBar = this;
    }
    void Start () {
        healthBar = GetComponent<Slider>();
        bossController = L3Boss.GetComponent<L3BossHealthManager>();
        
    }
	
	// Update is called once per frame
	void Update () {
		// get health value from boss Health manager
        int health = L3Boss.GetComponent<L3BossHealthManager>().getHealth();  // get health from boss
		// update the healthbar
        healthBar.value = health;

    }
}
