using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : MonoBehaviour {

    //private PlayerController playerController;

    public static float timeOut = 15f;

     

    // Use this for initialization
    void Start()
    {
       //playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
           other.GetComponent<PlayerController>().StartCoroutine(Countdown(other));

            Destroy(gameObject);
        }
    }

    public static IEnumerator Countdown(Collider2D other) {
        other.GetComponent<PlayerController>().speedMode = true;
        if (other.GetComponent<PlayerController>().speedMode == true)
        {
            Debug.Log("speedMode is ON");
        }
        yield return new WaitForSeconds(timeOut);
        other.GetComponent<PlayerController>().speedMode = false;
        if (other.GetComponent<PlayerController>().speedMode == false)
        {
            Debug.Log("speedMode is OFF");
        }
    }
            
}
