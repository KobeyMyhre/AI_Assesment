using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum joggState
{
    jogging,
    resting,
}

public class JoggingState : MonoBehaviour {

    NavMeshAgent agent;
    WanderBehavior wander;

    public float maxEnergy;
    public float currentEnergy;
    public float energyDrain;
    public joggState myState;
    public GameObject bed;
	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        wander = GetComponent<WanderBehavior>();
        currentEnergy = maxEnergy;
	}

    void switchStates()
    {
        if(myState == joggState.jogging)
        {
            currentEnergy -= energyDrain * Time.deltaTime;
            if(currentEnergy <= 0)
            {
                agent.destination = bed.transform.position;
                myState = joggState.resting;
            }
        }
        if(myState == joggState.resting)
        {
            

            if(currentEnergy >= maxEnergy)
            {
                myState = joggState.jogging;
            }

            
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		switch(myState)
        {
            case joggState.resting:
                float distance = Vector3.Distance(transform.position, bed.transform.position);

                if (distance < 1)
                {
                    currentEnergy += energyDrain * Time.deltaTime;
                }
                break;
            case joggState.jogging:
                agent.destination = wander.returnWanderPoints();
                break;
        }
        switchStates();
	}
}
