using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAvoid : MonoBehaviour {

    Rigidbody rb;

    //public float speed;
    //public Transform target;
    //Vector3 desiredVelocity;

    public bool foundObstacle;
    public float avoidanceRadius;
    public float avoidanceStrength;
    Collider hitObstacle;
    Vector3 wallDir;
    // Use this for initialization
    void Start()
    {
        foundObstacle = false;
        rb = GetComponent<Rigidbody>();
    }
    
    
    public void doWallAvoidance()
    {
        if(!foundObstacle)
        {
            //desiredVelocity = speed * (target.position - transform.position).normalized;

           // rb.AddForce(desiredVelocity - rb.velocity);
            float maxDistance = Mathf.Infinity;
            Collider[] neighbours = Physics.OverlapSphere(transform.position, avoidanceRadius);
            foreach (Collider n in neighbours)
            {
                if (n.tag == "Obstacle")
                {
                    float distance = Vector3.Distance(transform.position, n.transform.position);
                    if (maxDistance > distance)
                    {
                        maxDistance = distance;
                        foundObstacle = true;
                        hitObstacle = n;
                        wallDir = (n.transform.position - transform.position).normalized;
                    }
                }

            }
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, wallDir, out hit, rb.velocity.magnitude))
            {
                Vector3 perp = Vector3.Cross(transform.position, hit.normal);
                rb.AddForce(perp.normalized * avoidanceStrength);
                
            }
            else
            {
                //foundObstacle = false;
            }
            Debug.DrawLine(transform.position, transform.position + (hit.normal * 5));
        }
        Debug.DrawLine(transform.position, transform.position + (wallDir * 5), Color.blue);
       

    }


    // Update is called once per frame
    void Update () {
        doWallAvoidance();
	}
}
