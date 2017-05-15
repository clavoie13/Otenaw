using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class HealthSpirit : NetworkBehaviour {

    [SerializeField]
    SpiritHealthBar sHB;

    [SerializeField]
    float MaxHealth = 100f;
    
    [SyncVar][HideInInspector]
    public float currentHealth;

    //float interval = 1f;

    [SyncVar][HideInInspector]
    public float cost = 1f;

    [SerializeField]
    float aCost;

    [SerializeField]
    float xCost;

    [SerializeField]
    float yCost;

    [SerializeField]
    float bCost;

    float tempsActuel = 1;
    bool castingDust = false;

    private SoundPlayer monSoundPlayer;

    void Start()
    {
        monSoundPlayer = GetComponent<SoundPlayer>();
    }

    private void Update()
    {
        if (!isServer)
            return;

        tempsActuel += Time.deltaTime;

        if (tempsActuel >= 1 && castingDust)
        {
            if (currentHealth - cost < 0)
            {
                RpcJouerSonManaVide();
                return;
            }

            currentHealth -= cost;

            //sHB.TakeDamage(cost);
            RpcLoseWill();
            tempsActuel = 0;
        }
    }

    [ClientRpc]
    void RpcJouerSonManaVide()
    {
        if (hasAuthority)
        {
            //monSoundPlayer.playSound(3);
            //Debug.Log("Joue le sous de pu de mana");
        }
    }

    [Command]
    public void CmdStartCasting()
    {
        RpcStartCasting();
    }

    [Command]
    public void CmdStopCasting()
    {
        RpcStopCasting();
    }

    [ClientRpc]
    void RpcStartCasting()
    {
        castingDust = true;
    }

    [ClientRpc]
    void RpcStopCasting()
    {
        castingDust = false;
    }

    private void OnEnable()
    {
        cost = bCost;
        currentHealth = MaxHealth;
    }

    [ClientRpc]
    void RpcLoseWill()
    {
        sHB.TakeDamage(cost);
    }

    [ClientRpc]
    void RpcGainWill(float will)
    {
        sHB.GetLife(will);

        //Jouer le son spirit-gainwill juste pour la spirit
        if (hasAuthority)
        {
            monSoundPlayer.playSound(2);
        }

    }

    [Command]
    public void CmdGainWill(float will)
    {
        //ajouter la wiil a la vie courante sans depasser le max life
        currentHealth = (currentHealth + will) >= MaxHealth ? MaxHealth : (currentHealth + will);

        RpcGainWill(will);
    }

    [Command]
    public void CmdChangeState(int state)
    {
        switch (state)
        {
            //spell A
            case 0:
                cost = aCost;
                break;
            //spell X
            case 1:
                cost = xCost;
                break;
            //spell Y
            case 2:
                cost = yCost;
                break;
            //spell B
            case 3:
                cost = bCost;
                break;
        }
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }

    public SpiritSpellAnimController GetSpellAnimController()
    {
        return sHB.GetComponent<SpiritSpellAnimController>();
    }

}
