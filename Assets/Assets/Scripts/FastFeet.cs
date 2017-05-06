using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFeet : MonoBehaviour {
    /* Script for speed pick up, begins speedMode, waits amount of time, then ends speedMode, also destroys pick up */
    public static float timeOut = 15f;      // time of delay


    public void OnTriggerEnter2D(Collider2D other)        // If other is player, start CoRoutine & destroy pickup
    {
        if (other.name == "Player")
        {
            other.GetComponent<PlayerController>().StartCoroutine(Countdown(other));

            Destroy(gameObject);
        }
    }
    // Sets speedMode active, countsDown, then sets speedMode inactive
    public static IEnumerator Countdown(Collider2D other)
    {
        other.GetComponent<PlayerController>().speedMode = true;
        yield return new WaitForSeconds(timeOut);
        other.GetComponent<PlayerController>().speedMode = false;
    }    

}
