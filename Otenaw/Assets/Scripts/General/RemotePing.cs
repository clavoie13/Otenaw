using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class RemotePing : NetworkBehaviour
{


    [SerializeField]
    GameObject ombre;

    SoundPlayer leSoundPlayer;

    // Use this for initialization
    void Start () {
        leSoundPlayer = GetComponent<SoundPlayer>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void PlayPing()
    {
        ObjectifManager.INSTANCE.setJaiFaisLePing();
        leSoundPlayer.CmdPlaySound(2);
        GetComponent<TipiJellyShot>().CmdStartJelly();
    }
}
