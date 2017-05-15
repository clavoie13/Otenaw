using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sOTuerColon : MonoBehaviour {

    public GameObject lePontSpirit;
    public GameObject lePontWarrior;
    int nbrATuer = 3;
    int nbrTuerCourant = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void jaiTuerUnColon(GameObject leColon)
    {

        if (!lePontSpirit.GetComponent<objectifComplet>().complet)
        {
            leColon.transform.position = new Vector3(-32f, 1, 17);
        }
        else
        {
            Destroy(leColon.gameObject);
            nbrTuerCourant++;

            if (nbrTuerCourant == nbrATuer)
            {
               GetComponent<sOPont>().activerSO();
            }
        }

    }

}
