using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTriggerRerempli : MonoBehaviour {

    [Header("Options Level Designer")]
    [Space(10)]

    [SerializeField]
    float timeAvantRemplir = 5f;

    [SerializeField]
    [Tooltip("Liste des spawner a etre affecter par ce trigger")]
    GameObject[] tableauSpawners;

    [SerializeField]
    [Tooltip("Inscrire le nombre de robot a spawner pour le spawner au meme index que le tableau des spawner.")]
    int[] tableauNbrRobotDuSpawn;

    bool canSpawn = true;

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (!canSpawn)
            return;
        canSpawn = false;

        StartCoroutine(delaySpaw());

        for (int i = 0; i < tableauSpawners.Length; i++)
        {
            ActiverSpawner(i);
        }
    }

    private void ActiverSpawner(int i)
    {
        tableauSpawners[i].GetComponent<spawner>().TriggeredSpawn(tableauNbrRobotDuSpawn[0]);
    }

    IEnumerator delaySpaw()
    {
        yield return new WaitForSeconds(timeAvantRemplir);

        canSpawn = true;
    }
}
