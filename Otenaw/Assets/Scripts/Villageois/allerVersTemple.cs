using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class allerVersTemple : NetworkBehaviour
{

    protected GameObject goal;
    protected UnityEngine.AI.NavMeshAgent agent;
    // Use this for initialization
    void Start() {

    }

    public virtual void initialize()
    {
        StartCoroutine(stopLeGarsInitialize());

        if (!isServer)
            return;

        //Trouver le goal (la porte du temple)
        goal = GameObject.FindGameObjectWithTag("PorteTemple");

        //Set la destination du villageois
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.enabled = true;
        agent.SetDestination(goal.transform.position);

        //Mettre la valeur pour les chemins du tipi au temple 
        agent.SetAreaCost(3, 1);
    }

    void EventStop()
    {
        if (!isServer)
            return;

        stopMovement();

    }

    public void stopMovement()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        agent.velocity = Vector3.zero;
        agent.Stop();
    }

    public void resumetMovment()
    {
        agent.velocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        StartCoroutine(stopLeGars());
        agent.SetDestination(goal.transform.position);//**************************************************************
        agent.Resume();
    }

    public void resumetMovmentPasReset()
    {
        agent.velocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        StartCoroutine(stopLeGars());

        /*agent.SetDestination(goal.transform.position);//**************************************************************
        agent.Resume();*/
    }

    IEnumerator stopLeGars()
    {
        yield return new WaitForSeconds(0.05f);
        agent.velocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    IEnumerator stopLeGarsInitialize()
    {
        yield return new WaitForSeconds(5f);
        agent.velocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void changeSpeed(float speed)
    {
        if (!isServer)
            return;

        agent.speed = speed;
    }

    private void OnEnable()
    {
        //Pour quand le jeu stop
        EventManager.StartListening("EventStop", EventStop);
    }

    private void OnDisable()
    {
        //Pour quand le jeu stop
        EventManager.StopListening("EventStop", EventStop);
    }
}
