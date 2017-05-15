using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTipi : MonoBehaviour {

    [SerializeField]
    GameObject arrow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!ObjectifManager.INSTANCE.JeSuisDansUnTuto)
            gameObject.SetActive(false);
		
        /*if(ObjectifManager.INSTANCE.nbrOuvertTipi)
        {
            arrow.SetActive(false);
        }
        else
        {
            arrow.SetActive(true);
        }*/

	}
}
