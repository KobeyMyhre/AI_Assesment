using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EpicPlayerController : MonoBehaviour {


    NavMeshAgent agent;
    float horizontal;
    float vertical;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        agent.destination = transform.position + (new Vector3(horizontal, 0, vertical) );
	}
}
