using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowControllerRobot : SlowController {

    Colon monC;

    // Use this for initialization
    void Start()
    {
        monC = GetComponent<Colon>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void slowDown(float force)
    {
        if (!isServer)
            return;

        dansDeLaBou++;
        monC.speedBou(force);
    }

    public override void reset()
    {
        if (!isServer)
            return;

        dansDeLaBou--;

        if (dansDeLaBou < 1)
            monC.speedBou(1f);
    }

    public override void removeAllBou()
    {
        if (!isServer)
            return;

        dansDeLaBou = 0;

        monC.speedBou(1f);
    }
}
