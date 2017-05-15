using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReadyPanel : MonoBehaviour {

    [SerializeField]
    GameObject aButton;

    [SerializeField]
    Text readyText;

    [SerializeField]
    Color colorReady;

    public void SetReady()
    {
        readyText.color = colorReady;
        aButton.SetActive(false);
        //readyText.fontSize = 70;
    }
}
