using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtingBombParticleController : MonoBehaviour {
    //public GameObject player;
    public int damageToGive;
	void OnParticleCollision(GameObject other)
    {
        if(other.name == "Player")
        {
            HealthManager.HurtPlayer(damageToGive);
        }

    }
}
