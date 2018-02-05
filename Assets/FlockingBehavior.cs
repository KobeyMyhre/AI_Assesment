using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingBehavior : MonoBehaviour {

    Vector3 Cforce;
    Vector3 Aforce;
    Vector3 Sforce;
    Rigidbody rbz;
    public float speed;
    public float radius;
	// Use this for initialization
	void Start ()
    {
        rbz = GetComponent<Rigidbody>();
        rbz.AddForce(Random.insideUnitSphere * 5);
	}
    void flocking()
    {
        Vector3 Ctarget = Vector3.zero;
        Vector3 aDesire = Vector3.zero;
        Vector3 sSum = Vector3.zero;
        int hood = 0;
        Collider[] Hood = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider T in Hood)
        {
            if(T.tag == "Flock")
            {
                hood++;
                Rigidbody rb = T.GetComponent<Rigidbody>();
                Ctarget += T.transform.position;
                aDesire += rb.velocity;
                sSum += (transform.position - T.transform.position) / radius;// * (radius - Vector3.Distance(transform.position, T.transform.position)) / radius;

            }



        }
        Ctarget /= hood;
        aDesire /= hood;
        sSum /= hood;



        Cforce = (Ctarget - transform.position).normalized * speed - rbz.velocity;
        Sforce = sSum.normalized * speed - rbz.velocity;
        Aforce = aDesire.normalized * speed - rbz.velocity;
        rbz.AddForce((Cforce + Sforce + Aforce).normalized * speed);
    }
    // Update is called once per frame
    void Update ()
    {
        flocking();
	}
}
