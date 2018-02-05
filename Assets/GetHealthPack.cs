using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHealthPack : Task
{
    public GameObject healthPack;
    public override void doBehaviour(BehaviorManager manger)
    {
       
            
            manger.agent.destination = healthPack.transform.position;
        
   

        
    }
    public override bool checkBehavior(BehaviorManager manager)
    {
        if(pathComplete(manager))
        {
            manager.health += 50;
            return true;
        }

        return false;
    }

    public override void updateBehavior(BehaviorManager manager)
    {
       if(checkBehavior(manager))
        {
            manager.behaviors.Pop();
        }
    }
}
