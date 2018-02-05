using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum minerState
{
    pickUpGold,
    BringGoldToBin,
    GoToWork,
    GoToBed,
    SolveMathProblems
}



public class Miner : MonoBehaviour {


    NavMeshAgent agent;
    public minerState state;
    public Transform gold;
    public Transform goldContainer;
    public Transform workLocation;
    public Transform homeLocation;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}


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

    // Update is called once per frame
    void Update ()
    {
		switch(state)
        {
            case minerState.pickUpGold:
                agent.destination = gold.position;
                break;
            case minerState.BringGoldToBin:
                agent.destination = goldContainer.position;
                break;
            case minerState.GoToBed:
                agent.destination = homeLocation.position;
                break;
            case minerState.GoToWork:
                agent.destination = workLocation.position;
                break;
            case minerState.SolveMathProblems:
                mathProblemsSolved++;
                break;
        }
        updateState();
	}
    public int mathProblemsSolved;
    void updateState()
    {
        switch(state)
        {
            case minerState.pickUpGold:
               
                if (pathComplete())
                {
                    gold.transform.position = transform.position + Vector3.up;
                    gold.transform.parent = transform;
                    state = minerState.BringGoldToBin;
                }
                break;
            case minerState.BringGoldToBin:
                
                if (pathComplete())
                {
                    gold.transform.position = goldContainer.position + Vector3.up;
                    gold.transform.parent = goldContainer.transform;
                    state = minerState.SolveMathProblems;
                }
                break;
            case minerState.GoToBed:
               if(pathComplete())
                {
                    state = minerState.GoToWork;
                }
                break;
            case minerState.GoToWork:
                if(pathComplete())
                {
                    state = minerState.pickUpGold;
                }
                break;
            case minerState.SolveMathProblems:
                if(mathProblemsSolved > 400)
                {
                    state = minerState.GoToBed;
                }
                break;
        }
    }
}
