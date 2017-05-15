using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SangController : MonoBehaviour {

    WarriorHealth laHealth;
    [SerializeField]
    GameObject leSang;

    bool isActive = false;

	// Use this for initialization
	void Start () {
        Debug.Log("je sus le hud");
        laHealth = GetComponent<WarriorHealth>();
    }
	
	// Update is called once per frame
	void Update () {
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
