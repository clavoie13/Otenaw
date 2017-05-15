using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HealthVillageois : Health
{
    VillageoisAnimationController monAC;

    private bool canTakeDamage = true;

    float currentTime = 0;

    [SerializeField]
    float invincibleTime = 10;

    public bool dead = false;

    [SerializeField]
    GameObject villageoisHud;

    [SerializeField]
    Renderer meshRenderer;

    

    private allerVersTemple monAllerVersTemple;
    private RewindVillageois monRewind;
    private FastForwardVillageois monFF;
    private SlowControllerVillageois monSCV;

    private SoundPlayer monSoundPlayer;


    // Use this for initialization
    void Start () {
        
        monRewind = GetComponent<RewindVillageois>();
        monFF = GetComponent<FastForwardVillageois>();
        monAC = GetComponent<VillageoisAnimationController>();
        monAllerVersTemple = GetComponent<allerVersTemple>();
        monSCV = GetComponent<SlowControllerVillageois>();
        monSoundPlayer = GetComponent<SoundPlayer>();
        InstancierHud();
    }
	
	// Update is called once per frame
	void Update () {

        RenderUI();

        if (canTakeDamage)
            return;

        currentTime += Time.deltaTime;

        if (currentTime >= invincibleTime)
        {
            if (dead)
                return;

            canTakeDamage = true;
            currentTime = 0;
        }
    }

    public override void TakeDamage(int damage)
    {
        if (!isServer)
        {
            return;
        }

        if (!canTakeDamage)
            return;

        canTakeDamage = false;

        if (monFF.entrainFF)
            monFF.stopFastForward();

        if (monRewind.entrainDeRewind)
            monRewind.stopRewind();


        disableVil();

        currentHealth -= damage;

        //Sync le hud sur les 2 clients
        RpcSyncHud(damage);

        

        if (currentHealth <= 0 && dead == false)
        {
            
            dead = true;
            monAC.RpcDeath();
            monSoundPlayer.RpcPlaySound(1);
            GetComponent<villageois>().disableMovement();

            StartCoroutine(killVil());
        }
        else
        {
            monAC.RpcHit();
            monSoundPlayer.RpcPlaySound(0);
        }
    }

    public void enableVil()
    {
        if (!isServer)
            return;

        monAllerVersTemple.resumetMovment();
    }

    void disableVil()
    {
        canTakeDamage = false;
        monAllerVersTemple.stopMovement();
    }

    IEnumerator killVil()
    {
        yield return new WaitForSeconds(1.5f);

        currentHealth = health;
        canTakeDamage = true;
        dead = false;

        //ObjectifManager.INSTANCE.TuerVillageois();
        //Sync s'il est mort 
        RpcSyncActive();
        monAC.RpcResetAnimator();
        monRewind.clearRewind();
        monSCV.removeAllBou();
    }

    public void InstancierHud()
    {
        villageoisHud = Instantiate(villageoisHud) as GameObject;
        villageoisHud.transform.SetParent(ObjectifManager.INSTANCE.entityCanvas.transform, false);

        maHealthBar = villageoisHud.GetComponent<NpcHealthBar>();      
        maHealthBar.Initisalisation(health, currentHealth);

        villageoisHud.GetComponent<UpdateUiPosition>().activer(gameObject);
    }

    void RenderUI()
    {

        if (meshRenderer == null)
            return;

        if (meshRenderer.isVisible)
        {
            villageoisHud.SetActive(true);
        }
        else
        {
            villageoisHud.SetActive(false);
        }
    }
}
