using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{

    

    public virtual void doBehaviour(BehaviorManager manger)
    {
        //Do civilian stuff
        Debug.Log("I am parent");
    }

    public virtual bool checkBehavior(BehaviorManager manager)
    {
        return false;
    }

    public virtual void updateBehavior(BehaviorManager manager)
    {

    }



    protected bool pathComplete(BehaviorManager manager)
    {
        if (!manager.agent.pathPending)
        {
            if (manager.agent.stoppingDistance >= manager.agent.remainingDistance)
            {
                if (!manager.agent.hasPath || manager.agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

}
