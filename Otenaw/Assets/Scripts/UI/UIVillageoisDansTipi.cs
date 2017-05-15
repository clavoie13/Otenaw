using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIVillageoisDansTipi : MonoBehaviour {

    [SerializeField]
    TipiHudVillageoisIcon[] tableauVisage;

    int index;

    int nombreMax;

    int nombreActuel;

    float timeToFill = 5;

    TipiManager tipiManager;

    // Update is called once per frame
    void Update () {
        tableauVisage[index].imgFill.fillAmount = tipiManager.currentTime / timeToFill;
    }

    public void Initialiser(int nM, int nA, float time, TipiManager tM)
    {
        tipiManager = tM;

        timeToFill = time;

        nombreMax = nM;
        nombreActuel = nA;
        index = nA;

        for(int i = 0; i < nA; i++)
        {
            //Afficher l<icone full
            tableauVisage[i].imgFull.SetActive(true);
        }

        for(int i = 0; i < nM; i++)
        {
            tableauVisage[i].gameObject.SetActive(true);
        }
    }

    public void UpdateVillageois(int nA)
    {
        if (nA == 0)
        {
            ReleaseVillageois();
            return;
        }

        //Afficher l<image full  
        tableauVisage[index].imgFull.SetActive(true);
        tableauVisage[index].imgFull.GetComponent<Animator>().enabled = true;
        tableauVisage[index].imgFull.GetComponent<Animator>().SetTrigger("pop");
        tableauVisage[index].imgFill.fillAmount = 0;
        nombreActuel = nA;
        index = nA;
    }

    void ReleaseVillageois()
    {
        for (int i = 0; i < nombreMax; i++)
        {
            //desafficher les images full
            tableauVisage[i].imgFull.SetActive(false);
        }
        int lastIndex = index;
        index = 0;
        //Mettre le fill amount a 0
        tableauVisage[lastIndex].imgFill.fillAmount = 0;
    }

}
