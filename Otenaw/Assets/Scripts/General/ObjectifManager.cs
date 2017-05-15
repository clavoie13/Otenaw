using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using Prototype.NetworkLobby;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class ObjectifManager : NetworkBehaviour {

    public static ObjectifManager INSTANCE;

    public Transform transCamera;

    public GameObject CamRightMax;
    public GameObject CamLeftMax;
    public GameObject CamUpMax;
    public GameObject CamDownMax;

    [Header("Objectif de niveau")]
    public int nbrObjectif;
    //[SerializeField] int nbrStrikeMax;
    [SerializeField]
    [Tooltip("temps en secondes")]
    int timeObjectifEnSeconde;
    

    //canvas ou on affiche les barre de vie des ennemies et des villageois
    public Canvas entityCanvas;
    //public Canvas tipiCanvas;

    public ObjectifHud objHud;

    [SyncVar][HideInInspector]
    public int nbrVillageoisSauver = 0;

    bool canWin = true;
    private int nbrStrike = 0;

    [SyncVar(hook = "UpdateTimer")]
    private int timer = 0;

    float currentTime;
    public bool ready = false;
    [HideInInspector]
    public bool tutoOuvert = false;


    public bool JeSuisDansUnTuto = false;

    [SyncVar]
    [HideInInspector]
    public bool nbrOuvertTipi = false;
    [SyncVar]
    [HideInInspector]
    public bool nbrAttackNormal = false;
    [SyncVar]
    [HideInInspector]
    public bool nbrSpeciaAttack = false;

    [SyncVar]
    [HideInInspector]
    public bool nbrRewindNpc = false;
    [SyncVar]
    [HideInInspector]
    public bool nbrFFNpc = false;

    [SyncVar]
    [HideInInspector]
    public bool nbrRewindWarrior = false;
    [SyncVar]
    [HideInInspector]
    public bool nbrFFWarrior = false;
    [SyncVar]
    [HideInInspector]
    public bool nbrCollectDust = false;
    [SyncVar]
    [HideInInspector]
    public bool jaiFaisLePing = false;

    [SyncVar]
    [HideInInspector]
    public bool nbrRewindSpirit = false;
    [SyncVar]
    [HideInInspector]
    public bool nbrFFSpirit = false;

    [SyncVar]
    [HideInInspector]
    public bool nbrAttaquerRobot = false;

    [SyncVar]
    [HideInInspector]
    public bool jePeuxHealer = false;

    [SyncVar]
    [HideInInspector]
    public bool TriggerHealing = true;

    public string NextLevel = "";

    public int nbrTipi;

    [SerializeField]
    string[] ListeNiveau;

    bool commencerTuneFight = false;
    int demiTimeObjectifEnSeconde;

    [SerializeField]
    GameObject MusiquePlayer;

    private void Awake()
    {
        INSTANCE = this;
    }

    private void Start()
    {
        timer = timeObjectifEnSeconde;
        currentTime = 0;
        objHud.InitialiserObjectifScreen(nbrObjectif, timeObjectifEnSeconde);
        objHud.SetObjectif(nbrObjectif, timeObjectifEnSeconde);
        objHud.UpdateNbrSauver(nbrVillageoisSauver);
        demiTimeObjectifEnSeconde = timeObjectifEnSeconde / 2;
        //ready = true;
    }

    //pour decrementer le timer
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            XInputDotNetPure.GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
        }

        if(TriggerHealing)
        {
            if (nbrAttackNormal && nbrSpeciaAttack && nbrFFSpirit && nbrRewindSpirit)
            {
                StartCoroutine(delayHealing());
                TriggerHealing = false;
            }
        }

        if (!isServer)
            return;

        if (Input.GetKeyDown("1"))
        {
            RpcAfficherLoadingScreen();
            LobbyManager.INSTANCE.nextLevel = 0;
            StartCoroutine(WaitForLoadScreen());
            //LobbyManager.INSTANCE.ServerChangeScene("LevelLoader");
        }

        if (Input.GetKeyDown("2"))
        {
            RpcAfficherLoadingScreen();
            LobbyManager.INSTANCE.nextLevel = 1;
            StartCoroutine(WaitForLoadScreen());
            //LobbyManager.INSTANCE.ServerChangeScene("LevelLoader");
        }

        if (Input.GetKeyDown("3"))
        {
            RpcAfficherLoadingScreen();
            LobbyManager.INSTANCE.nextLevel = 2;
            StartCoroutine(WaitForLoadScreen());
            //LobbyManager.INSTANCE.ServerChangeScene("LevelLoader");
        }
        if (Input.GetKeyDown("4"))
        {
            RpcAfficherLoadingScreen();
            LobbyManager.INSTANCE.nextLevel = 3;
            StartCoroutine(WaitForLoadScreen());
            //LobbyManager.INSTANCE.ServerChangeScene("LevelLoader");
        }
        if (Input.GetKeyDown("5"))
        {
            RpcAfficherLoadingScreen();
            LobbyManager.INSTANCE.nextLevel = 4;
            StartCoroutine(WaitForLoadScreen());
            //LobbyManager.INSTANCE.ServerChangeScene("LevelLoader");
        }
        if (Input.GetKeyDown("6"))
        {
            RpcAfficherLoadingScreen();
            LobbyManager.INSTANCE.nextLevel = 5;
            StartCoroutine(WaitForLoadScreen());
            //LobbyManager.INSTANCE.ServerChangeScene("LevelLoader");
        }
        if (Input.GetKeyDown("7"))
        {
            RpcAfficherLoadingScreen();
            LobbyManager.INSTANCE.nextLevel = 6;
            StartCoroutine(WaitForLoadScreen());
            //LobbyManager.INSTANCE.ServerChangeScene("LevelLoader");
        }

        if (!ready)
            return;
        
        currentTime += Time.deltaTime;
        if(currentTime >= 1)
        {
            timer--;
            currentTime = 0;

            if (!commencerTuneFight)
            {
                if (timer <= demiTimeObjectifEnSeconde)
                {
                    commencerTuneFight = true;
                    MusiquePlayer.GetComponent<MusiqueController>().RpcPlayMusiqueFight();
                }
            }

            if(timer == 0)
            {
                EventManager.TriggerEvent("EventWarriorDie");
                MusiquePlayer.GetComponent<MusiqueController>().RpcPlayMusiqueDeath();

                StartCoroutine(ServerCountdownRestart());
                RpcLose();
                ready = false;
            }
        }
    }

    IEnumerator delayHealing()
    {
        yield return new WaitForSeconds(2f);
        jePeuxHealer = true;
    }

    void UpdateTimer(int timer)
    {
        objHud.UpdateTimer(timer);
    }

    /*public void TuerVillageois()
    {
        if (!canWin)
            return;

        nbrStrike++;
        RpcUpdateStrike(nbrStrike);

        if (nbrStrike >= nbrStrikeMax)
        {
            RpcLoseStrike();
            canWin = false;
        }
    }*/

    public void SauverVillageois()
    {
        if (!canWin)
            return;

        nbrVillageoisSauver++;
        RpcUpdateHud(nbrVillageoisSauver);    

        if (nbrVillageoisSauver == nbrObjectif)
        {
            EventManager.TriggerEvent("EventWin");
            MusiquePlayer.GetComponent<MusiqueController>().RpcPlayMusiqueWin();
            RpcWinEvent();
            toggleReady();
            //Loader la prochaine scene
            //Invoke("chargerProchainNiveau", 5f);
            StartCoroutine(ServerCountdownNextLevel());
        }
    }

    public void tipiDetruit()
    {
        nbrTipi--;

        if (nbrTipi <= 0)
        {
            EventManager.TriggerEvent("EventWarriorDie");
            MusiquePlayer.GetComponent<MusiqueController>().RpcPlayMusiqueDeath();

            StartCoroutine(ServerCountdownRestart());
            RpcLose();

        }
    }

    void chargerProchainNiveau()
    {
        RpcAfficherLoadingScreen();
        LobbyManager.INSTANCE.nextLevel++;

        if (LobbyManager.INSTANCE.nextLevel > 6)
            //CEST LA VIE
            Debug.Log("allo");
        else
            StartCoroutine(WaitForLoadScreen());
        //LobbyManager.INSTANCE.ServerChangeScene("LevelLoader");
    }

    void chargerNiveauActuel()
    {
        RpcAfficherLoadingScreen();
        StartCoroutine(WaitForLoadScreen());
        //LobbyManager.INSTANCE.ServerChangeScene("LevelLoader");
    }

    public void PlayerDied(int playerIndex)
    {
        if (!canWin)
            return;

        EventManager.TriggerEvent("EventWarriorDie");
        MusiquePlayer.GetComponent<MusiqueController>().RpcPlayMusiqueDeath();

        StartCoroutine(ServerCountdownRestart());
        RpcLose();
    }

    [ClientRpc]
    void RpcUpdateHud(int nVil)
    {     
        objHud.UpdateNbrSauver(nVil);
    }

    [ClientRpc]
    void RpcWinEvent()
    {
        entityCanvas.enabled = false;
        ready = false;
        objHud.SetInGamePanels(false);
        EventManager.TriggerEvent("EventStop");
    }

    /* [ClientRpc]
     void RpcUpdateStrike(int nStrike)
     {
         objHud.UpdateStrike(nStrike);
     }*/

    [ClientRpc]
    void RpcLose()
    {
        ready = false;
        objHud.SetInGamePanels(false);
        entityCanvas.enabled = false;
    }

    /*[ClientRpc]
    void RpcLoseStrike()
    {
        objHud.LoseStrike();
    }*/

    public void ShowTuto(int numeroTuto, bool jeSuisWarrior)
    {
        if(jeSuisWarrior)
        {
            switch (numeroTuto)
            {
                case 1:
                    objHud.TutoWarriorActivated(0);
                    break;
                case 2:
                    objHud.TutoWarriorActivated(1);
                    break;
                case 3:
                    objHud.TutoWarriorActivated(2);
                    break;
                case 4:
                    objHud.TutoWarriorActivated(3);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (numeroTuto)
            {
                case 1:
                    objHud.TutoSpiritActivated(0);
                    break;
                case 2:
                    objHud.TutoSpiritActivated(1);
                    break;
                case 3:
                    objHud.TutoSpiritActivated(2);
                    break;
                case 4:
                    objHud.TutoSpiritActivated(3);
                    break;
                default:
                    break;
            }
        }
    }

    public void TempleTuto()
    {
        //objHud.TutoTempleActivated();
    }

    public void StopTuto()
    {
        objHud.StopTuto();
    }

    //Pour le warrior
    public void setNbrOuvertTipi()
    {
        nbrOuvertTipi = true;
    }

    public void setNbrAttackNormal()
    {
        nbrAttackNormal = true;
    }

    public void setNbrSpeciaAttack()
    {
        nbrSpeciaAttack = true;
    }

    //Pour la spirit
    public void setNbrRewindNpc()
    {
        nbrRewindNpc = true;
    }

    public void setNbrFFNpc()
    {
        nbrFFNpc = nbrRewindNpc;
    }

    public void setNbrRewindWarrior()
    {
        if (nbrAttackNormal && nbrSpeciaAttack && nbrFFSpirit && nbrRewindSpirit && jePeuxHealer)
        {
            nbrRewindWarrior = true;
        }
    }

    public void setNbrRewindSpirit()
    {
        //Debug.Log("11111");
        nbrRewindSpirit = true;
    }

    public void setNbrFFSpirit()
    {
        //Debug.Log("22222");
        nbrFFSpirit = true;
    }

    public void setNbrFFWarrior()
    {
        nbrFFWarrior = nbrRewindWarrior;
    }

    public void setJaiFaisLePing()
    {
        jaiFaisLePing = nbrCollectDust;
    }

    //Pour starter la game
    public void toggleReady()
    {
        ready = !ready;
    }

    [ClientRpc]
    void RpcAfficherLoadingScreen()
    {
        LobbyManager.INSTANCE.ShowLoadingScreen();
    }

    public IEnumerator ServerCountdownRestart()
    {
        float remainingTime = 5;
        int floorTime = Mathf.FloorToInt(remainingTime);

        yield return new WaitForSeconds(3);
        RpcShowGameOverScreen();

        while (remainingTime > 0)
        {
            yield return null;

            remainingTime -= Time.deltaTime;
            int newFloorTime = Mathf.CeilToInt(remainingTime);

            if (newFloorTime != floorTime)
            {//to avoid flooding the network of message, we only send a notice to client when the number of plain seconds change.
                floorTime = newFloorTime;

                RpcUpdateTimerRestart(floorTime);
            }
        }

        RpcHideScreen();
        chargerNiveauActuel();
    }

    public IEnumerator ServerCountdownNextLevel()
    {
        float remainingTime = 5;
        int floorTime = Mathf.FloorToInt(remainingTime);

        yield return new WaitForSeconds(5);
        RpcShowWinScreen();

        while (remainingTime > 0)
        {
            yield return null;

            remainingTime -= Time.deltaTime;
            int newFloorTime = Mathf.CeilToInt(remainingTime);

            if (newFloorTime != floorTime)
            {//to avoid flooding the network of message, we only send a notice to client when the number of plain seconds change.
                floorTime = newFloorTime;

                RpcUpdateTimerNextLevel(floorTime);
            }
        }

        RpcHideScreen();
        chargerProchainNiveau();
    }

    [ClientRpc]
    void RpcUpdateTimerRestart(int newTime)
    {
        objHud.UpdateRestartTimer(newTime);
    }

    [ClientRpc]
    void RpcUpdateTimerNextLevel(int newTime)
    {
        objHud.UpdateNextLevelTimer(newTime);
    }

    [ClientRpc]
    void RpcShowWinScreen()
    {
        objHud.AfficherWinScreen();
    }

    [ClientRpc]
    void RpcShowGameOverScreen()
    {
        objHud.AfficherGameOverScreen();
    }

    [ClientRpc]
    void RpcHideScreen()
    {
        objHud.HideScreen();
    }

    IEnumerator WaitForLoadScreen()
    {
        yield return new WaitForSeconds(2f);
        LobbyManager.INSTANCE.ServerChangeScene("LevelLoader");
    }
}

