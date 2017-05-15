using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colonTuto : Colon {

    //[SerializeField] float speed;

    private chasserVillageoisTuto CVT;


    // Use this for initialization
    void Start () {

        if (isServer)
            GetComponent<Rigidbody>().drag = 100;

        CVT = GetComponent<chasserVillageoisTuto>();
        speedCurrent = speed;

        CVT.initialize();
        CVT.changeSpeed(speedCurrent);
    }

    public override void disableMovement()
    {
        CVT.stopMovement();
    }

    public override void enableMovement()
    {
        CVT.resumetMovment();
    }

    public override void speedUp(float mul)
    {
        speedCurrent *= mul;

        CVT.changeSpeed(speedCurrent);
    }

    public override void speedDown(float mul)
    {
        speedCurrent /= mul;

        CVT.changeSpeed(speedCurrent);
    }
}
