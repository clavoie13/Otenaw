using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class TriggerTipi : NetworkBehaviour
{

    InteractionTipi iTipi;
    WarriorMiniHudController chienJaune;

    private bool isTriggered;

    private void Update()
    {
        if (!isTriggered)
            return;

        if (Input.GetButtonDown("Interact"))
        {
            if (gameObject.GetComponentInParent<TipiManager>().nbrVillageois < 1)
                return;

            //gameObject.GetComponentInParent<TipiManager>().ReleaseVillager();

            GetComponent<TipiJellyShot>().StartJelly();
            chienJaune.ReleaseVillageois(GetComponentInParent<TipiManager>().gameObject);
            iTipi.Cacher();
            //GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Warrior" && other.GetComponent<WarriorMovement>().enabled)
        {
            isTriggered = true;

            chienJaune  = other.GetComponent<WarriorMiniHudController>();
            iTipi = other.GetComponent<WarriorMiniHudController>().GetITipi();
            iTipi.Afficher();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Warrior" && other.GetComponent<WarriorMovement>().enabled)
        {
            isTriggered = false;
            iTipi.Cacher(); ;
        }
    }

}
