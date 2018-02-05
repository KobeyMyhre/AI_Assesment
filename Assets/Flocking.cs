using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour {

    Vector3 Cforce;
    Vector3 Aforce;
    Vector3 Sforce;
    Rigidbody rb;
    public float speed;
    public float radius;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Random.insideUnitSphere * 5);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 Ctarget = Vector3.zero;
        Vector3 aDesire = Vector3.zero;
        Vector3 sSum = Vector3.zero;

        int hoodSize = 0;
        Collider[] hood = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider guyInHood in hood)
        {
            var Flocker = guyInHood.GetComponent<Flocking>();
            if(Flocker != null)
            {
                hoodSize++;
                Rigidbody guyRb = guyInHood.GetComponent<Rigidbody>();

                Ctarget += Flocker.transform.position;
                aDesire += guyRb.velocity;
                sSum    += (transform.position - guyInHood.transform.position) / radius;

            }
        }

        Ctarget /= hoodSize;
        aDesire /= hoodSize;
        sSum /= hoodSize;

        Cforce = (Ctarget - transform.position).normalized * speed - rb.velocity;
        Aforce = aDesire.normalized * speed - rb.velocity;
        Sforce = sSum.normalized * speed - rb.velocity;

        rb.AddForce((Cforce + Aforce + Sforce).normalized * speed);




	}
}
