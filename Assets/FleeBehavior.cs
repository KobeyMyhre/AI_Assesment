using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehavior : MonoBehaviour {

    //Rigidbody rb;

    Vector3 desiredVelocity;

    public float speed;
    public Transform target;

    // Use this for initialization
    void Start()
    {
      //  rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //desiredVelocity = (speed * (target.position - transform.position).normalized) * -1;

        //rb.AddForce(desiredVelocity - rb.velocity);
    }

    public Vector3 returnFleeVector()
    {
      return  (target.position - transform.position) * -1 + transform.position;
    }

}
