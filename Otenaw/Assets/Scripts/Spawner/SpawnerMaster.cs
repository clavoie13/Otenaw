using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class SpawnerMaster : NetworkBehaviour {

    [Header("Spawner Robots")]
    [SerializeField]
    [Tooltip("Liste des spawner a etre affecter par ce trigger")]
    GameObject[] tableauSpawners;

    [SerializeField]
    float timeSpawnOvertimeMin = 3f;
    [SerializeField]
    float timeSpawnOvertimeMax = 5f;

    float timeRandom;

    bool jeSuisPasPret = true;
    bool canSpawn = true;

    // Use this for initialization
    void Start () {

        EventManager.StartListening("EventStop", StopSpawn);
    }
	
	// Update is called once per frame
	void Update () {
        if (jeSuisPasPret)
        {
            if (ObjectifManager.INSTANCE.ready && isServer)
            {
                jeSuisPasPret = false;

                if (!isServer)
                    return;

                timeRandom = Random.Range(timeSpawnOvertimeMin, timeSpawnOvertimeMax);
                Invoke("SpawnOverTime", timeRandom);
            }
        }
    }

    public void StopSpawn()
    {
        canSpawn = false;
    }

    public void SpawnOverTime()
    {
        if (!canSpawn)
            return;

        int randomIndex = Random.Range(0, tableauSpawners.Length);
        tableauSpawners[randomIndex].GetComponent<spawner>().TriggeredSpawn(1);

        timeRandom = Random.Range(timeSpawnOvertimeMin, timeSpawnOvertimeMax);
        Invoke("SpawnOverTime", timeRandom);
    }
}
