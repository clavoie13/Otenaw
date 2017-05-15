using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTipi : MonoBehaviour {

    [SerializeField]
    GameObject btnImg;

    public void Afficher()
    {
        btnImg.SetActive(true);
    }

    public void Cacher()
    {
        btnImg.SetActive(false);
    }
}
