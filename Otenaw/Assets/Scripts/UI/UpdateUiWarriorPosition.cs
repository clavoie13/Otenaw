using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUiWarriorPosition : UpdateUiPosition
{

    bool isWarrior = false;

    private void Start()
    {
        isWarrior = GameObject.FindGameObjectWithTag("Warrior").GetComponent<WarriorMovement>().enabled;
        if(isWarrior)
        {
            healthPanelOffset = 4;
        }
        else
        {
            healthPanelOffset = 4f;
        }
    }

    // Update is called once per frame
    protected override void Update () {
        if (!canDo)
            return;

        worldPos = new Vector3(parentEntity.transform.position.x, parentEntity.transform.position.y + healthPanelOffset, parentEntity.transform.position.z);
        screenPos = Camera.main.WorldToScreenPoint(worldPos);
        gameObject.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);
    }
}
