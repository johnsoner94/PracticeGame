using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public GameObject platform;              // platform object

    public float moveSpeed;          // platform speed

    public Transform currentPoint;    // current point

    public Transform[] points;       // array for ponits to go to

    public int pointSelection;       // index for points

	// Use this for initialization
	void Start () {
        currentPoint = points[pointSelection];       // begins at pointSelection
	}
	
	// Update is called once per frame
	void Update () {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);      // moves platform between points

        if(platform.transform.position == currentPoint.position)     // if platform has reached a point...
        {
            pointSelection++;                                        // increase pointSelection

            if(pointSelection == points.Length)               // if last point in array...
            {
                pointSelection = 0;                          // go back to beginning of array
            }

            currentPoint = points[pointSelection];              // move to next point in array
        }
    
    }
    public void OnTriggerEnter2D(Collider2D other)          // To set an inactive platform to activate
    {
        if(other.name == "Player")
        {
            platform.SetActive(true);
        }
    }


}
