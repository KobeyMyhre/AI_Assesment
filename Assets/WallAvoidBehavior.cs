using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAvoidBehavior : MonoBehaviour {


    Rigidbody rb;

    public float avoidanceStrength;
    //public float avoidanceRange;

    
	// Use this for initialization
	void Start ()
    {
        
        rb = GetComponent<Rigidbody>();
	}
    Vector3 wallDir;

    public void doWallAvoidance()
    {
        RaycastHit hit;

        
        if (Physics.Raycast(transform.position, transform.forward, out hit, rb.velocity.magnitude))
        {
            rb.AddForce(hit.normal * avoidanceStrength);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        doWallAvoidance();
	}
}
