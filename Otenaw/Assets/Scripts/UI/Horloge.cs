using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Horloge : MonoBehaviour {

    [SerializeField]
    Text countdown;

    [SerializeField]
    Image horloge;

    [SerializeField]
    Color couleurMax;

    [SerializeField]
    Color couleurNormal;

    float timeToFill = 5;

    int time;

    TipiManager tipiManager;

	// Update is called once per frame
	void Update () {
        horloge.fillAmount = tipiManager.currentTime / timeToFill;
    }

    public void Initialiser(float tF, TipiManager tM)
    {
        timeToFill = tF;
        tipiManager = tM;
        horloge.fillAmount = 0;
    }

    public void UpdateCoutdown(string a)
    {
        if(countdown.color == couleurMax)
            countdown.color = couleurNormal;

        countdown.text = a;
    }

    public void SetMax()
    {
        countdown.color = couleurMax;
        countdown.text = "Max";
    }
}
