using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    private PlayerController playerController;
    public float powerUpDelay;
     

    // Use this for initialization
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerController.rapidFire = false;
            playerController.speedMode = true;
            if (playerController.speedMode == true)
            {
                Debug.Log("SpeedMode is ON");
            }
            Destroy(gameObject);
            

           
        }
    }

   
}
