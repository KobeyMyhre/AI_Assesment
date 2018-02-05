using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : MonoBehaviour {

    public float speed;
    public float radius;
    public float jitter;
    public float distance;
    public Vector3 target;

    

    public Vector3 returnWanderPoints()
    {
        target = Vector3.zero;
        target = Random.insideUnitCircle.normalized * radius;
        target = (Vector2)target + Random.insideUnitCircle * jitter;

        target.z = target.y;
        target += transform.position;
        target += transform.forward * distance;

        target.y = transform.position.y;
        //Vector3 dir = (target - transform.position).normalized;
        //Vector3 desiredVelocity = dir * speed;
        return target;
    }

	
}
