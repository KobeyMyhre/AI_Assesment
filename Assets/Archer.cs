using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum archerState
{
    walkTowards,
    walkAway,
    isInRange
}


public class Archer : MonoBehaviour {


    NavMeshAgent agent;
    public GameObject arrow;
    public archerState state;
    public Transform target;
	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
    void updateState()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance >= agent.stoppingDistance && distance <= agent.stoppingDistance + 5)
        {
            state = archerState.isInRange;
        }
        else if(distance < agent.stoppingDistance)
        {
            state = archerState.walkAway;
        }
        else if(distance > agent.stoppingDistance + 5)
        {
            state = archerState.walkTowards;
        }
        else
        {
            Debug.Log("I dont know what im supposed to be doing. PLease help");
        }
    }

    void shoot()
    {
        GameObject spawnedArrow = Instantiate(arrow);
        spawnedArrow.transform.position = transform.position;
        spawnedArrow.transform.rotation = transform.rotation;
        spawnedArrow.GetComponent<Rigidbody>().AddForce(spawnedArrow.transform.forward * 50, ForceMode.Impulse);
        Destroy(spawnedArrow, 3);
    }
    public float shootTimer = 1;
	// Update is called once per frame
	void Update ()
    {
		switch(state)
        {
            case archerState.isInRange:
                transform.LookAt(target);
                if(shootTimer < 0)
                {
                    shoot();
                    shootTimer = 1;
                }else { shootTimer -= Time.deltaTime; }
                
                break;
            case archerState.walkAway:
                Vector3 dir =transform.position - target.position;
                agent.destination = transform.position + (dir * 20);
                break;
            case archerState.walkTowards:
                agent.destination = target.position;
                break;
            
        }
        updateState();
	}
}
