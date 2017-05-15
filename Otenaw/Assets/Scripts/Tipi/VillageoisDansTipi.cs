using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Events;

public class VillageoisDansTipi : NetworkBehaviour {

    [SerializeField]
    Text nbrVillageois;

    [SerializeField]
    Text nbrVillageoisMax;

    [SerializeField]
    Color couleurMax;

    [SerializeField]
    Color couleurNormal;

    int nbMax;
    bool isMax = false;

    public void Initialiser(int nbV, int nbM)
    {
        nbrVillageois.text = nbV.ToString();
        nbrVillageoisMax.text = nbM.ToString();
        nbMax = nbM;
        UpdateColor(nbV);     
    }

    public void UpdateVillageois(int nV)
    {
        UpdateColor(nV);
        nbrVillageois.GetComponent<Text>().text = nV.ToString();
    }

    void UpdateColor(int nV)
    {
        if(nV < nbMax && isMax)
        {
            nbrVillageois.color = couleurNormal;
            isMax = false;
        }
        else if(nV == nbMax)
        {
            nbrVillageois.color = couleurMax;
            isMax = true;
        }
    }
}
