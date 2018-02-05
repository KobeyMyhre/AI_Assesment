using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

    public Transform follow1;
    public Transform follow2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 midPoint = (follow1.position + follow2.position) / 2;
        float dist = Vector3.Distance(follow1.position, follow2.position);
        transform.position = midPoint + (Vector3.up * (dist + 5));
        transform.LookAt(midPoint);
	}
}
