using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoAnimatorController : MonoBehaviour {

    public void SetIdle()
    {
        GetComponent<Animator>().SetTrigger("Idle");
    }

    public void SetHide()
    {
        GetComponent<Animator>().SetTrigger("Hide");
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }
}
