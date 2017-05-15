using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class NetworkPlayer : NetworkBehaviour {

    [SerializeField]
    GameObject warriorPrefab;
    [SerializeField]
    GameObject spiritPrefab;

    GameObject player;

    [SyncVar]
    public int pCharacter;
    private bool firstTime = true;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!isLocalPlayer)
            return;

        StartCoroutine(DelaySpwawn());
    }

    [Command]
    public void CmdSetUpWarrior()
    {
        player = Instantiate(warriorPrefab, GameObject.Find("SpawnWarrior").transform.position, Quaternion.identity) as GameObject;
        NetworkServer.SpawnWithClientAuthority(player, gameObject);
    }

    [Command]
    public void CmdSetUpSpirit()
    {
        player = Instantiate(spiritPrefab, GameObject.Find("SpawnSpirit").transform.position, Quaternion.identity) as GameObject;
        NetworkServer.SpawnWithClientAuthority(player, gameObject);
    }

    //[ClientRpc]
    public void EnableClient()
    {
        if (pCharacter == 0)
        {
            GameObject.FindGameObjectWithTag("Warrior").GetComponent<NetworkPlayerSetup>().EnablePlayer();
        }
        else if (pCharacter == 1)
        {
            GameObject.FindGameObjectWithTag("Spirit").GetComponent<NetworkPlayerSetup>().EnablePlayer();
        }
    }

    IEnumerator DelaySpwawn()
    {
        yield return new WaitForSeconds(0.1f);
        
        switch(pCharacter)
        {
            case 0:
                CmdSetUpWarrior();
                break;
            case 1:
                CmdSetUpSpirit();
                break;
            default:
                Debug.Log(pCharacter);
                break;
        }

        GetComponent<NetworkPlayerInput>().InitialiserInput(pCharacter);
        GetComponent<NetworkPlayerInput>().enabled = true;
        
        yield return new WaitForSeconds(1f);
        firstTime = false;
    }

    void OnLevelWasLoaded()
    {
        if (firstTime)
            return;

        if (!isLocalPlayer)
            return;

        //CmdSetUpPlayer();
        StartCoroutine(DelaySpwawn());
    }
}
