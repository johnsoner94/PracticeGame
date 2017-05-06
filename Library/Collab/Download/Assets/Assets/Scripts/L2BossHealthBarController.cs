using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // added for health bar

/* Creates Health bar that reflects the L2 Boss's health status */

public class L2BossHealthBarController : MonoBehaviour {

    public static L2BossHealthBarController bossHealthBar;

    public GameObject L2Boss;  // the enemy

    // Slider for boss health bar
    public Slider healthBar;

    private BossEnemyHealthManager bossController;
  
    // Use this for initialization
    void Awake()
    {
        bossHealthBar = this;     // set health bar
    }
    void Start()
    {
       
        healthBar = GetComponent<Slider>();             // set slider
        bossController = L2Boss.GetComponent<BossEnemyHealthManager>();  //get Boss's health

    }

    // Update is called once per frame
    void Update()
    {
        // get health value from boss Health manager
        int health = L2Boss.GetComponent<BossEnemyHealthManager>().getHealth();
		// update the healthbar
        healthBar.value = health;

    }
}
