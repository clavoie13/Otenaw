using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectifHudAnimationController : MonoBehaviour {

    [SerializeField]
    Animator horloge;

    [SerializeField]
    Animator chrono;

    [SerializeField]
    Animator villageois;

    public void AddVillageois()
    {
        villageois.SetTrigger("Add");
    }

    public void SetCritique()
    {
        horloge.SetFloat("Speed", 3.0f);
        chrono.SetTrigger("Critique");
    }

    public void MoinsMinute()
    {
        chrono.SetTrigger("Minute");
    }

}
