using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipiPosition : MonoBehaviour {

    //Variable qui permet de savoir si un colon est sur la position
    public bool libre;


	// Use this for initialization
	void Start () {
       //Indiquer que le point est libre;
       libre = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void jeReserveLaPosition()
    {
        libre = false;
    }

    public void jeLibereLaPoisition()
    {
        libre = true;
    }

    public bool positionLibre()
    {
        return libre;
    }
}
