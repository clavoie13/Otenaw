using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcHealthBar : MonoBehaviour {

    [SerializeField]
    GameObject barToHide;

    [SerializeField]
    Image trueHealthBar;

    [SerializeField]
    Image damageBar;

    private float currentLife = 1;
    private float pv = 1;
    private float maxLife = 100;
    private float speed = 0.5f;
    private float changeAmount;
    private float difference;

	private bool asChanged = false;
    private bool visible = false;

    // Update is called once per frame
    void OnGUI() {

        if (!asChanged)
            return;

        changeAmount = difference / speed * Time.deltaTime;
        pv -= changeAmount;
        damageBar.fillAmount -= changeAmount;

        if (pv <= currentLife)
        {
            pv = currentLife;
            damageBar.fillAmount = currentLife;
            asChanged = false;
        }
    }

    //fonction qui initialise les champs selon la vie maximum de l'entite et sa vie actuelle
    public void Initisalisation(float mLife, float cLife)
    {
        currentLife = cLife / mLife;
        pv = currentLife;

        trueHealthBar.fillAmount = currentLife;
        damageBar.fillAmount = pv;
        maxLife = mLife;
    }

    //fonction pour faire perdre de la vie a l'entite
    public void LoseLife(float dmg)
    {
        if (!visible)
            afficherBar();

        currentLife -= dmg / maxLife;      

        if (currentLife < 0)
            currentLife = 0;

        difference = pv - currentLife;
        asChanged = true;
        trueHealthBar.fillAmount = currentLife;
    }

    //affiche la bar de vie la premiere fois que l'entite prend des degats
    void afficherBar()
    {
        visible = true;
        barToHide.SetActive(true);
    }

    public void hideBar()
    {
        visible = false;
        barToHide.SetActive(false);
    }
}
