using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtCamera : MonoBehaviour {

	// Update is called once per frame
	void LateUpdate () {

        Vector3 v = Camera.main.transform.position - transform.position;

        v.x = v.z = 0.0f;

        transform.LookAt(Camera.main.transform.position - v);
        //transform.rotation = Camera.main.transform.rotation;
    }
}
