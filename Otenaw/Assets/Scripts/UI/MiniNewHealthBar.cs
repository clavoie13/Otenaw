using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniNewHealthBar : MonoBehaviour {

    [SerializeField]
    Image healthBar;

    [SerializeField]
    GameObject hb;

    [SerializeField]
    Color couleurNormal;

    [SerializeField]
    Color couleurFastForward;

    [SerializeField]
    Color couleurRewind;

    WarriorHealth wH;

    public float minLife = 10;
    public float maxLife = 100;

    float lifeRange;

    int danger = 70;

    int critique = 85;

    bool actif = false;

    float currentHealth;

    WarriorMiniHBAnimController animController;

    private void Start()
    {
        lifeRange = maxLife - minLife;
        animController = GetComponent<WarriorMiniHBAnimController>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (!actif)
            return;

        currentHealth = wH.curHealth;
        healthBar.fillAmount = (currentHealth - minLife) / lifeRange;

        if(currentHealth > danger)
        {
            if (currentHealth > critique)
            {
                animController.PulseHigh();
            }
            else
            {
                animController.PulseLow();
            }
        }
        else
        {
            animController.StopPulse();
        }
    }

    public void Initisalisation(WarriorHealth wh)
    {
        wH = wh;
        actif = true;
        hb.SetActive(true);
        GetComponent<ArrowHeal>().enabled = true;
    }

    public void SetFastForward()
    {
        healthBar.color = couleurFastForward;
        animController.SetNoiseSpeed(2);
    }

    public void SetRewind()
    {
        healthBar.color = couleurRewind;
        animController.SetNoiseSpeed(-3);
    }

    public void StopEffect()
    {
        healthBar.color = couleurNormal;
        animController.SetNoiseSpeed(1);
    }
}
