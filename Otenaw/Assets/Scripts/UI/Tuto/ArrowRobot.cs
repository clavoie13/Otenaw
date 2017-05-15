using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRobot : MonoBehaviour {

    [SerializeField]
    GameObject arrow;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!ObjectifManager.INSTANCE.JeSuisDansUnTuto)
            gameObject.SetActive(false);

        if (ObjectifManager.INSTANCE.nbrVillageoisSauver > 0)
        {
            arrow.SetActive(false);
        }
        else
        {
            arrow.SetActive(true);
        }
    }
}
