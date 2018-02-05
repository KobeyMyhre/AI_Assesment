using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPuddle : MonoBehaviour {

    public float damage;
    void OnTriggerStay(Collider other)
    {
        var attempt = other.GetComponent<IDamageable>();
        if(attempt != null)
        {
            attempt.takeDamage(damage);
        }
    }

}
