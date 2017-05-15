using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class DustSpawner : NetworkBehaviour
{

    public GameObject dustPrefab;
    public GameObject uiSpell;
    public float timeToSpawn = 0.2f;
    public int columnPoolSize = 15;

    private GameObject[] dustArray;
    private int currentDust = 0;
    [SyncVar] private int stateSpell = 0;

    private SoundPlayer leSoundPlayer;
    private Vector3 objectPoolPosition = new Vector3(-50, -50, -50);

    private HealthSpirit healthScript;
    private bool isAxisRightInUse = false;
    private bool isAxisLeftInUse = false;
    private HealthSpirit maHealth;
    private Transform positionDust;
    private SpiritAnimationController monAC;

    // Use this for initialization
    void Start()
    {
        monAC = GetComponent<SpiritAnimationController>();
        positionDust = GameObject.Find("SpawnWarrior").transform;
        maHealth = GetComponent<HealthSpirit>();
        //uiSpell.GetComponent<NpcStatusBar>().ShowEffect(2);

        leSoundPlayer = GetComponent<SoundPlayer>();
        healthScript = GetComponent<HealthSpirit>();

        if (isServer)
        {
            InvokeRepeating("spawnDust", timeToSpawn, timeToSpawn);

            dustArray = new GameObject[columnPoolSize];

            for (int i = 0; i < columnPoolSize; i++)
            {
                dustArray[i] = Instantiate(dustPrefab, objectPoolPosition, Quaternion.identity) as GameObject;
                NetworkServer.Spawn(dustArray[i]);
            }
        }
    }

    void Update()
    {
        if (!hasAuthority)
            return;

        if (Input.GetAxis("RewindTrigger") == 0 && isAxisLeftInUse)
        {
            maHealth.GetSpellAnimController().StopRewind();

            isAxisLeftInUse = false;
            maHealth.CmdStopCasting();  
            CmdChangeState(0);
            //uiSpell.GetComponent<NpcStatusBar>().StopEffect();
        }

        if (Input.GetAxis("FastForwardTrigger") == 0 && isAxisRightInUse)
        {
            maHealth.GetSpellAnimController().StopFastForward();

            isAxisRightInUse = false;
            maHealth.CmdStopCasting();
            CmdChangeState(0);
            //uiSpell.GetComponent<NpcStatusBar>().StopEffect();
        }


        if (Input.GetAxis("RewindTrigger") != 0 && !isAxisRightInUse && !isAxisLeftInUse)
        {
            maHealth.GetSpellAnimController().StartRewind();

            CmdTutoRewind();
            monAC.CmdRewind();
            isAxisLeftInUse = true;
            CmdPlaySound(0);
            CmdChangeState(1);
            healthScript.CmdChangeState(3);

            maHealth.CmdStartCasting();   
            //uiSpell.GetComponent<NpcStatusBar>().ShowEffect(0);

        }
        else if (Input.GetAxis("FastForwardTrigger") != 0 && !isAxisLeftInUse && !isAxisRightInUse)
        {
            maHealth.GetSpellAnimController().StartFastForward();

            CmdTutoFF();
            monAC.CmdFF();
            isAxisRightInUse = true;

            CmdPlaySound(1);
            CmdChangeState(2);
            healthScript.CmdChangeState(2);

            maHealth.CmdStartCasting();  
            //uiSpell.GetComponent<NpcStatusBar>().ShowEffect(1);
        }
    }

    [Command]
    void CmdTutoRewind()
    {
        ObjectifManager.INSTANCE.setNbrRewindSpirit();
    }

    [Command]
    void CmdTutoFF()
    {
        ObjectifManager.INSTANCE.setNbrFFSpirit();
    }

    [Command]
    void CmdChangeState(int s)
    {
        stateSpell = s;
    }

    [Command]
    void CmdPlaySound(int index)
    {
        leSoundPlayer.RpcPlaySound(index);
    }

    void spawnDust()
    {
        /*dustArray[currentDust].SetActive(true);
        dustArray[currentDust].transform.position = transform.position;*/

        if (stateSpell == 0 || maHealth.currentHealth <= maHealth.cost)
            return;

        dustArray[currentDust].GetComponent<DustEffect>().SetDust(stateSpell);
        RpcspawnDustClient(dustArray[currentDust]);
        

        currentDust++;

        if (currentDust >= columnPoolSize)
        {
            currentDust = 0;
        }
    }

    [ClientRpc]
    void RpcspawnDustClient(GameObject dust)
    {
        dust.transform.position = new Vector3 (transform.position.x, positionDust.position.y, transform.position.z);
        dust.GetComponent<DustEffect>().SetDust(stateSpell);
        dust.SetActive(true);
    }
}
