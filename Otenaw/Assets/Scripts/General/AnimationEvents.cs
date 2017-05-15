using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour  {

    [SerializeField]
    WarriorAttack WA;
    [SerializeField]
    WarriorHealth WH;
    [SerializeField]
    footStep FT;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void enablePlayer()
    {
        WH.enablePlayer();
    }

    public void StartSweep()
    {
        WA.StartSweep();
    }

    public void EndAttack()
    {
        WA.EndAttack();
    }

    public void StartAttack()
    {
        WA.StartAttack();
    }

    public void EndCombo()
    {
        WA.EndCombo();
    }

    public void StopThrust()
    {
        WA.StopThrust();
    }

    public void StartPsSlash()
    {
        WA.StartPSAttaque();
    }

    public void StartPsSweep()
    {
        WA.StartPSSweep();
    }

    public void StartPsThrust()
    {
        WA.StartPSThrust();
    }

    public void StartLigneVitesse()
    {
        WA.StartPSLigne();
    }

    public void StopLigneVitesse()
    {
        WA.StopPSLigne();
    }

    public void sonsFootStep()
    {
        FT.jouerSon();
    }
}
