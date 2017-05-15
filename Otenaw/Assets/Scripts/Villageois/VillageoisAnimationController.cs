using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class VillageoisAnimationController : NetworkBehaviour
{

    Animator monAnimator;
    UnityEngine.AI.NavMeshAgent agent;

    RewindVillageois monRewind;
    FastForwardVillageois monFF;

    [SerializeField]
    GameObject PSHIT;

    GameObject leHit;

    // Use this for initialization
    void Start () {
        monAnimator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        monRewind = GetComponent<RewindVillageois>();
        monFF = GetComponent<FastForwardVillageois>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isServer)
            return;

        if (agent.velocity != Vector3.zero && !monRewind.entrainDeRewind)
        {
            RpcMove();
        }
        else if (!monRewind.entrainDeRewind)
        {
            RpcIdle();
        }
    }

    [ClientRpc]
    public void RpcMove()
    {
        monAnimator.SetFloat("Speed", 1f);
    }

    [ClientRpc]
    public void RpcIdle()
    {
        if (monAnimator == null)
            monAnimator = GetComponent<Animator>();
        monAnimator.SetFloat("Speed", 0f);
    }

    [ClientRpc]
    public void RpcStartRewind()
    {
        monAnimator.SetTrigger("StartRewind");
        monAnimator.SetFloat("SpeedSpell", monRewind.speedAnimation * -1f);
    }

    [ClientRpc]
    public void RpcStopRewind()
    {
        monAnimator.SetFloat("SpeedSpell", 1f);
    }

    [ClientRpc]
    public void RpcStartFF()
    {
        monAnimator.SetFloat("SpeedSpell", monFF.multiplicationSpeed);
    }

    [ClientRpc]
    public void RpcStopFF()
    {
        monAnimator.SetFloat("SpeedSpell", 1f);
    }

    [ClientRpc]
    public void RpcHit()
    {
        monAnimator.SetTrigger("Hit");
    }

    [ClientRpc]
    public void RpcDeath()
    {
        monAnimator.SetTrigger("Death");
    }

    [ClientRpc]
    public void RpcResetAnimator()
    {
        monAnimator.Rebind();
    }
}
