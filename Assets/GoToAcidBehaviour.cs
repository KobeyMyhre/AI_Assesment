using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToAcidBehaviour : Task {

    public GameObject acid;

    public override void doBehaviour(BehaviorManager manger)
    {
        manger.agent.destination = acid.transform.position;
    }

    public override bool checkBehavior(BehaviorManager manager)
    {
       if(manager.health < 25)
        {
            return true;
        }
        return false;
    }

    public override void updateBehavior(BehaviorManager manager)
    {
        if(checkBehavior(manager))
        {
            GetHealthPack attempt = manager.thingThatHoldsBehaviors.GetComponent<GetHealthPack>();
            //attempt.healthPack = GameObject.Find("HealthPack");
            manager.behaviors.Push(attempt);
            //Push get healthPack
        }
    }
}
