using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlowControllerWarrior : SlowController {

    WarriorMovement monWM;



	// Use this for initialization
	void Start () {
        monWM = GetComponent<WarriorMovement>();	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public override void slowDown(float force)
    {
        if (!hasAuthority)
            return;

        dansDeLaBou++;
        monWM.CmdChangerBou(force);
    }

    public override void reset()
    {
        if (!hasAuthority)
            return;

        dansDeLaBou--;

        if (dansDeLaBou < 1)
            monWM.CmdChangerBou(1f);
    }
}
