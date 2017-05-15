using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DespawnVillageois : NetworkBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (!isServer)
            return;

        if (other.tag == "Villageois")
        {
            //Desactiver le villageois
            RpcDisableVillageois(other.gameObject);
        }
    }

    [ClientRpc]
    void RpcDisableVillageois(GameObject villageois)
    {
        villageois.GetComponent<FastForwardVillageois>().stopFastForward();
        villageois.GetComponent<EntitySpawnSetup>().DisableEntity();
    }
}

