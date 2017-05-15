using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sOPont : sousObjectif {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void activerSO()
    {
        //On veut que le pont s'active
        Debug.Log("Le pont doit bouger");

        leSousObjectif.transform.Rotate(0, 0, -90);
        leSousObjectif.GetComponent<objectifComplet>().complet = true;
    }
}
