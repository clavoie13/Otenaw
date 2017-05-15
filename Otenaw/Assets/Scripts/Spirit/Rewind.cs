using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class Rewind : NetworkBehaviour
{

    public bool entrainDeRewind = false;

    public const int effectIndex = 0; 

    public virtual void startRewind()
    {
        
    }

    [ClientRpc]
    protected void RpcShowStatusEffect()
    {
        GetComponent<Health>().maHealthBar.gameObject.GetComponent<NpcStatusBar>().StopEffect();
        GetComponent<Health>().maHealthBar.gameObject.GetComponent<NpcStatusBar>().ShowEffect(effectIndex);
    }

    [ClientRpc]
    protected void RpcStopStatusEffect()
    {
        GetComponent<Health>().maHealthBar.gameObject.GetComponent<NpcStatusBar>().StopEffect();
    }

    public virtual void clearRewind()
    {
    }

    [ClientRpc]
    protected void RpcStopTimer()
    {
        GetComponent<BoomTimerController>().StopTimer();
    }
}
