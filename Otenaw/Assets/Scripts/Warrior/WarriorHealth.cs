using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

using XInputDotNetPure;

public class WarriorHealth : Health {

    [SerializeField]
    GameObject WOLD;

    [SerializeField]
    GameObject WYOUNG;

    [SerializeField]
    GameObject poofSwap;

    [SerializeField]
    float maxHealth = 100;

    [SerializeField]
    float minHealth = 10;
    //[SerializeField] float forceKnockBack = 1;

    [SerializeField]
    WarriorHealthBar wHB;

    [SerializeField]
    NewWarriorHealthBar newWHB;

    [SerializeField]
    float dmgPerSecond;

    private bool canTakeDamage = true;

    /*[SyncVar(hook="ChangeAnimation")]
    private bool state = true;*/

    private float delay = 0.75f;

    private float previousHealth;

    [SerializeField]
    float invincibleTime = 1;

    float currentTime = 0;

    float delayDot = 0;

    [SyncVar] [HideInInspector]
    public float curHealth;

    WarriorAnimationController monAC;
    WarriorAttack monWarriorAttack;

    bool dead = false;

    bool isRewining = false;

    float speedDot = 1;

    MiniNewHealthBar maMiniHb;
    NpcStatusBar maStatusBar;

    CameraWarrior maCamera;

    private SoundPlayer monSoundPlayer;

    GameObject lePoofSwap;

    WarriorParticleController wParticleController;

    // Use this for initialization
    void Start()
    {
        curHealth = minHealth;
        previousHealth = curHealth;
        monAC = GetComponent<WarriorAnimationController>();
        monWarriorAttack = GetComponent<WarriorAttack>();
        maCamera = GetComponent<CameraWarrior>();
        monSoundPlayer = GetComponent<SoundPlayer>();
        wParticleController = GetComponent<WarriorParticleController>();

        lePoofSwap = Instantiate(poofSwap, new Vector3 (-100, -100, -100), Quaternion.identity) as GameObject;
    }

    private void Update()
    {
        if (!isServer)
            return;

        //SECTION POUR LE CHANGEMENT D'ETAT DU WARRIOR
        if(curHealth < 40)
        {
            if(previousHealth >= 40)
            {
                monWarriorAttack.RpcEndAttack();
                RpcDevenirJeune();
                RpcActiverPoof();
            }
        }
        else
        {
            if (previousHealth < 40)
            {
                monWarriorAttack.RpcEndAttack();
                RpcDevenirVieux();
                RpcActiverPoof();
            }
        }

        previousHealth = curHealth;

        //SECTION POUR LE VIEILLISSEMENT OVER TIME
        delayDot += Time.deltaTime;
        if (delayDot >= delay / speedDot)
        {
            //appel al fonction dot qui applique le dmg
            Dot();
            delayDot = 0;
        }


        //SECTION POUR PRENDRE DES DEGATS PAR LES CHRONOBOTS
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

    [ClientRpc]
    void RpcDevenirJeune()
    {
        //effet particule
        //transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        WOLD.SetActive(false);
        WYOUNG.SetActive(true);

        monAC.DevenirJeune();

        if (GetComponent<WarriorMovement>() != null)
            GetComponent<WarriorMovement>().rajeunir();

        if (GetComponent<WarriorAttack>() != null)
            GetComponent<WarriorAttack>().rajeunir();
    }

    [ClientRpc]
    void RpcDevenirVieux()
    {
        //effet particule
        //transform.localScale = new Vector3(1f, 1f, 1f);

        WOLD.SetActive(true);
        WYOUNG.SetActive(false);

        monAC.DevenirVieux();

        if (speedDot > 1)
            monAC.ChangeSpeedSpell(1.5f);

        if (GetComponent<WarriorMovement>() != null)
            GetComponent<WarriorMovement>().vieillir();

        if (GetComponent<WarriorAttack>() != null)
            GetComponent<WarriorAttack>().vieillir();
    }

    public override void TakeDamage(int damage)
    {
        if (!canTakeDamage)
            return;

        canTakeDamage = false;

        //previousHealth = curHealth;

        monAC.CmdHit();
        canTakeDamage = false;

        RpcDisablePlayer();

        RpcFeedbackBobo();

        curHealth += damage;
        wHB.TakeDamage(damage);
        wParticleController.CmdPlayHit();

        //si le joueur est mort
        if (curHealth >= maxHealth && dead == false)
        {
            ObjectifManager.INSTANCE.PlayerDied(0);
            dead = true;
            //monAC.CmdDeath();

            EventManager.TriggerEvent("EventWarriorDie");

        }
        else
        {
            //Sinon jouer le sons de warrior hurt
            Debug.Log("Son old warrior hurt");
            monSoundPlayer.RpcPlaySound(4);
        }
    }

    [ClientRpc]
    void RpcFeedbackBobo()
    {
        if (!hasAuthority)
            return;

        StartCoroutine(delaisVibration());
        maCamera.ShakeCamera(0.27f, 0.40f);
    }

    public void enablePlayer()
    {
        if (!hasAuthority)
            return;

        //canTakeDamage = true;
        GetComponent<WarriorMovement>().enableMovement();
        GetComponent<WarriorAttack>().enableAttack();
    }

    [ClientRpc]
    void RpcDisablePlayer()
    {
        if (!hasAuthority)
            return;

        GetComponent<WarriorMovement>().disableMovement();
        GetComponent<WarriorAttack>().disableAttack();
    }

    [ClientRpc]
    public void RpcStartRewind()
    {
        if (isRewining)
            return;

        isRewining = true;
        speedDot = 10;
        newWHB.SetRewind();
        maMiniHb.SetRewind();
        maStatusBar.StopEffect();
        maStatusBar.ShowEffect(0);
        wParticleController.PlayHeal();
    }

    [ClientRpc]
    public void RpcStopRewind()
    {
        isRewining = false;
        speedDot = 1;
        newWHB.StopEffect();
        maStatusBar.StopEffect();
        maMiniHb.StopEffect();
        wParticleController.StopHeal();
    }

    [ClientRpc]
    public void RpcStartFastForward(float newSpeed)
    {
        speedDot = newSpeed;
        maStatusBar.StopEffect();
        maStatusBar.ShowEffect(1);
        newWHB.SetFastForward();
        maMiniHb.SetFastForward();
    }

    [ClientRpc]
    public void RpcStopFastForward()
    {
        speedDot = 1;
        newWHB.StopEffect();
        maStatusBar.StopEffect();
        maMiniHb.StopEffect();
    }

    protected override void OnEnable()
    {
        //je veux que sa fasse rien
    }

    protected override void OnDisable()
    {
        //je veux que sa fasse rien
    }

    IEnumerator delaisVibration()
    {
        XInputDotNetPure.GamePad.SetVibration(PlayerIndex.One, 1f, 1f);

        yield return new WaitForSeconds(0.35f);

        XInputDotNetPure.GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
    }

    void Dot()
    {
        if (isRewining)
        {
            curHealth = (curHealth - dmgPerSecond) < minHealth ? minHealth : curHealth - dmgPerSecond;
            //appel pour le feedback
        }
        else
        {
            curHealth = (curHealth + dmgPerSecond) > maxHealth ? maxHealth : curHealth + dmgPerSecond;
            //appel pour le feedback
        }

        //si le joueur est mort
        if (curHealth >= maxHealth && dead == false)
        {

            ObjectifManager.INSTANCE.PlayerDied(0);
            dead = true;
            monAC.CmdDeath();
            RpcDisablePlayer();
            monSoundPlayer.RpcPlaySound(6);
        }
    }

    /*[ClientRpc]
    void RpcSpawnFeedback(bool type)
    {
    
    }*/

    public void InitialiserMiniHB(MiniNewHealthBar miniHB, NpcStatusBar statusBar)
    {
        maMiniHb = miniHB;
        maStatusBar = statusBar;
        if (!hasAuthority)
        {
            maMiniHb.Initisalisation(this);
        }
    }

    [ClientRpc]
    void RpcActiverPoof()
    {
        lePoofSwap.transform.position = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        lePoofSwap.SetActive(false);
        lePoofSwap.SetActive(true);
        monSoundPlayer.playSound(5);
    }

}
