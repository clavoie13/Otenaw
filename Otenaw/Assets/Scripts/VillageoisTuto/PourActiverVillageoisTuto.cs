using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourActiverVillageoisTuto : MonoBehaviour {

    [SerializeField] float countDownAvantDepart;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (countDownAvantDepart <= 0 && GetComponent<EntitySpawnSetup>().isActive == false)
        {
            GetComponent<EntitySpawnSetup>().InitializeEntity();
            GetComponent<PourActiverVillageoisTuto>().enabled = false;
        }
        else
        {
            countDownAvantDepart -= Time.deltaTime;
        }
    }
}
