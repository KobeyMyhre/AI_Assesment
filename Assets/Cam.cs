using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

    public Transform[] flock;

    Vector3 sum;
    Vector3 midPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        sum = Vector3.zero;
		for(int i =0; i < flock.Length; i++)
        {
            sum += flock[i].position;
        }
        midPoint = sum / (flock.Length - 1);

        midPoint.y += 50;
        transform.position = midPoint;
        //transform.LookAt(midPoint);
	}
}
