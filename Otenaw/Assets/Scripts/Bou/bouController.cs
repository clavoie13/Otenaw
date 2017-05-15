using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class bouController : NetworkBehaviour {

    [SerializeField]
    float slowPower = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (/*other.gameObject.tag == "Enemy" || */other.gameObject.tag == "Warrior" || other.gameObject.tag == "Villageois")
        {
            other.GetComponent<SlowController>().slowDown(slowPower);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (/*other.gameObject.tag == "Enemy" || */other.gameObject.tag == "Warrior" || other.gameObject.tag == "Villageois")
        {
            other.GetComponent<SlowController>().reset();
        }
    }
}
