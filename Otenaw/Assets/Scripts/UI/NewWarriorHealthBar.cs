using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewWarriorHealthBar : MonoBehaviour {

    [SerializeField]
    Image healthBar;

    [SerializeField]
    Color couleurNormal;

    [SerializeField]
    Color couleurRewind;

    [SerializeField]
    Color couleurFastForward;

    WarriorHealth wH;

    WarriorHBAnimController animController;

    public float minLife = 10;
    public float maxLife = 100;

    float lifeRange;

    int danger = 70;

    int critique = 85;

    bool actif = false;

    float currentHealth;

    private void Start()
    {
        wH = GetComponentInParent<WarriorHealth>();
        animController = GetComponent<WarriorHBAnimController>();
        lifeRange = maxLife - minLife;
    }

    // Update is called once per frame
    void Update () {

        healthBar.fillAmount = (wH.curHealth - minLife) / lifeRange;
    }


    public void SetFastForward()
    {
        if (animController == null)
            return;

        healthBar.color = couleurFastForward;
        animController.SetNoiseSpeed(2);
    }

    public void SetRewind()
    {
        if (animController == null)
            return;

        healthBar.color = couleurRewind;
        animController.SetNoiseSpeed(-3);
    }

    public void StopEffect()
    {
        if(animController == null)
            return;

        healthBar.color = couleurNormal;
        animController.SetNoiseSpeed(1);
    }
}
