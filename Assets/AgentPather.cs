using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentPather : MonoBehaviour {

    NavMeshAgent agent;
    public GameObject[] target;
    public int patrolIndex;
    public bool editorStop;


    public GameObject bunnyTarget;
    bool hasBunny;
	// Use this for initialization
	void Start ()
    {
        hasBunny = false;
        agent = GetComponent<NavMeshAgent>();
        patrolIndex = 0;
        target = GameObject.FindGameObjectsWithTag("Point");
        
        shouldWalk = true;

        agent.destination = target[patrolIndex].transform.position;
    }

    bool shouldWalk;

    bool pathComplete()
    {
        if (!agent.pathPending)
        {
            if (agent.stoppingDistance >= agent.remainingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }

        }
        return false;
    }


    private void OnTriggerEnter(Collider other)
    {
        Bunny attempt = other.GetComponent<Bunny>();
        if(attempt != null && hasBunny == false)
        {
            hasBunny = true;
            bunnyTarget = other.gameObject;
        }
    }


    // Update is called once per frame
    void Update ()
    {
        
        if(pathComplete() && hasBunny == false)
        {
            patrolIndex++;
            if(patrolIndex >= target.Length)
            {
                patrolIndex = 0;
            }
            agent.destination = target[patrolIndex].transform.position;
        }
        if(hasBunny == true)
        {
            agent.destination = bunnyTarget.transform.position;
        }



        if (editorStop)
        {
            editorStop = false;
            agent.isStopped = !shouldWalk;
            shouldWalk = agent.isStopped;
        }
        
        
	}
}
