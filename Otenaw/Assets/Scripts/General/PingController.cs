using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class PingController : NetworkBehaviour
{
    SoundPlayer leSoundPlayer;

    GameObject otherPlayer;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Ping"))
        {
            
            CmdPlayPing();
        }
    }

    [Command]
    void CmdPlayPing()
    {
        if (gameObject.tag == "Warrior")
        {
            GameObject.FindGameObjectWithTag("Spirit").GetComponent<RemotePing>().PlayPing();
        }
        else
        {
            GameObject.FindGameObjectWithTag("Warrior").GetComponent<RemotePing>().PlayPing();
        }
    }
}
