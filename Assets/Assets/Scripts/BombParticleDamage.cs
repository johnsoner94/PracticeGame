using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombParticleDamage : MonoBehaviour {

   

    public int damageToGive;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            //Debug.Log("I see you");
            HealthManager.HurtPlayer(damageToGive);
        }
    }

}
