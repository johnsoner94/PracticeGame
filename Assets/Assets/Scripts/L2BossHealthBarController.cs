using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // added for health bar


public class L2BossHealthBarController : MonoBehaviour {

    public static L2BossHealthBarController bossHealthBar;

    public GameObject L2Boss;  // the enemy
    // Slider for boss health bar
    public Slider healthBar;

    private BossEnemyHealthManager bossController;
    //public int health;
    // Use this for initialization
    void Awake()
    {
        bossHealthBar = this;
    }
    void Start()
    {
       
        healthBar = GetComponent<Slider>();
        bossController = L2Boss.GetComponent<BossEnemyHealthManager>();

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
