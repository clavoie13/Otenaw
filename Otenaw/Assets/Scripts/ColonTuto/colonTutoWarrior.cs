using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colonTutoWarrior : Colon {

    private chasserWarriorTuto CVW;

    // Use this for initialization
    void Start () {

        if (isServer)
            GetComponent<Rigidbody>().drag = 100;

        CVW = GetComponent<chasserWarriorTuto>();
        speedCurrent = speed;

        CVW.initialize();
        CVW.changeSpeed(speedCurrent);
    }


    public override void disableMovement()
    {
        CVW.stopMovement();
    }

    public override void enableMovement()
    {
        CVW.resumetMovment();
    }

    public override void speedUp(float mul)
    {
        speedCurrent *= mul;

        CVW.changeSpeed(speedCurrent);
    }

    public override void speedDown(float mul)
    {
        speedCurrent /= mul;

        CVW.changeSpeed(speedCurrent);
    }
}
