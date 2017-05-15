using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipiActifManager : MonoBehaviour {

    GameObject[] tipiPresent;
    List<GameObject> tipiARetourner;

    // Use this for initialization
    void Start () {

        tipiPresent = GameObject.FindGameObjectsWithTag("Tipi");

        tipiARetourner = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {

    }
    
    //Retourner la liste des titpi actif qui reste de la place
    public List<GameObject> retournerListeTipiActif()
    {
        tipiARetourner.Clear();

        foreach (GameObject tipiCourant in tipiPresent)
        {
            if (tipiCourant.GetComponent<Entity>().isActive && tipiCourant.GetComponent<TipiPositionManager>().jaiTuDeLaPlace())
            {
                tipiARetourner.Add(tipiCourant);
            }
        }

        return tipiARetourner;
    }
}
