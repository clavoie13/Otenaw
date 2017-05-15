using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageoisTuto : villageois {

    private allerVersTempleTuto AVTT;

    // Use this for initialization
    void OnEnable()
    {
        AVTT = GetComponent<allerVersTempleTuto>();
        speedCurrent = speed;

        AVTT.initialize();
        AVTT.changeSpeed(speedCurrent);
    }


    public override void disableMovement()
    {
        AVTT.stopMovement();
    }

    public override void enableMovement()
    {
        AVTT.resumetMovment();
    }

    public override void speedUp(float mul)
    {
        speedCurrent *= mul;

        AVTT.changeSpeed(speedCurrent);
    }

    public override void speedDown(float mul)
    {
        speedCurrent /= mul;

        AVTT.changeSpeed(speedCurrent);
    }
}
