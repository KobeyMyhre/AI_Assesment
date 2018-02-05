using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Bunny : MonoBehaviour {


    NavMeshAgent agent;
    WanderBehavior wander;
	// Use this for initialization
	void Start ()
    {
        wander = GetComponent<WanderBehavior>();
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        agent.destination = wander.returnWanderPoints();
	}
}
