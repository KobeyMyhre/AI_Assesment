using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursuit : MonoBehaviour {

    public Transform leader;
    public float speed;
    Rigidbody rb;
    Vector3 leaderOffset;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        leaderOffset = transform.position - leader.transform.position;
    }

    void ArriveAtPoints(Vector3 targetPos)
    {
        Vector3 targetOnOurY = targetPos;
        targetOnOurY.y = transform.position.y;
        Vector3 targetOffset = targetOnOurY - transform.position;
        float dist = Vector3.Distance(transform.position, targetPos);
        float rampedSpeed = speed * (targetOffset.magnitude / dist);
        float clippedSpeed = Mathf.Min(rampedSpeed, speed);
        if(targetOffset.magnitude != 0)
        {
            Vector3 desiredVelocity = ((clippedSpeed / targetOffset.magnitude) * targetOffset);
            rb.velocity = desiredVelocity;
        }
        
    }

    // Update is called once per frame
    void Update ()
    {
        
        ArriveAtPoints(leader.transform.position + leaderOffset);
       // transform.position = leader.transform.position + leaderOffset;
        Debug.DrawLine(transform.position, transform.position + leaderOffset, Color.magenta);
	}
}
