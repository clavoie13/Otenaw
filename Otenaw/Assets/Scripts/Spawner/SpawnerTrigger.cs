using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour {

    [Header("Options Level Designer")]
    [Space(10)]
    [SerializeField]
    [Tooltip ("Liste des spawner a etre affecter par ce trigger")]
    GameObject[] tableauSpawners;
    
    [SerializeField]
    [Tooltip("Chaque index ajoute un use au trigger. La valeur de chaque index doit etre egale au nombre d'ennemi a spawner a cet utilisation")]
    int[] tableauNbrDeSpawn;

    private int compteurUse = 0;

    private void OnTriggerEnter(Collider other)
    {
        
        for(int i = 0; i < tableauSpawners.Length; i++)
        {
            ActiverSpawner(i);
        }

        compteurUse++;

        if (compteurUse == tableauNbrDeSpawn.Length)
            Destroy(this);
    }

    private void ActiverSpawner(int i)
    {
        tableauSpawners[i].GetComponent<spawner>().TriggeredSpawn(tableauNbrDeSpawn[compteurUse]);
    }

}
