using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class NetworkPlayerInput : NetworkBehaviour {

    public int indexPlayer = -1;
    public bool getInput = false;

    // Update is called once per frame
    void Update () {

        if (!isLocalPlayer)
            return;

        if (!getInput)
            return;

        if (Input.GetButtonDown("Interact"))
        {
            getInput = false;

            if (indexPlayer == 0)
            {
                CmdWarriorRdy();
            }
            else if(indexPlayer == 1)
            {
                CmdSpiritRdy();
            }
            
            enabled = false;
        }
    }

    public void InitialiserInput(int ip)
    {
        indexPlayer = ip;
        getInput = true;
    }

    [Command]
    void CmdWarriorRdy()
    {
        ObjectifManager.INSTANCE.GetComponent<ActivateLevel>().SetWarriorRdy();
    }

    [Command]
    void CmdSpiritRdy()
    {
        ObjectifManager.INSTANCE.GetComponent<ActivateLevel>().SetSpiritRdy();
    }
}
