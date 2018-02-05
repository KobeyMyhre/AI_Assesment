using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterposeBehavior : MonoBehaviour {

    public Transform thing1;
    public Transform thing2;
    public float speed;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
    void ArriveAtPoints(Vector3 targetPos)
    {
        Vector3 targetOnOurY = targetPos;
        targetOnOurY.y = transform.position.y;
        Vector3 targetOffset = targetOnOurY - transform.position;
        float dist = Vector3.Distance(transform.position, targetPos);
        float rampedSpeed = speed * (targetOffset.magnitude / dist);
        float clippedSpeed = Mathf.Min(rampedSpeed, speed);
        Vector3 desiredVelocity = (clippedSpeed / targetOffset.magnitude) * targetOffset;
        rb.velocity = desiredVelocity;
    }
    
	void Update ()
    {
        Vector3 midPoint = thing1.position - thing2.position;
        float midPointTime = Vector3.Distance(midPoint, transform.position) / speed;

        Vector3 aPos = thing1.position + thing1.GetComponent<Rigidbody>().velocity * midPointTime;
        Vector3 bPos = thing2.position + thing2.GetComponent<Rigidbody>().velocity * midPointTime;

        Vector3 desiredMidPoint = (aPos + bPos) / 2;

        ArriveAtPoints(desiredMidPoint);
        Debug.DrawLine(transform.position, transform.position + desiredMidPoint, Color.green);
	}
}
