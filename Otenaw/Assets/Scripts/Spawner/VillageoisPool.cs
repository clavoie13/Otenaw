using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class VillageoisPool : NetworkBehaviour {

    public static VillageoisPool INSTANCE;

    [SerializeField]
    GameObject villageois;

    /*[SerializeField]
    bool canGrow = true;*/

    [Space(10)]
    [Header("Options Level Designer")]

    [SerializeField]
    int nbrToPool = 20;

    List<GameObject> pool;

    VillageoisActifManager villageoisActifManager;

    //Id qu'on assigne a un villageois quand on le spawn sur le serveur
    int idVillageois = 0;

    void Awake()
    {
        INSTANCE = this;
    }

    // Use this for initialization
    void Start()
    {

        villageoisActifManager = GetComponent<VillageoisActifManager>();

        if (isServer)
        {
            pool = new List<GameObject>();

            for (int i = 0; i < nbrToPool; i++)
            {
                GameObject obj = Instantiate(villageois) as GameObject;
                obj.transform.position = new Vector3(-50f, -50f, -50f);
                //obj.GetComponent<HealthVillageois>().InstancierHud();
                pool.Add(obj);
                NetworkServer.Spawn(obj);
                obj.GetComponent<villageois>().setId(idVillageois);
                idVillageois++;
                villageoisActifManager.addUnVillageois(obj);
            }
        }

    }

    public GameObject GetPooledVillageois()
    {
        if (isServer)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].GetComponent<EntitySpawnSetup>().isActive)
                {
                    return pool[i];
                }
            }

            /* if (canGrow)
             {
                 GameObject obj = Instantiate(villageois) as GameObject;
                 pool.Add(obj);
                 NetworkServer.Spawn(obj);
                 obj.GetComponent<villageois>().setId(idVillageois);
                 idVillageois++;
                 villageoisActifManager.addUnVillageois(obj);
                 return obj;
             }*/
        }
        return null;
    }
}
