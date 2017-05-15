using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillAttractZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Warrior")
        {
            transform.parent.GetComponent<WillController>().startMoving();
        }
    }
}
