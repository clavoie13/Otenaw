using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampDeVision : MonoBehaviour {

    chasserVillageois comportementDeChasse;
    
    // Use this for initialization
	void Start () {

        comportementDeChasse = GetComponentInParent<chasserVillageois>();

	}
	
    //Quand on entre dans le champ de vision
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Villageois" || other.tag == "Warrior" || other.tag == "Tipi")
        {
            if (other.GetComponent<Entity>().isActive)
            {
                comportementDeChasse.jaiVuQuelqueChose(other);
            }
        }
    }

}
