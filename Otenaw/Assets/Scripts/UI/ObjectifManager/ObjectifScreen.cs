using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectifScreen : MonoBehaviour {

    [SerializeField]
    PlayerReadyPanel warriorPanel;

    [SerializeField]
    PlayerReadyPanel spiritPanel;

    [SerializeField]
    GameObject infoPanel;

    [SerializeField]
    Text nbrVillageois;

    [SerializeField]
    Text minute;

    [SerializeField]
    Text seconde;

    public void Initialiser(int nbV, int time)
    {
        nbrVillageois.text = string.Format("x {0:0}", nbV);
        minute.text = (time / 60).ToString();
        seconde.text = string.Format("{0:0#}", (time % 60));

        infoPanel.SetActive(true);
        warriorPanel.gameObject.SetActive(true);
        spiritPanel.gameObject.SetActive(true);
    }

    public void SetReady(int index)
    {
        if(index == 0)
        {
            warriorPanel.SetReady();
        }
        else if(index  == 1)
        {
            spiritPanel.SetReady();
        }
    }

}
