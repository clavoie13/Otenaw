using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ColonAnimationController : NetworkBehaviour
{

    Animator monAnimator;
    UnityEngine.AI.NavMeshAgent agent;
    RewindColon monRewind;
    FastForwardColon monFF;

    [SerializeField]
    GameObject PSHIT;

    GameObject leHit;

    // Use this for initialization
    void Start () {
        leHit = Instantiate(PSHIT, new Vector3(-100, -100, -100), Quaternion.identity) as GameObject;

        monRewind = GetComponent<RewindColon>();
        monFF = GetComponent<FastForwardColon>();
        monAnimator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!isServer)
            return;

        if(agent.velocity != Vector3.zero && !monRewind.entrainDeRewind)
        {
            RpcMove();
            /*stop = true;
            StartCoroutine(waitUnPeu());*/
        }
        else if(!monRewind.entrainDeRewind)
        {
            RpcIdle();
            /*stop = true;
            StartCoroutine(waitUnPeu());*/
        }
	}

    [ClientRpc]
    public void RpcAttack()
    {
        monAnimator.SetTrigger("Attack");
    }

    [ClientRpc]
    public void RpcMove()
    {
        monAnimator.SetFloat("Walk_Speed", 1f);
    }

    [ClientRpc]
    public void RpcIdle()
    {
        if (monAnimator == null)
            monAnimator = GetComponent<Animator>();
        monAnimator.SetFloat("Walk_Speed", 0f);
    }

    [ClientRpc]
    public void RpcStartRewind()
    {
        monAnimator.SetFloat("Walk_Speed", 1f);
        monAnimator.SetFloat("SpeedSpell", monRewind.speedAnimation * -1f);
        monAnimator.SetTrigger("StartRewind");
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
        leHit.transform.position = transform.position;
        leHit.SetActive(false);
        leHit.SetActive(true);
    }

    [ClientRpc]
    public void RpcDeath()
    {
        monAnimator.SetTrigger("Death");
        leHit.SetActive(false);
        leHit.SetActive(true);
    }

    [ClientRpc]
    public void RpcDesactivate()
    {
        monAnimator.SetTrigger("Desactivate");
        leHit.SetActive(false);
        leHit.SetActive(true);
    }

    [ClientRpc]
    public void RpcRespawn()
    {
        monAnimator.SetTrigger("Respawn");
    }

    IEnumerator waitUnPeu()
    {
        yield return new WaitForSeconds(0.5f);
    }

    [ClientRpc]
    public void RpcResetAnimator()
    {
        monAnimator.Rebind();
    }
}
