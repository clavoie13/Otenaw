using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class FastForwardWarrior : FastForward {

    [SerializeField]
    float duration = 3;

    [SerializeField]
    float newSpeed = 2;

    float curTime = 0;
    bool active = false;
    WarriorMovement WM;
    WarriorAnimationController WAC;

    void Start()
    {
        WM = GetComponent<WarriorMovement>();
        WAC = GetComponent<WarriorAnimationController>();
    }

	// Update is called once per frame
	void Update () {

        //on veux que le serveur seulement face ce calcul
        if (!isServer)
            return;

        //si le fast forward n<est pas actif
        if (!active)
            return;

        curTime += Time.deltaTime;
        if (curTime >= duration)
        {
            stopFastForward();
        }
	}

    public override void startFastForward()
    {
        if (!isServer)
            return;

        //GetComponent<WarriorHealth>().changeState(1);
        GetComponent<RewindWarrior>().StopRewind();
        GetComponent<WarriorHealth>().RpcStartFastForward(newSpeed);
        WAC.CmdChangeSpeedSpell(1.5f);
        RpcChangeSpeed(1.5f);

        ObjectifManager.INSTANCE.setNbrFFWarrior();

        //changer le speed de l<animator
        //changer le speed de deplacement

        curTime = 0;
        active = true;
    }

    [ClientRpc]
    public void RpcChangeSpeed(float s)
    {
        WM.changeMultiplicateur(s);
    }

    public void stopFastForward()
    {
        //GetComponent<WarriorHealth>().changeState(1);
        active = false;
        GetComponent<WarriorHealth>().RpcStopFastForward();
        WAC.CmdChangeSpeedSpell(1f);
        RpcChangeSpeed(1f);
        //changer le speed de l<animator
        //changer le speed de deplacement
    }
}
