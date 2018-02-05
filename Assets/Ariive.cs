using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ariive : MonoBehaviour {

    Rigidbody rb;
    public float speed;
    public Transform target;
    public float slowingDistance;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void DoAction()
    {
        Vector3 targetOffset = target.position - transform.position;
        float dist = Vector3.Distance(transform.position, target.position);
        float rampedSpeed = speed * (targetOffset.magnitude / dist);
        float clippedSpeed = Mathf.Min(rampedSpeed, speed);
        Vector3 desiredVelocity = (clippedSpeed / targetOffset.magnitude) * targetOffset;
        rb.velocity = desiredVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        DoAction();
        //rb.AddForce(desiredVelocity - rb.velocity);
    }
}
