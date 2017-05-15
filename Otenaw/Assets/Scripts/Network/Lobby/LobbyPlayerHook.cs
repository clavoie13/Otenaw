using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Prototype.NetworkLobby;

public class LobbyPlayerHook : LobbyHook {

    // Use this for initialization
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        NetworkPlayer localPlayer = gamePlayer.GetComponent<NetworkPlayer>();

        localPlayer.pCharacter = lobby.playerCharacter;
    }
}
