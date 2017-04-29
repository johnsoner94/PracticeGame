using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            ladder.SetActive(true);
            block.SetActive(true);
        }
    }
}
