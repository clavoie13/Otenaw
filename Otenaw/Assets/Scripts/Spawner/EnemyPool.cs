using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class EnemyPool : NetworkBehaviour {

    public static EnemyPool INSTANCE;

    [SerializeField]
    GameObject enemy;

    /*[SerializeField]
    bool canGrow = true;*/

    [Space(10)]
    [Header("Options Level Designer")]

    [SerializeField]
    int nbrToPool = 50;  

    List<GameObject> pool;

    void Awake ()
    {
        INSTANCE = this;
    }

	// Use this for initialization
	void Start () {

        if (isServer)
        {
            pool = new List<GameObject>();

            for (int i = 0; i < nbrToPool; i++)
            {
                GameObject obj = Instantiate(enemy) as GameObject;
                obj.transform.position = new Vector3(-50f, -50f, -50f);
                //obj.GetComponent<HealthColon>().InstancierHud();
                pool.Add(obj);
                NetworkServer.Spawn(obj);
            }
        }
	}

    public GameObject GetPooledEnemy()
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

            /*if (canGrow)
            {
                GameObject obj = Instantiate(enemy) as GameObject;
                pool.Add(obj);
                NetworkServer.Spawn(obj);
                return obj;
            }*/
        }
        return null;
    }
}
