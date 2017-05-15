using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaterTipiTuto : MonoBehaviour {

    [SerializeField]
    GameObject laTriggerBox;
    [SerializeField]
    GameObject laFleche;

    bool jeSuisWarrior = false;

	// Use this for initialization
	void Start () {
        if (!ObjectifManager.INSTANCE.JeSuisDansUnTuto)
        {
            laTriggerBox.SetActive(true);
            this.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {

		if(ObjectifManager.INSTANCE.nbrRewindWarrior)
        {
            laTriggerBox.SetActive(true);

            laFleche.SetActive(true);
        }
        else
        {
            laFleche.SetActive(false);
        }
	}
}
