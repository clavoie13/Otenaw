using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ActivateLevel : NetworkBehaviour {

    bool warriorRdy = false;
    bool spiritRdy = false;

    GameObject[] networkPlayerlist;

    bool gameOn = false;

	// Use this for initialization
	void Start () {
        networkPlayerlist = GameObject.FindGameObjectsWithTag("Player");
        //Get les spawnerRandoms pour pas qui shit des robots
	}
	
	// Update is called once per frame
	void Update () {

        if (!isServer)
            return;

        if (gameOn)
            return;

        if (warriorRdy && spiritRdy)
        {
            RpcStartGame();
            //Go go gadget la game
            GetComponent<ObjectifManager>().toggleReady();

            RpcEnablePlayer();

            if (GetComponent<ObjectifManager>().JeSuisDansUnTuto)
            {
                RpcEnableTuto();
            }
            // Activer les spawnerRandoms pour qui shit des robots

            gameOn = true;          
        }

	}
    
    public void SetWarriorRdy()
    {
        
        RpcUpdateHud(0);
        warriorRdy = true;
    }

    public void SetSpiritRdy()
    {
        RpcUpdateHud(1);
        spiritRdy = true;
    }

    [ClientRpc]
    void RpcUpdateHud(int index)
    {
        GetComponent<ObjectifManager>().objHud.PlayerSetReady(index);
    }

    [ClientRpc]
    void RpcStartGame()
    {
        GetComponent<ObjectifManager>().objHud.StartGame();
    }

    [ClientRpc]
    void RpcEnablePlayer()
    {    
        networkPlayerlist = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject item in networkPlayerlist)
        {
            item.GetComponent<NetworkPlayer>().EnableClient();
        }
    }

    [ClientRpc]
    void RpcEnableTuto()
    {
        GameObject.Find("TutoController").GetComponent<TutoController>().enabled = true;
    }
}
