using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prototype.NetworkLobby;
using UnityEngine.Networking;
using UnityEngine.Events;

public class LevelLoader : NetworkBehaviour {

    [SerializeField]
    string[] ListeNiveau;

    /*
    void Awake()
    {
        LobbyManager.INSTANCE.ShowLoadingScreen();
    }
    */

    // Use this for initialization
    void Start () {
        if (!isServer)
            return;

        Invoke("ChangeLevel", 2f);
	}

    void ChangeLevel ()
    {
        LobbyManager.INSTANCE.ServerChangeScene(ListeNiveau[LobbyManager.INSTANCE.nextLevel]);
    }
}
