using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomerHud : MonoBehaviour {

    [SerializeField]
    GameObject bomb;

    [SerializeField]
    Text timeBomb;

    [SerializeField]
    Animator animator;

    public void StartTimer()
    {
        animator.Rebind();
        timeBomb.text = "4";
        bomb.SetActive(true);
    }

    public void UpdateTimer(int sec)
    {
        timeBomb.text = sec.ToString();
    }

    public void StopTimer()
    {
        bomb.SetActive(false);
    }

}
