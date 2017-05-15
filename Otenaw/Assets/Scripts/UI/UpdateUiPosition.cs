using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUiPosition : MonoBehaviour {

    protected bool canDo = false;

    protected Vector3 worldPos;
    protected Vector3 screenPos;

    protected float healthPanelOffset = 3;

    protected GameObject parentEntity;

    // Update is called once per frame
    protected virtual void Update () {

        if (!canDo)
            return;

        worldPos = new Vector3(parentEntity.transform.position.x, parentEntity.transform.position.y + healthPanelOffset, parentEntity.transform.position.z);
        screenPos = Camera.main.WorldToScreenPoint(worldPos);
        gameObject.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);
    }

    public void activer(GameObject pE)
    {
        canDo = true;
        parentEntity = pE;
    }
}
