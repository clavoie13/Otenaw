using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Prototype.NetworkLobby
{
    public class JoinMenuManager : MonoBehaviour
    {
        [SerializeField]
        LobbyManager lobbyManager;

        [SerializeField]
        InputField ipInput;

        [SerializeField]
        InputField portInput;

        [SerializeField]
        Text ipInputPlaceholder;

        [SerializeField]
        Text portInputPlaceholder;

        //selectionner le premier bouton quand est enable
        private void OnEnable()
        {
            ipInput.text = "";
            portInput.text = "";
            ipInputPlaceholder.text = PlayerPrefs.GetString("IpAdress");
            portInputPlaceholder.text = PlayerPrefs.GetInt("Port").ToString();
        }

        //quand le joueur appui sur joinGame
        public void OnSaveClick()
        {
            PlayerPrefs.SetString("IpAdress", ipInput.text);
            PlayerPrefs.SetInt("Port", int.Parse(portInput.text));
            gameObject.SetActive(false);
        }

    }
}
