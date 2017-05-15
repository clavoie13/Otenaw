using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class WarriorEventController : NetworkBehaviour {
	// Use this for initialization
	void Start () {

        if (!isServer)
            return;

        EventManager.StartListening("EventWarriorDie", mettreMortLeWarrior);
        EventManager.StartListening("EventWin", gagner);


    }

    void mettreMortLeWarrior()
    {
        EventManager.StopListening("EventWarriorDie", mettreMortLeWarrior);
        GetComponent<WarriorAnimationController>().CmdDeath();



        RpcEventStop();
    }

    void gagner()
    {
        EventManager.StopListening("EventWin", gagner);
        GetComponent<WarriorAnimationController>().CmdDance();

        RpcEventStop();
    }


    //Fonction pour caller le event stop car le trigger est juste sur le serveur
    [ClientRpc]
    void RpcEventStop()
    {
        EventManager.TriggerEvent("EventStop");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
