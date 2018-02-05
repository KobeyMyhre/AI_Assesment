using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTowardsBehaviour : Task
{

    public GameObject target;
    //public GameObject target2;
    public bool walkToSecondTarget;
    public override void doBehaviour(BehaviorManager manger)
    {
        //Logic
        
        manger.agent.destination = target.transform.position;
        
       
    }

    public override bool checkBehavior(BehaviorManager manager)
    {
        //Condition
        return pathComplete(manager);
    }

    public override void updateBehavior(BehaviorManager manager)
    {
        if(checkBehavior(manager))
        {
            

            manager.behaviors.Pop();
            WalkTowardsBehaviour newWalk = manager.thingThatHoldsBehaviors.GetComponent<WalkTowardsBehaviour>();
            if(walkToSecondTarget)
            {
                //newWalk.target = manager.target2;
            }
            else
            {
               // newWalk.target = manager.target1;
            }
            walkToSecondTarget = !walkToSecondTarget;
            manager.behaviors.Push(newWalk);
        }
    }

}
