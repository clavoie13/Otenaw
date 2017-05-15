using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkState : NetworkBehaviour {

    [SyncVar]
    public int nbrPlayer = 0;

    public void AddPlayer()
    {
        nbrPlayer++;
    }

    public void RemovePlayer()
    {
        nbrPlayer--;
    }

    public int GetNbrPlayer()
    {
        return nbrPlayer;
    }
}
