using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowControllerVillageois : SlowController {

    villageois monV;

    // Use this for initialization
    void Start()
    {
        monV = GetComponent<villageois>();
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
        monV.speedBou(force);
    }

    public override void reset()
    {
        if (!isServer)
            return;

        dansDeLaBou--;

        if (dansDeLaBou < 1)
            monV.speedBou(1f);
    }

    public override void removeAllBou()
    {
        if (!isServer)
            return;

        dansDeLaBou = 0;

        monV.speedBou(1f);
    }
}
