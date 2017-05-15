using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempleHud : MonoBehaviour {

    [SerializeField]
    Text nbrSauver;

    [SerializeField]
    Text nbrObjectifs;

    [SerializeField]
    Animator monAnim;

    int ancienNombre;

    //set up le nombre de villageois a sauver dans le Hud
    public void SetObjectif(int nObjectifs)
    {
        nbrObjectifs.text = nObjectifs.ToString();
        ancienNombre = 0;
    }

    //update le nombre de villageois deja sauver dans le Hud
    public void UpdateNbrSauver(int nSauver)
    {
        if (ancienNombre != nSauver)
        {
            ancienNombre = nSauver;
            nbrSauver.text = nSauver.ToString();
            monAnim.SetTrigger("Add");
        }
    }
}
