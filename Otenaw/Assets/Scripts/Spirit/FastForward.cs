using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class FastForward : NetworkBehaviour
{
    public const int effectIndex = 1;

    public virtual void startFastForward()
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
}
