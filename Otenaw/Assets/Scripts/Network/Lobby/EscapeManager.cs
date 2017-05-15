using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Prototype.NetworkLobby;
using UnityEngine.Networking;

public class EscapeManager : NetworkBehaviour {

	// Update is called once per frame
	void Update () {
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                LobbyManager.INSTANCE.GoBackButton();
            }
        }
	}
}
