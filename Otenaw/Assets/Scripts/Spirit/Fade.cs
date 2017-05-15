using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public float timeToFade;

    //private float timer = 0;
    private Vector3 positionDepart;

    // Use this for initialization
    void Start () {
        /*transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        positionDepart = transform.position;*/
        
    }

    void OnEnable()
    {
        Invoke("DestroyDust", timeToFade);
        /*transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        positionDepart = transform.position;*/
    }

    // Update is called once per frame
    void Update () {
        /*timer += Time.deltaTime;

        float lerp = timer / timeToFade;

        float valueScale = Mathf.Lerp(0.5f, 0f, lerp);
        float valueHeight = Mathf.Lerp(positionDepart.y, 0f, lerp);

        transform.localScale = new Vector3(valueScale, valueScale, valueScale);
        transform.position = new Vector3(transform.position.x, valueHeight, transform.position.z);

        if(valueScale <= 0)
        {
            timer = 0;
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.SetActive(false);
        }*/
	}

    void DestroyDust()
    {
        gameObject.SetActive(false);
    }
}
