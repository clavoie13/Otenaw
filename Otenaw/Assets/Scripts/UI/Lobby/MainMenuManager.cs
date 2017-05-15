using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.NetworkLobby
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField]
        LobbyManager lobbyManager;

        [SerializeField]
        Button firstSelect;

        [SerializeField]
        RectTransform creditPanel;

        [SerializeField]
        RectTransform introPanel;

        //selectionner le premier bouton quand est enable
        private void OnEnable()
        {
            //firstSelect.Select();
            StartCoroutine(WaitForIt());
        }

        //quand le joueur appui sur hostgame
        public void OnHostButton()
        {
            GetComponent<IpOptionManager>().HideOption();
            lobbyManager.networkPort = GetComponent<IpOptionManager>().GetPort();
            lobbyManager.StartHost();     
        }

        //quand le joueur appui sur joinGame
        public void OnJoinButton()
        {
            GetComponent<IpOptionManager>().HideOption();
            lobbyManager.networkAddress = GetComponent<IpOptionManager>().GetIpAdress();
            lobbyManager.networkPort = GetComponent<IpOptionManager>().GetPort();
            lobbyManager.StartClient();

            lobbyManager.backDelegate = lobbyManager.StopClientClbk;
        }

        //quand le joueur appui sur introduction
        public void OnIntroButton()
        {
            lobbyManager.backDelegate = lobbyManager.SimpleBackClbk;
            lobbyManager.ChangeTo(introPanel);
        }

        //quand le joueur appui sur credit
        public void OnCreditButton()
        {
            lobbyManager.backDelegate = lobbyManager.SimpleBackClbk;
            lobbyManager.ChangeTo(creditPanel);
        }

        //quand le joueur appui sur Quit
        public void OnQuitButton()
        {
            Application.Quit();
        }

        IEnumerator WaitForIt()
        {
            yield return new WaitForSeconds(0.1f);
            firstSelect.Select();
            if (lobbyManager.eventSystem == null)
                lobbyManager.eventSystem = GameObject.Find("EventSystem");
        }
    }
}
