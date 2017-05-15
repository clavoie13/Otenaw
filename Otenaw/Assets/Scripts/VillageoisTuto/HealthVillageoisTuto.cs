using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthVillageoisTuto : Health
{

    public GameObject leColonQuiMeChasse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
            this.transform.position = new Vector3(-58, 0, 0);

            //Replacer le colon a sa position de depart
            leColonQuiMeChasse.transform.position = new Vector3(-58, 1, -6);
        }
    }
}
