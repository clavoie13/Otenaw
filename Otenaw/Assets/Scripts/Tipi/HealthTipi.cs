using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class HealthTipi : Health {

    [SerializeField]
    GameObject tipiHud;

    [SerializeField]
    Renderer meshRenderer;

    [SerializeField]
    float dureShake = 0.1f;

    [SerializeField]
    GameObject Tipi;

    SoundPlayer monSoundPlayer;

    bool doTheShake = false;

    float timer = 0;

    // Use this for initialization
    void Start () {
        timer = dureShake;
        InstancierHud();
        monSoundPlayer = GetComponent<SoundPlayer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (meshRenderer.isVisible)
        {
            tipiHud.SetActive(true);
        }
        else
        {
            tipiHud.SetActive(false);
        }

        if(doTheShake)
        {
            timer -= Time.deltaTime;

            Tipi.transform.localPosition = Random.insideUnitSphere * 0.25f;

            if(timer <= 0f)
            {
                timer = 0;
                doTheShake = false;
                Tipi.transform.localPosition = Vector3.zero;
            }
        }

    }

    public override void TakeDamage(int damage)
    {
        if (!isServer)
        {
            return;
        }

        currentHealth -= damage;

        //Sync le hud sur les 2 clients
        RpcSyncHud(damage);

        if (currentHealth <= 0)
        {
            currentHealth = health;
            //Sync s'il est mort 
            RpcSyncActive();
            
            //Avertir qu'un tipi est detruit
            ObjectifManager.INSTANCE.tipiDetruit();
        }
        else
        {
            RpcHitTipi();
        }
    }

    [ClientRpc]
    protected override void RpcSyncActive()
    {   
        //Desactiver mes comportement
        gameObject.GetComponent<TipiManager>().TipiMort();
    }

    [ClientRpc]
    protected void RpcHitTipi()
    {
        //Desactiver mes comportement
        monSoundPlayer.playSound(0);
        timer = dureShake;
        doTheShake = true;
    }

    public void InstancierHud()
    {
        tipiHud = Instantiate(tipiHud) as GameObject;
        tipiHud.transform.SetParent(ObjectifManager.INSTANCE.entityCanvas.transform, false);
        maHealthBar = tipiHud.GetComponent<NpcHealthBar>();

        tipiHud.GetComponent<UpdateUiPosition>().activer(gameObject);
        maHealthBar.Initisalisation(health, currentHealth);

        GetComponent<TipiManager>().InitialiserHud(tipiHud);
    }

    protected override void OnDisable()
    {
        tipiHud.SetActive(false);
    }
}
