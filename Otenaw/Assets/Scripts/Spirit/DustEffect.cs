using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class DustEffect : NetworkBehaviour
{

    [SerializeField] GameObject[] dustArray;

    private int stateSpell = 1;

    // Use this for initialization
    void Awake () {
        
    }

    public void SetDust(int SS)
    {
        stateSpell = SS;

        if (stateSpell == 0)
            return;

        for (int i = 0; i < dustArray.Length; i++)
        {
            dustArray[i].SetActive(false);
        }

        dustArray[stateSpell - 1].SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isServer)
            return;

        if(stateSpell == 1)
        {
            if (other.GetComponent<Rewind>())
            {
                other.GetComponent<Rewind>().startRewind();
            }
        }
        else if (stateSpell == 2)
        {
            if (other.GetComponent<FastForward>())
            {
                other.GetComponent<FastForward>().startFastForward();
            }
        }
    }
}
