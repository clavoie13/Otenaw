using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthColonTutoWarrior : Health {

    public GameObject leManagerSousObjectif;


    public override void TakeDamage(int damage)
    {
        if (!isServer)
        {
            return;
        }

        health -= damage;

        //Sync le hud sur les 2 clients
        RpcSyncHud(damage);

        if (health <= 0)
        {
            health = currentHealth;
            //Sync s'il est mort 
            leManagerSousObjectif.GetComponent<sOTuerColon>().jaiTuerUnColon(this.gameObject);
        }

    }

}
