using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritSangController : MonoBehaviour {

    WarriorHealth laHealth;
    [SerializeField]
    GameObject leSang;

    bool isActive = false;

	// Use this for initialization
	void OnEnable () {
        laHealth = GameObject.FindGameObjectWithTag("Warrior").GetComponent<WarriorHealth>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(laHealth.curHealth);
        if (laHealth.curHealth >= 85)
        {
            if (!isActive)
            {
                leSang.SetActive(true);
                isActive = true;
            }
        }
        else
        {
            if (isActive)
            {
                leSang.SetActive(false);
                isActive = false;
            }
        }
    }
}
