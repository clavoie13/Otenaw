using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WarriorCooldownController : NetworkBehaviour {

    [SerializeField]
    WarriorAttack warriorAttack;

    [SerializeField]
    WarriorCooldownHud thrustHud;

    [SerializeField]
    WarriorCooldownHud sweapHud;

    WarriorCooldownHud cdActif;

    [SerializeField]
    float cooldownThrust;

    [SerializeField]
    float cooldownSweap; 

    bool spellInCooldown = false;

    [HideInInspector]
    public float currentTime;
    public float currentSecond;

    float dureCooldown = 0;

    [HideInInspector]
    float speed = 1;

    // Use this for initialization
    void Start () {
        currentTime = 0;
        dureCooldown = 0;
        sweapHud.InitialiserWCC(this);
        thrustHud.InitialiserWCC(this);
    }
	
	// Update is called once per frame
	void Update () {

        if (!hasAuthority)
            return;

        if (!spellInCooldown)
            return;

        currentTime += Time.deltaTime;
        currentSecond = Mathf.CeilToInt((dureCooldown/speed) - currentTime);

        if (currentTime >= (dureCooldown/speed))
        {    
            EndCooldown();
        }
    }

    public void StartCooldownThrust()
    {
        if(spellInCooldown)
        {
            EndCooldown();
        }

        cdActif = thrustHud;
        dureCooldown = cooldownThrust;
        currentSecond = dureCooldown;
        currentTime = 0;
        cdActif.Initialiser(dureCooldown);
        spellInCooldown = true;
    }

    public void StartCooldownSweap()
    {
        if (spellInCooldown)
        {
            EndCooldown();
        }

        cdActif = sweapHud;
        dureCooldown = cooldownSweap;
        currentSecond = dureCooldown;
        currentTime = 0;
        cdActif.Initialiser(dureCooldown);
        spellInCooldown = true;
    }

    void EndCooldown()
    {
        spellInCooldown = false;
        cdActif.StopCooldown();
        warriorAttack.spellInCooldown = false;
    }

    public void ChangeState(bool state)
    {
        //Vieux
        if(state)
        {
            thrustHud.ShowIcon();
            sweapHud.HideIcon();
            //afficher icon sweap
        }
        else //Jeune
        {
            //afficher icon thrust
            sweapHud.ShowIcon();
            thrustHud.HideIcon();
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
