using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourActiverColon : MonoBehaviour {

    [SerializeField] float countDownAvantDepart;

    // Update is called once per frame
    void Update () {
        if (countDownAvantDepart <= 0 && GetComponent<EntitySpawnSetup>().isActive == false)
        {
            GetComponent<EntitySpawnSetup>().InitializeEntity();
            GetComponent<PourActiverColon>().enabled = false;

        }
        else
        {
            countDownAvantDepart -= Time.deltaTime;
        }
    }
}
