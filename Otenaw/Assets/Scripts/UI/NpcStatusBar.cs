using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcStatusBar : MonoBehaviour
{
    [SerializeField]
    GameObject[] tableauEffect;

    int indexActif;

    public void ShowEffect(int index)
    {
        indexActif = index;
        tableauEffect[indexActif].SetActive(true);
    }

    public void StopEffect()
    {
        tableauEffect[indexActif].SetActive(false);
    }
}
