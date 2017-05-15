using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofPariculeSol : MonoBehaviour {

    [SerializeField]
    GameObject Poof;

    GameObject lePoof;

    HealthColon maHealth;

    // Use this for initialization
    void Start () {
        maHealth = transform.parent.GetComponent<HealthColon>();
        lePoof = Instantiate(Poof, new Vector3(-100, -100, -100), Quaternion.identity) as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (maHealth.dead != true)
            return;

        Debug.Log("la pousiere a marcher");
        lePoof.transform.position = transform.position;
        lePoof.SetActive(false);
        lePoof.SetActive(true);
    }
}
