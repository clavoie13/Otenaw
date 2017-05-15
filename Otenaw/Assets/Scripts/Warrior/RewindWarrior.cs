using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class RewindWarrior : Rewind {

    [SerializeField]
    float timeToRewind = 1;

    float curTime;

    bool rewind = false;
	
	// Update is called once per frame
	void Update () {

        if (!isServer)
            return;

        if (!rewind)
            return;

        curTime -= Time.deltaTime;
        if(curTime <= 0)
        {
            StopRewind();
        }
		
	}

    public override void startRewind()
    {
        if (!isServer)
            return;

        curTime = timeToRewind;

        if (ObjectifManager.INSTANCE.jePeuxHealer)
            CmdTutoRewind();

        if (!rewind)
        {
            GetComponent<FastForwardWarrior>().stopFastForward();
            GetComponent<WarriorHealth>().RpcStartRewind();

            rewind = true;
        }
    }

    [Command]
    void CmdTutoRewind()
    {
        ObjectifManager.INSTANCE.setNbrRewindWarrior();
    }

    public void StopRewind()
    {
        rewind = false;
        GetComponent<WarriorHealth>().RpcStopRewind();
    }
}
