using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Colon : NetworkBehaviour
{

    [SerializeField] protected float speed;

    protected float speedCurrent;

    private chasserVillageois CV;

    private Collider monCollider;

    private UnityEngine.AI.NavMeshAgent monNavMesh;

    private float forceBou = 1f;

    // Use this for initialization
    void Start () {

        monCollider = GetComponent<CapsuleCollider>();

        if (!isServer)
            return;

        GetComponent<Rigidbody>().drag = 100;

        CV = GetComponent<chasserVillageois>();
        speedCurrent = speed;

        CV.initialize();
        CV.changeSpeed(speedCurrent);
        monNavMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

    private void OnEnable()
    {
        GetComponent<NetworkTransform>().transformSyncMode = NetworkTransform.TransformSyncMode.SyncRigidbody3D;
    }

    // Update is called once per frame
    void Update () {
        
    }

    public virtual void disableMovement()
    {
        if (!isServer)
            return;

        //Arreter de bouger
        CV.stopMovement();

        RpcDesactiverColliderNavMesh();

    }

    public virtual void enableMovement()
    {
        if (!isServer)
            return;

        //Pour pouvoir pas passer au travers du stock
        RpcActiverColliderNavMesh();

    }

    public virtual void speedUp(float mul)
    {
        speedCurrent *= mul;

        CV.changeSpeed(speedCurrent / forceBou);
    }

    public virtual void speedDown(float mul)
    {
        speedCurrent /= mul;

        CV.changeSpeed(speedCurrent / forceBou);
    }

    public virtual void speedBou(float force)
    {
        forceBou = force;
        CV.changeSpeed(speedCurrent / forceBou);
    }

    [ClientRpc]
    public void RpcDesactiverColliderNavMesh()
    {
        //Pour pouvoir passer au travers du stock
        monCollider.isTrigger = true;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
    }

    [ClientRpc]
    public void RpcActiverColliderNavMesh()
    {
        //Pour pouvoir passer au travers du stock
        monCollider.isTrigger = false;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;

        if(isServer)
            //Commencer a bouger
            CV.resumetMovment();
    }
}
