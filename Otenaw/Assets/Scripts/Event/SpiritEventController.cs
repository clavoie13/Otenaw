using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class SpiritEventController : NetworkBehaviour
{

	// Use this for initialization
	void Start () {

        if (!isServer)
            return;

        EventManager.StartListening("EventWarriorDie", mettreMortLaSpirit);
        EventManager.StartListening("EventWin", gagner);

    }

    void mettreMortLaSpirit()
    {
        EventManager.StopListening("EventWarriorDie", mettreMortLaSpirit);
        GetComponent<SpiritAnimationController>().CmdDeath();

        RpcEventStop();
    }

    void gagner()
    {
        EventManager.StopListening("EventWin", gagner);
        GetComponent<SpiritAnimationController>().CmdDance();

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
