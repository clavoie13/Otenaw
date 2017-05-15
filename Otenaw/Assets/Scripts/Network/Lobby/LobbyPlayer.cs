using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Prototype.NetworkLobby
{
    public class LobbyPlayer : NetworkLobbyPlayer
    {
        enum Characters { Warrior, Spirit };
        static int[] personnage = new int[] { (int)Characters.Warrior, (int)Characters.Spirit };
        static List<int> _CharacterInUse = new List<int>();

        RectTransform warriorTransform;
        RectTransform spiritTransform;

        [SyncVar(hook = "UpdatePosition")]
        public int playerCharacter = 0;

        [SerializeField]
        Color couleurLocal;

        [SerializeField]
        Color couleurRemote;

        [SerializeField]
        GameObject remotePlayer;

        [SerializeField]
        GameObject localPlayer;

        [SerializeField]
        GameObject readyPanel;

        [SerializeField]
        GameObject ishaReady;

        [SerializeField]
        GameObject odemReady;

        public Button readyButton;

        [SyncVar]
        private bool ready = false;

        GameObject readyImage;

        // Use this for initialization
        void Start()
        {
            warriorTransform = LobbyManager.INSTANCE.warriorTransform;
            spiritTransform = LobbyManager.INSTANCE.spiritTransform;
            UpdatePosition(playerCharacter);
        }

        // Update is called once per frame
        void Update()
        {
            if (!ready)
                return;

            if (!isLocalPlayer)
                return;

            if (Input.GetButton("Cancel"))
            {
                ready = false;
                SendNotReadyToBeginMessage();
                LobbyManager.INSTANCE.eventSystem.SetActive(true);
                readyButton.Select();
                readyPanel.SetActive(false);

                readyImage.SetActive(false);

                CmdSetUnready();
            }

        }

        public override void OnClientEnterLobby()
        {
            base.OnClientEnterLobby();

            LobbyPlayerList.INSTANCE.AddPlayer(this);

            if (isLocalPlayer)
            {
                SetupLocalPlayer();
            }
            else
            {
                SetupOtherPlayer();
            }

            playerCharacter = 0;
        }

        public override void OnStartAuthority()
        {
            base.OnStartAuthority();
            SetupLocalPlayer();
        }

        void SetupOtherPlayer()
        {
            if (isServer)
            {
                localPlayer.SetActive(false);
                remotePlayer.SetActive(true);
                readyPanel.GetComponentInChildren<Text>().color = couleurRemote;
            }
            else
            {
                remotePlayer.SetActive(false);
                localPlayer.SetActive(true);
                readyPanel.GetComponentInChildren<Text>().color = couleurLocal;
            }
            OnClientReady(ready);
        }

        void SetupLocalPlayer()
        {
            if (isServer)
            {
                remotePlayer.SetActive(false);
                localPlayer.SetActive(true);
                readyPanel.GetComponentInChildren<Text>().color = couleurLocal;
            }
            else
            {
                localPlayer.SetActive(false);
                remotePlayer.SetActive(true);
                readyPanel.GetComponentInChildren<Text>().color = couleurRemote;
            }
            OnClientReady(ready);
        }

        public void UpdatePosition(int newPos)
        {
            switch (newPos)
            {
                case 0:
                    gameObject.transform.SetParent(warriorTransform);
                    gameObject.transform.localPosition = Vector3.zero;
                    gameObject.transform.localScale = Vector3.one;
                    readyImage = ishaReady;
                    break;
                case 1:
                    gameObject.transform.SetParent(spiritTransform);
                    gameObject.transform.localPosition = Vector3.zero;
                    gameObject.transform.localScale = Vector3.one;
                    readyImage = odemReady;
                    break;
                default:
                    break;
            }
        }

        public override void OnClientReady(bool readyState)
        {
            if (readyState)
            {
                readyPanel.SetActive(true);
                readyImage.SetActive(true);
            }
            else
            {
                readyPanel.SetActive(false);
                if(readyImage != null)
                    readyImage.SetActive(false);
            }
        }

        public void OnReadyClicked()
        {
            if (isLocalPlayer)
                CmdSetReady();
        }

        [Command]
        public void CmdSetReady()
        {
            int idx = System.Array.IndexOf(personnage, playerCharacter);

            int inUseIdx = _CharacterInUse.IndexOf(idx);

            if (idx < 0) idx = 0;

            idx = (idx + 1) % personnage.Length;

            bool alreadyInUse = false;

            for (int i = 0; i < _CharacterInUse.Count; ++i)
            {
                if (_CharacterInUse[i] == playerCharacter)
                {//that color is already in use
                    alreadyInUse = true;
                }
            }

            if (alreadyInUse)
            {
                //si chu deja utiliser faire un son de non
            }
            else
            {   //sinon on 
                _CharacterInUse.Add(playerCharacter);
                RpcSetReady();
                readyPanel.SetActive(true);
                ready = true;
                RpcToggleReady(ready);
            }
        }

        [Command]
        public void CmdSetUnready()
        {
            ready = false;
            _CharacterInUse.Remove(playerCharacter);
        }

        [Command]
        public void CmdUpdateCaracterHover(int index)
        {
            playerCharacter = index;
        }

        [ClientRpc]
        void RpcSetReady()
        {
            if (isLocalPlayer)
            {
                SendReadyToBeginMessage();
                LobbyManager.INSTANCE.eventSystem.SetActive(false);
            }
        }

        [ClientRpc]
        void RpcToggleReady(bool rdy)
        {
            OnClientReady(rdy);
        }

        //Cleanup thing when get destroy (which happen when client kick or disconnect)
        public void OnDestroy()
        {
            LobbyPlayerList.INSTANCE.RemovePlayer(this);
            _CharacterInUse.Remove(playerCharacter);
        }

        [ClientRpc]
        public void RpcUpdateCountdown(int countdown)
        {
            if (!isLocalPlayer)
                return; 

            LobbyManager.INSTANCE.countdownPanel.UIText.text = countdown.ToString();
            LobbyManager.INSTANCE.countdownPanel.gameObject.SetActive(countdown != 0);
            if (countdown == 1)
                LobbyManager.INSTANCE.loadingPanel.GetComponent<loadingScreenController>().ShowScreen();
        }

        [ClientRpc]
        public void RpcUpdateWindow()
        {
            LobbyManager.INSTANCE.ChangeTo(LobbyManager.INSTANCE.lobbyPanel);
        }
    }
}
