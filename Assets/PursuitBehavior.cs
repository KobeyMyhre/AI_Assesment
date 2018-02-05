using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitBehavior : MonoBehaviour {

    Rigidbody rb;

    Vector3 desiredVelocity;
    Vector3 projectedPosition;
    public float projectedDistance;
    public float speed;
    float currentSpeed;
    public float BurstSpeed;
    public Transform target;
    Rigidbody targetRb;
    float dist;
    public float acceptableDistance;
    // Use this for initialization
    void Start()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody>();
        targetRb = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, target.position);
        if(dist > acceptableDistance)
        {
            //Pursuit Logic
            currentSpeed = speed;
            projectedPosition = target.position + (targetRb.velocity.normalized * projectedDistance);
            desiredVelocity = currentSpeed * (projectedPosition - transform.position).normalized;
            rb.AddForce(desiredVelocity - rb.velocity);
        }
        else
        {
            currentSpeed = BurstSpeed;
            desiredVelocity = currentSpeed * (target.position - transform.position).normalized;

            rb.AddForce(desiredVelocity - rb.velocity);
        }
        

        Debug.DrawLine(transform.position, projectedPosition, Color.red);
        Debug.DrawLine(transform.position, target.position, Color.blue);
        Debug.DrawLine(transform.position, desiredVelocity * 10, Color.green);
    }
}
