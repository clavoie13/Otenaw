using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BoomTimerController : NetworkBehaviour {

    BoomerHud monHud;

	public void Initialiser(BoomerHud bh)
    {
        monHud = bh;
    }

    public void StartTimer()
    {
        monHud.StartTimer();
    }

    public void UpdateTimer(int sec)
    {
        monHud.UpdateTimer(sec);
    }

    public void StopTimer()
    {
        monHud.StopTimer();
    }

    [ClientRpc]
    public void RpcStopTimer()
    {
        monHud.StopTimer();
    }
}
