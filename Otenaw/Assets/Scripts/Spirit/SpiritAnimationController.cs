using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class SpiritAnimationController : NetworkBehaviour
{

    [SerializeField]
    Animator monAnimator;

    // Use this for initialization
    void Start () {
		
	}

    [Command]
    public void CmdDance()
    {
        RpcDance();
    }

    [Command]
    public void CmdDeath()
    {
        RpcDeath();
    }

    [Command]
    public void CmdRewind()
    {
        RpcRewind();
    }

    [Command]
    public void CmdFF()
    {
        RpcFF();
    }

    [Command]
    public void CmdChangeSpeed(float s)
    {
        RpcChangeSpeed(s);
    }

    [ClientRpc]
    void RpcChangeSpeed(float s)
    {
        monAnimator.SetFloat("Speed", s);
    }

    [ClientRpc]
    void RpcRewind()
    {
        monAnimator.SetTrigger("Rewind");
    }

    [ClientRpc]
    void RpcFF()
    {
        monAnimator.SetTrigger("Fastforward");
    }

    [ClientRpc]
    void RpcDance()
    {
        int random = Random.Range(1, 3);

        if(random == 1)
            monAnimator.SetTrigger("Victory");
        else
            monAnimator.SetTrigger("Victory2");
    }

    [ClientRpc]
    void RpcDeath()
    {
        Debug.Log("Spirit mort");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
