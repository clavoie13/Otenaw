using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoController : MonoBehaviour {

    bool tutoTemple = true;
    public int numeroTuto = 0;
    private bool jeSuisWarrior = false;
    private bool tutoTempleOuvert = false;
    private float timeSuccesTuto = 0.5f;

    // Use this for initialization
    void Start () {
        //allo
        StartCoroutine(LateStart(1f));
    }
	
	// Update is called once per frame
	void Update () {

        /*if(tutoTemple)
        {
            if (ObjectifManager.INSTANCE.nbrVillageoisSauver > 0)
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
        }*/
        
        if(jeSuisWarrior)
        {
            if (numeroTuto == 1)
            {
                if (ObjectifManager.INSTANCE.nbrSpeciaAttack && ObjectifManager.INSTANCE.nbrAttackNormal)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
            else if (numeroTuto == 2)
            {
                if (ObjectifManager.INSTANCE.nbrRewindWarrior)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
            else if (numeroTuto == 3)
            {
                if (ObjectifManager.INSTANCE.nbrOuvertTipi)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
            else if (numeroTuto == 4)
            {
                if (ObjectifManager.INSTANCE.nbrAttaquerRobot)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
        }
        else
        {
            if (numeroTuto == 1)
            {
                if (ObjectifManager.INSTANCE.nbrRewindSpirit && ObjectifManager.INSTANCE.nbrFFSpirit)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
            else if (numeroTuto == 2)
            {
                if (ObjectifManager.INSTANCE.nbrRewindWarrior)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
            else if (numeroTuto == 3)
            {
                if (ObjectifManager.INSTANCE.nbrOuvertTipi)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
            else if (numeroTuto == 4)
            {
                if (ObjectifManager.INSTANCE.nbrRewindNpc)
                {
                    numeroTuto++;
                    StartCoroutine(WaitSuccesTuto(timeSuccesTuto));
                }
            }
        }

        if(!ObjectifManager.INSTANCE.tutoOuvert)
        {
            if (numeroTuto == 2 && (!ObjectifManager.INSTANCE.nbrSpeciaAttack || !ObjectifManager.INSTANCE.nbrAttackNormal || !ObjectifManager.INSTANCE.nbrRewindSpirit || !ObjectifManager.INSTANCE.nbrFFSpirit))
                return;


            
            ObjectifManager.INSTANCE.ShowTuto(numeroTuto, jeSuisWarrior);
            ObjectifManager.INSTANCE.tutoOuvert = true;
        }
    }

    IEnumerator WaitSuccesTuto(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ObjectifManager.INSTANCE.StopTuto();
        yield return new WaitForSeconds(1f);
        ObjectifManager.INSTANCE.tutoOuvert = false;
    }

    IEnumerator WaitHeal(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        yield return new WaitForSeconds(2F);
        ObjectifManager.INSTANCE.jePeuxHealer = true;
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
