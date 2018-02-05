using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BehaviorManager : MonoBehaviour, IDamageable {

    public float health;

    public void takeDamage(float damage)
    {
        health -= damage;
    }

    [HideInInspector]
    public Stack<Task> behaviors;
    [HideInInspector]
    public NavMeshAgent agent;

    public GameObject thingThatHoldsBehaviors;

    //public GameObject target1;
    //public GameObject target2;

    //public GameObject acid;

    //public GameObject walkTarget;
    //WalkTowardsBehaviour walkTowards;

	// Use this for initialization
	void Start ()
    {
       // walkTowards = GetComponent<WalkTowardsBehaviour>();
        agent = GetComponent<NavMeshAgent>();
        behaviors = new Stack<Task>();

        GoToAcidBehaviour attempt = thingThatHoldsBehaviors.GetComponent<GoToAcidBehaviour>();
        //attempt.acid = acid;
        behaviors.Push(attempt);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(behaviors.Count > 0)
        {
            behaviors.Peek().doBehaviour(this);
            behaviors.Peek().updateBehavior(this);
        }
        else
        {
            Debug.Log("I have no behaviors");
        }
	}
}
