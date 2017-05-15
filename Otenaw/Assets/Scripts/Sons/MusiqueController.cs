using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class MusiqueController : NetworkBehaviour {

    public GameObject mDeath;
    public GameObject mWind;
    public GameObject mTheme;
    public GameObject mFight;
    public GameObject mWin;

    // Use this for initialization
    void Start() {

    }

    [ClientRpc]
    public void RpcPlayMusiqueDeath()
    {
        musiqueDeath();
    }

    [ClientRpc]
    public void RpcPlayMusiqueFight()
    {
        //musiqueFight();
    }

    void musiqueDeath()
    {
        //Arreter les autres musiques
        mWind.SetActive(false);
        mTheme.SetActive(false);
        mFight.SetActive(false);
        mWin.SetActive(false);

        //Commencer l'autre tune
        mDeath.SetActive(true);
        mDeath.GetComponent<AudioSource>().PlayDelayed(0.45f);

    }

    void musiqueFight()
    {
        //Arreter les autres musiques
        mWind.SetActive(false);
        mTheme.SetActive(false);
        mDeath.SetActive(false);
        mWin.SetActive(false);

        //Commencer l'autre tune
        mFight.SetActive(true);
        mFight.GetComponent<AudioSource>().PlayDelayed(0.45f);

    }

    [ClientRpc]
    public void RpcPlayMusiqueWin()
    {
        musiqueWin();
    }

    void musiqueWin()
    {
        //Arreter les autres musiques
        mWind.SetActive(false);
        mTheme.SetActive(false);
        mFight.SetActive(false);
        mDeath.SetActive(false);

        //Commencer l'autre tune
        mWin.SetActive(true);
        mWin.GetComponent<AudioSource>().PlayDelayed(0.45f);

    }

}
