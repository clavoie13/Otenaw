using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHeal : MonoBehaviour {

    [SerializeField]
    GameObject arrow;

	// Update is called once per frame
	void Update () {

        if (ObjectifManager.INSTANCE.nbrRewindWarrior)
        {
            arrow.SetActive(false);
        }
        else
        {
            if (ObjectifManager.INSTANCE.nbrAttackNormal && ObjectifManager.INSTANCE.nbrSpeciaAttack && ObjectifManager.INSTANCE.nbrRewindSpirit && ObjectifManager.INSTANCE.nbrFFSpirit)
            {
                arrow.SetActive(true);
            }
        }
    }

    private void OnEnable()
    {
        if (!ObjectifManager.INSTANCE.JeSuisDansUnTuto)
            enabled = false;
    }
}
