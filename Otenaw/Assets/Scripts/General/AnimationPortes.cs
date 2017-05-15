using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPortes : MonoBehaviour {

    [SerializeField]
    float timeToDo = 1.0f;

    [SerializeField]
    float scaleDesiree = 0.3f;

    float scaleActuel;

    Vector3 scaleOriginal;

    bool jouerAnimation = false;

    bool ouvrir;

    float difference = 0;

    [HideInInspector]
    public bool etat = false;

    private void Start()
    {
        scaleOriginal = gameObject.transform.localScale;
    }

    private void Update()
    {
        if (!jouerAnimation)
            return;

        difference = ((scaleOriginal.x - scaleDesiree) / timeToDo) * Time.deltaTime;

        if(ouvrir)
        {
            JouerOuverture(difference);
        }
        else
        {
            JouerFermeture(difference);
        }      
    }

    private void JouerFermeture(float diff)
    {
        scaleActuel += difference;
        if (scaleActuel >= scaleOriginal.x)
        {
            jouerAnimation = false;
            scaleActuel = scaleOriginal.x;
        }
        transform.localScale = new Vector3(scaleActuel, scaleOriginal.y, scaleOriginal.z);
    }

    private void JouerOuverture(float diff)
    {
        scaleActuel -= difference;
        if (scaleActuel <= scaleDesiree)
        {
            jouerAnimation = false;
            scaleActuel = scaleDesiree;
        }
        transform.localScale = new Vector3(scaleActuel, scaleOriginal.y, scaleOriginal.z);
    }

    public void Ouvrir()
    {
        scaleActuel = scaleOriginal.x;
        ouvrir = true;
        etat = true;
        jouerAnimation = true;
    }

    public void Fermer()
    {
        scaleActuel = scaleDesiree;
        ouvrir = false;
        etat = false;
        jouerAnimation = true;
    }

}
