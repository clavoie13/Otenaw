using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonAttack : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartAttack()
    {
        if(GetComponent<chasserVillageois>() != null)
        {
            GetComponent<chasserVillageois>().StartAttack();
        }
        else if (GetComponent<chasserWarriorTuto>() != null)
        {
            GetComponent<chasserWarriorTuto>().StartAttack();
        }
        else if (GetComponent<chasserVillageoisTuto>() != null)
        {
            GetComponent<chasserVillageoisTuto>().StartAttack();
        }
    }

    public void EndAttack()
    {
        if (GetComponent<chasserVillageois>() != null)
        {
            GetComponent<chasserVillageois>().EndAttack();
        }
        else if (GetComponent<chasserWarriorTuto>() != null)
        {
            GetComponent<chasserWarriorTuto>().EndAttack();
        }
        else if (GetComponent<chasserVillageoisTuto>() != null)
        {
            GetComponent<chasserVillageoisTuto>().EndAttack();
        }
    }
}
