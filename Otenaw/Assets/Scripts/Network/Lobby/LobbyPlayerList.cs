using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Prototype.NetworkLobby
{
    //List of players in the lobby
    public class LobbyPlayerList : MonoBehaviour
    {
        public static LobbyPlayerList INSTANCE = null;
        public List<LobbyPlayer> players = new List<LobbyPlayer>();

        public void OnEnable()
        {
            INSTANCE = this;
        }

        public void AddPlayer(LobbyPlayer player)
        {
            if (players.Contains(player))
                return;

            players.Add(player);
        }

        public void RemovePlayer(LobbyPlayer player)
        {
            players.Remove(player);
        }
    }
}