using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;
using UnityEngine.Networking.Match;
using System.Collections;
using UnityEngine.EventSystems;


namespace Prototype.NetworkLobby
{
    public class LobbyManager : NetworkLobbyManager
    {
        static public LobbyManager INSTANCE;

        [Header("Unity UI Lobby")]
        [Tooltip("Time in second between all players ready & match start")]
        public float prematchCountdown = 5.0f;

        [Space]
        [Header("UI Reference")]
        // public LobbyTopPanel topPanel;

        [SerializeField]
        RectTransform mainMenuPanel;
        [SerializeField]
        RectTransform hostPanel;
        [SerializeField]
        RectTransform joinPanel;

        public RectTransform lobbyPanel;
        public RectTransform loadingPanel;

        public LobbyCountdownPanel countdownPanel;


        public RectTransform warriorTransform;
        public RectTransform spiritTransform;

        //public LobbyInfoPanel infoPanel

        protected RectTransform currentPanel;

        //Client numPlayers from NetworkManager is always 0, so we count (throught connect/destroy in LobbyPlayer) the number
        //of players, so that even client know how many player there is.
        [HideInInspector]
        public int _playerNumber = 0;

        //used to disconnect a client properly when exiting the matchmaker
        [HideInInspector]
        public bool _isMatchmaking = false;

        protected bool _disconnectServer = false;

        protected ulong _currentMatchID;

        protected LobbyHook _lobbyHooks;

        //[HideInInspector]
        public GameObject eventSystem;

        [HideInInspector]
        public int nextLevel;

        // Use this for initialization
        void Start()
        {
            INSTANCE = this;
            _lobbyHooks = GetComponent<Prototype.NetworkLobby.LobbyHook>();
            currentPanel = mainMenuPanel;

            GetComponent<Canvas>().enabled = true;

            DontDestroyOnLoad(gameObject);
        }

        public override void OnLobbyClientSceneChanged(NetworkConnection conn)
        {
            if (SceneManager.GetSceneAt(0).name == lobbyScene)
            {
                ChangeTo(mainMenuPanel);
            }
            else if(SceneManager.GetActiveScene().name == "LevelLoader")
            {
                //rien crisser
            }
            else
            {
                if(currentPanel == lobbyPanel)
                {
                    lobbyPanel.gameObject.SetActive(false);
                }
                //loadingPanel.GetComponent<loadingScreenController>().HideScreen(); 
                StartCoroutine(WaitBeforeFadeOut()); 
            }
        }

        public void ChangeTo(RectTransform newPanel)
        {

            if (currentPanel != null)
            {
                currentPanel.gameObject.SetActive(false);
            }

            if (newPanel != null)
            {
                newPanel.gameObject.SetActive(true);
            }

            currentPanel = newPanel;
        }

        public delegate void BackButtonDelegate();
        public BackButtonDelegate backDelegate;
        public void GoBackButton()
        {
            backDelegate();
        }

        public void SimpleBackClbk()
        {
            ChangeTo(mainMenuPanel);
        }

        public void StopHostClbk()
        {
            StopHost();
            ChangeTo(mainMenuPanel);
            //Destroy(GameObject.Find("Lobby"));
        }

        public void StopClientClbk()
        {
            StopClient();
            ChangeTo(mainMenuPanel);
        }


        public override void OnStartHost()
        {
            base.OnStartHost();

            ChangeTo(hostPanel);
            backDelegate = StopHostClbk;
        }

        // ----------------- Server callbacks ------------------

        //we want to disable the button JOIN if we don't have enough player
        //But OnLobbyClientConnect isn't called on hosting player. So we override the lobbyPlayer creation
        public override GameObject OnLobbyServerCreateLobbyPlayer(NetworkConnection conn, short playerControllerId)
        {
            GameObject obj = Instantiate(lobbyPlayerPrefab.gameObject) as GameObject;
            obj.transform.SetParent(warriorTransform);
            obj.transform.localPosition = Vector3.zero;
            gameObject.transform.localScale = Vector3.one;

            ChangeTo(lobbyPanel);

            /*for (int i = 0; i < lobbySlots.Length; ++i)
            {
                LobbyPlayer p = lobbySlots[i] as LobbyPlayer;

                if (p != null)
                {
                    p.RpcUpdateWindow();
                }
            }*/

            return obj;
        }

        public override void OnLobbyServerPlayerRemoved(NetworkConnection conn, short playerControllerId)
        {
            //ChangeTo(mainMenuPanel);
        }

        public override void OnLobbyServerDisconnect(NetworkConnection conn)
        {
            //ChangeTo(mainMenuPanel);
            //StopHostClbk();
        }

        public override bool OnLobbyServerSceneLoadedForPlayer(GameObject lobbyPlayer, GameObject gamePlayer)
        {
            //This hook allows you to apply state data from the lobby-player to the game-player
            //just subclass "LobbyHook" and add it to the lobby object.

            if (_lobbyHooks)
                _lobbyHooks.OnLobbyServerSceneLoadedForPlayer(this, lobbyPlayer, gamePlayer);

            return true;
        }

        // --- Countdown management

        public override void OnLobbyServerPlayersReady()
        {
            bool allready = true;
            for (int i = 0; i < lobbySlots.Length; ++i)
            {
                if (lobbySlots[i] != null)
                    allready &= lobbySlots[i].readyToBegin;
            }

            if (allready)
            {
                StartCoroutine(ServerCountdownCoroutine());
                for (int i = 0; i < lobbySlots.Length; ++i)
                {
                    if (lobbySlots[i] != null)
                    {//there is maxPlayer slots, so some could be == null, need to test it before accessing!
                        (lobbySlots[i] as LobbyPlayer).CmdSetUnready();
                    }
                }
            }
        }

        public IEnumerator ServerCountdownCoroutine()
        {
            float remainingTime = prematchCountdown;
            int floorTime = Mathf.FloorToInt(remainingTime);

            while (remainingTime > 0)
            {
                yield return null;

                remainingTime -= Time.deltaTime;
                int newFloorTime = Mathf.FloorToInt(remainingTime);

                if (newFloorTime != floorTime)
                {//to avoid flooding the network of message, we only send a notice to client when the number of plain seconds change.
                    floorTime = newFloorTime;

                    for (int i = 0; i < lobbySlots.Length; ++i)
                    {
                        if (lobbySlots[i] != null)
                        {//there is maxPlayer slots, so some could be == null, need to test it before accessing!
                            (lobbySlots[i] as LobbyPlayer).RpcUpdateCountdown(floorTime);
                        }
                    }
                }
            }

            for (int i = 0; i < lobbySlots.Length; ++i)
            {
                if (lobbySlots[i] != null)
                {
                    (lobbySlots[i] as LobbyPlayer).RpcUpdateCountdown(0);
                }
            }

            ServerChangeScene(playScene);
        }

        // ----------------- Client callbacks -----------------
        public override void OnClientConnect(NetworkConnection conn)
        {
            base.OnClientConnect(conn);

            //infoPanel.gameObject.SetActive(false);

            // conn.RegisterHandler(MsgKicked, KickedMessageHandler);

            if (!NetworkServer.active)
            {//only to do on pure client (not self hosting client)
                ChangeTo(lobbyPanel);
                //backDelegate = StopClientClbk;
            }
        }

        public override void OnClientDisconnect(NetworkConnection conn)
        {
            base.OnClientDisconnect(conn);
            ChangeTo(mainMenuPanel);
        }

        public override void OnClientError(NetworkConnection conn, int errorCode)
        {
            ChangeTo(mainMenuPanel);
            //infoPanel.Display("Cient error : " + (errorCode == 6 ? "timeout" : errorCode.ToString()), "Close", null);
        }

        public void ShowLoadingScreen()
        {
            //loadingPanel.GetComponent<loadingScreenController>().ShowScreen();
            ChangeTo(loadingPanel);
        }

        IEnumerator WaitBeforeFadeOut()
        {
            yield return new WaitForSeconds(1f);
            loadingPanel.GetComponent<loadingScreenController>().HideScreen();
        }
    }
}
