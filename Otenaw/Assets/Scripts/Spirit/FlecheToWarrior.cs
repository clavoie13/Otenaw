using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlecheToWarrior : MonoBehaviour {

    [SerializeField]
    float timeWait = 5f;

    private Transform warriorTransform;

    private Vector2 warriorV;
    private Vector2 forwardV;
    private bool wait = true;

	// Use this for initialization
	void Start () {

        if(transform.parent.gameObject.tag == "Warrior")
        {
            StartCoroutine(waitPlz());
        }
        else
        {
            StartCoroutine(waitPlzSpirit());
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (wait)
            return;


        forwardV = new Vector2(GetComponentInParent<Transform>().forward.x, GetComponentInParent<Transform>().forward.z);
        Vector3 difference = warriorTransform.position - transform.position;
        warriorV = new Vector2(difference.x, difference.z);

        float angle = GetAngle(forwardV, warriorV);

        transform.rotation = Quaternion.Euler(90f, 0f, angle);
	}

    private float GetAngle(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.x > vec1.x) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.up, diference) * sign;
    }

    IEnumerator waitPlz()
    {
        yield return new WaitForSeconds(timeWait);
        warriorTransform = GameObject.FindGameObjectWithTag("Spirit").transform;
        wait = false;
    }

    IEnumerator waitPlzSpirit()
    {
        yield return new WaitForSeconds(timeWait);
        warriorTransform = GameObject.FindGameObjectWithTag("Warrior").transform;
        wait = false;
    }
}
