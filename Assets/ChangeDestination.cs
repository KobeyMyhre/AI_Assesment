using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ChangeDestination : MonoBehaviour {


    public GameObject newGoal;
    // Use this for initialization

    private void OnTriggerEnter(Collider other)
    {
        AgentPather attempt = other.GetComponent<AgentPather>();
        if(attempt != null)
        {
            //attempt.target = newGoal;
        }
    }

}
