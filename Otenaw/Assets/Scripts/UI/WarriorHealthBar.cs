using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarriorHealthBar : MonoBehaviour {

    [SerializeField]
    Slider healthBar;

    WarriorHealth warrior;

    [SerializeField]
    Animator horlogeAnimator;

    [SerializeField]
    Animator feedbackAnimator;

    [SerializeField]
    Text feedbackText;

    private void Awake()
    {
        warrior = GetComponentInParent<WarriorHealth>();
    }

    // Update is called once per frame
    void Update () {

        healthBar.value = warrior.curHealth;
    }


    public void ToggleAnimation(bool state)
    {
        if(state)
        {
            horlogeAnimator.SetFloat("Speed", 1);
        }
        else
        {
            horlogeAnimator.SetFloat("Speed", -1);
        }
    }

    public void TakeDamage(int dmg)
    {
        if(dmg > 0)
        {
            feedbackText.text = "+" + dmg.ToString();
        }
        else
        {
            feedbackText.text = dmg.ToString();
        }

        feedbackAnimator.SetTrigger("play");
    }

}
