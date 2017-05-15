using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIDON_destroySpawnable : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {

        Invoke("DeleteObject", 3f);
	}

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime);
    }

    void DeleteObject()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

}
