using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarriorCooldownHud : MonoBehaviour {

    [SerializeField]
    Text countdown;

    [SerializeField]
    Image cooldown;

    /*[SerializeField]
    Animator monAnimator;*/

    [SerializeField]
    GameObject inactiveImg;

    float timeToFill = 5;

    [HideInInspector]
    public bool inCooldown = false; 

    WarriorCooldownController cdController;

    // Update is called once per frame
    void Update()
    {
        if (!cdController)
            return;

        if (!inCooldown)
            return;

        cooldown.fillAmount = (timeToFill - cdController.currentTime) / timeToFill;
        countdown.text = cdController.currentSecond.ToString();
    }

    public void Initialiser(float tF)
    {
        timeToFill = tF;      
        cooldown.fillAmount = 1;
        inCooldown = true;
    }

    public void InitialiserWCC(WarriorCooldownController cdC)
    {
        cdController = cdC;
    }

    public void UpdateCoutdown(string a)
    {
        countdown.text = a;
    }

    public void StopCooldown()
    {
        inCooldown = false;
        countdown.text = "";
        cooldown.fillAmount = 0;
    }

    public void ShowIcon()
    {
        inactiveImg.SetActive(true);
        //monAnimator.SetTrigger("Show");
    }

    public void HideIcon()
    {
        inactiveImg.SetActive(false);
        //monAnimator.SetTrigger("Hide");
    }
}
