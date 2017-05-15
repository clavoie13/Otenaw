using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoControllerLevel2 : MonoBehaviour {

    bool tutoTemple = false;
    private int numeroTuto = 0;
    private bool jeSuisWarrior = false;
    private bool tutoTempleOuvert = false;
    private float timeSuccesTuto = 2f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LateStart(1f));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(numeroTuto);

        if (tutoTemple)
        {
            if (true)
            {
                tutoTemple = false;
                tutoTempleOuvert = true;
                ObjectifManager.INSTANCE.tutoOuvert = true;
                ObjectifManager.INSTANCE.StopTuto();
                ObjectifManager.INSTANCE.TempleTuto();
            }
        }
        else
        {
            if (Input.GetButtonDown("Interact") && tutoTempleOuvert)
            {
                ObjectifManager.INSTANCE.tutoOuvert = false;
                tutoTempleOuvert = false;
                ObjectifManager.INSTANCE.StopTuto();
            }
        }

        if (jeSuisWarrior)
        {
            if (numeroTuto == 1)
            {
                if (ObjectifManager.INSTANCE.nbrRewindWarrior)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
            else if (numeroTuto == 2)
            {
                if (ObjectifManager.INSTANCE.nbrFFWarrior)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
            else if (numeroTuto == 3)
            {
                if (ObjectifManager.INSTANCE.nbrCollectDust)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
            else if (numeroTuto == 4)
            {
                if (ObjectifManager.INSTANCE.jaiFaisLePing)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTutoFinal(timeSuccesTuto));
                }
            }
        }
        else
        {
            if (numeroTuto == 1)
            {
                if (ObjectifManager.INSTANCE.nbrRewindWarrior)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
            else if (numeroTuto == 2)
            {
                if (ObjectifManager.INSTANCE.nbrFFWarrior)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
            else if (numeroTuto == 3)
            {
                if (ObjectifManager.INSTANCE.nbrCollectDust)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
            else if (numeroTuto == 4)
            {
                if (ObjectifManager.INSTANCE.jaiFaisLePing)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTutoFinal(timeSuccesTuto));
                }
            }
        }

        if (!ObjectifManager.INSTANCE.tutoOuvert)
        {
            ObjectifManager.INSTANCE.ShowTuto(numeroTuto, jeSuisWarrior);
            ObjectifManager.INSTANCE.tutoOuvert = true;
        }
    }

    IEnumerator WaitSuccesTuto(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ObjectifManager.INSTANCE.StopTuto();
        ObjectifManager.INSTANCE.tutoOuvert = false;
    }

    IEnumerator WaitSuccesTutoFinal(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ObjectifManager.INSTANCE.StopTuto();
        ObjectifManager.INSTANCE.tutoOuvert = false;
        tutoTemple = true;
    }

    IEnumerator WaitTutoFermer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (tutoTempleOuvert)
        {
            ObjectifManager.INSTANCE.tutoOuvert = false;
            tutoTempleOuvert = false;
        }
    }

    IEnumerator LateStart(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

        if (GameObject.FindGameObjectWithTag("Warrior").GetComponent<WarriorMovement>().enabled)
        {
            jeSuisWarrior = true;
        }

        numeroTuto++;
        ObjectifManager.INSTANCE.ShowTuto(numeroTuto, jeSuisWarrior);
        ObjectifManager.INSTANCE.tutoOuvert = true;
    }
}
