using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WarriorParticleController : NetworkBehaviour {

    [SerializeField]
    ParticleSystem feedbackHit;

    [SerializeField]
    ParticleSystem feedbackHeal;

    [Command]
    public void CmdPlayHit()
    {
        RpcPlayHit();
    }

    [ClientRpc]
	public void RpcPlayHit()
    {
        //CancelInvoke();
        feedbackHit.Play();
        //Invoke("StopHit", 1f);
    }

    [Command]
    public void CmdStopHit()
    {
        RpcStopHit();
    }

    [ClientRpc]
    void RpcStopHit()
    {
        feedbackHit.Stop();
        feedbackHit.time = 0;
    }

    public void PlayHeal()
    {
        feedbackHeal.Play();
    }

    public void StopHeal()
    {
        feedbackHeal.Stop();
        feedbackHeal.time = 0;
    }
}
