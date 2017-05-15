using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipiPositionManager : MonoBehaviour {

    //Tableau contenant tous les positions possibles qu'un colon peut attaquer
    public GameObject[] tableauPosition;
    List<GameObject> lesPoisitionLibres;

    // Use this for initialization
    void Start () {

        lesPoisitionLibres = new List<GameObject>();

    }
	
    public List<GameObject> trouverPositionLibre()
    {
        lesPoisitionLibres.Clear();

        for (int i = 0; i < tableauPosition.Length; i++)
        {
            if (tableauPosition[i].GetComponent<TipiPosition>().positionLibre())
            {
                lesPoisitionLibres.Add(tableauPosition[i]);
            }
        }

        return lesPoisitionLibres;
    }

    public bool jaiTuDeLaPlace()
    {
        for (int i = 0; i < tableauPosition.Length; i++)
        {
            if (tableauPosition[i].GetComponent<TipiPosition>().positionLibre())
            {
                return true;
            }
        }

        return false;
    }

    public void desactiverTousLesPositions()
    {
        for (int i = 0; i < tableauPosition.Length; i++)
        {
            tableauPosition[i].GetComponent<TipiPosition>().jeLibereLaPoisition();
            tableauPosition[i].GetComponent<Entity>().isActive = false;
        }
    }

}
