using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageoisActifManager : MonoBehaviour {

    List<GameObject> villageoisSpawn;
    List<GameObject> villageoisARetourner;

    bool premierAjouter = true;

    // Use this for initialization
    void Start () {

        villageoisARetourner = new List<GameObject>();
	}
	
	public void addUnVillageois(GameObject leVillageois)
    {
        if (premierAjouter)
        {
            villageoisSpawn = new List<GameObject>();
            premierAjouter = false;
        }

        villageoisSpawn.Add(leVillageois);
    }

    public List<GameObject> retournerListeVillageoisActif()
    {
        villageoisARetourner.Clear();

        for (int i = 0; i < villageoisSpawn.Count; i++)
        {
            if (villageoisSpawn[i].GetComponent<Entity>().isActive)
            {
                villageoisARetourner.Add(villageoisSpawn[i]);
            }
        }

        return villageoisARetourner;
    }

}
