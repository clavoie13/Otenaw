using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class SlowController : NetworkBehaviour {

    protected int dansDeLaBou = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void slowDown(float force)
    {

    }

    public virtual void reset()
    {

    }

    public virtual void removeAllBou()
    {

    }
}
