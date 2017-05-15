using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ColliderPortes : NetworkBehaviour {

    [SerializeField]
    AnimationPortes[] tableauPorte;

    bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isServer)
            return;

        if (!isOpen)
        {
            isOpen = true;
            RpcOuvrirPorte();
        }

        CancelInvoke();
        Invoke("FermerPorte", 3f);
    }

    void FermerPorte()
    {
        RpcFermerPorte();
        isOpen = false;
    }

    [ClientRpc]
    void RpcOuvrirPorte()
    {
        foreach (AnimationPortes item in tableauPorte)
        {
            item.Ouvrir();
        }
    }

    [ClientRpc]
    void RpcFermerPorte()
    {
        foreach (AnimationPortes item in tableauPorte)
        {
            item.Fermer();
        }
    }
}
