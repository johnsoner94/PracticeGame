using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script to make ladder appear when triggering a collider*/

public class LadderAppear : MonoBehaviour
{
    public GameObject ladder;
    public GameObject block;
    private bool ladderActive;
    // Use this for initialization
    void Start()
    {
        ladderActive = false;
    }

   
    void OnTriggerEnter2D(Collider2D other)  // if other is player...
    {
        if (other.name == "Player")
        {
            ladder.SetActive(true);      // set ladder active
            block.SetActive(true);       // set invisible blocks active
        }
    }
}
