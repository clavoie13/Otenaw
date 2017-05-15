using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

namespace Prototype.NetworkLobby
{

    public class LobbyMenuCharacterSelect : MonoBehaviour, ISelectHandler
    {
        [SerializeField]
        int characterIndex;

        public void OnClick()
        {
            List<LobbyPlayer> players = LobbyPlayerList.INSTANCE.players;

            foreach (LobbyPlayer player in players)
            {
                if(player.isLocalPlayer)
                {
                    player.readyButton = GetComponent<Button>();
                    player.OnReadyClicked();
                }
            } 
        }

        public void OnSelect(BaseEventData eventData)
        {

            List<LobbyPlayer> players = LobbyPlayerList.INSTANCE.players;

            foreach (LobbyPlayer player in players)
            {
                if (player.isLocalPlayer)
                {
                    player.CmdUpdateCaracterHover(characterIndex);
                }
            }
        }
    }
}
