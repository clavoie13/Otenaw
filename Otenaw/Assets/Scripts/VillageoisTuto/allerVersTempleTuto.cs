using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allerVersTempleTuto : allerVersTemple {

    public GameObject goalTuto;

    public override void initialize()
    {

        if (!isServer)
            return;

        //Trouver le goal (la porte du temple)
        goal = goalTuto;

        //Set la destination du villageois
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.enabled = true;
        agent.SetDestination(goal.transform.position);
    }
}
