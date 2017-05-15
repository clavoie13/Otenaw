using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class villageois : NetworkBehaviour {

    [SerializeField] protected float speed;
    [SerializeField] TextMesh texteVie;

    protected float speedCurrent;

    private allerVersTemple AVT;

    public int monId = -1;

    private Collider monCollider;

    private UnityEngine.AI.NavMeshAgent monNavMesh;

    private float forceBou = 1f;

    // Use this for initialization
    void OnEnable () {
        AVT = GetComponent<allerVersTemple>();
        speedCurrent = speed;

        AVT.initialize();
        AVT.changeSpeed(speedCurrent);

        monCollider = GetComponent<CapsuleCollider>();
        monNavMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
	

    public virtual void disableMovement()
    {
        //Arreter de bouger
        AVT.stopMovement();

        RpcDesactiverColliderNavMesh();

    }

    public virtual void enableMovement()
    {
        RpcActiverColliderNavMesh();
    }

    public virtual void speedUp(float mul)
    {
        speedCurrent *= mul;

        AVT.changeSpeed(speedCurrent / forceBou);
    }

    public virtual void speedDown(float mul)
    {
        speedCurrent /= mul;

        AVT.changeSpeed(speedCurrent / forceBou);
    }

    public virtual void speedBou(float force)
    {
        forceBou = force;
        AVT.changeSpeed(speedCurrent / forceBou);
    }

    public void setId(int leId)
    {
        monId = leId;
    }

    public int getId()
    {
        return monId;
    }

    [ClientRpc]
    public void RpcDesactiverColliderNavMesh()
    {
        //Pour pouvoir passer au travers du stock
        GetComponent<CapsuleCollider>().isTrigger = true;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
    }

    [ClientRpc]
    public void RpcActiverColliderNavMesh()
    {
        //Pour pouvoir passer au travers du stock
        GetComponent<CapsuleCollider>().isTrigger = false;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;

        if (isServer)
            //Commencer a bouger
            AVT.resumetMovment();
    }
}
