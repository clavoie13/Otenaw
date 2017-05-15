using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;



public class WarriorAttack : NetworkBehaviour {

    [SerializeField]
    WarriorWeapon Weapon;

    [SerializeField]
    float DureSlashAttack;

    [SerializeField]
    float DureThrustAttack;

    [SerializeField]
    float ForceThrustAttack;


    [SerializeField]
    int slashDamageOld;

    [SerializeField]
    int slashDamageYoung;

    [SerializeField]
    int thrustDamage;

    [SerializeField]
    int sweepDamage;

    [SerializeField]
    float dureCooldown = 3f;

    [SerializeField]
    WarriorCooldownController wCd;

    /*[SerializeField]
    AudioClip soundAttack;*/

    private Rigidbody rBody;
    private WarriorMovement lePlayerController;
    private WaitForSeconds timeDashAttack;
    private bool canAttack;
    private bool isOld = false;
    private SoundPlayer leSoundPlayer;
    private WarriorAnimationController leAnimationController;

    private bool isAxisRightInUse = false;
    private bool isAxisLeftInUse = false;

    private float timeCooldown = 0f;

    [HideInInspector]
    public bool spellInCooldown = false;

    private bool canCombo = false;

    private int attaqueDuCombo = -1;
    private float tempsEntreChaqueCoup = 0f;

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        leSoundPlayer = GetComponent<SoundPlayer>();
        leAnimationController = GetComponent<WarriorAnimationController>();
        lePlayerController = GetComponent<WarriorMovement>();
        canAttack = true;
        timeDashAttack = new WaitForSeconds(DureThrustAttack);
        wCd.ChangeState(isOld);
    }

    // Update is called once per frame
    void Update()
    {

        if (!hasAuthority)
            return;

        if (Input.GetAxis("SlashTrigger") == 0)
        {
            isAxisRightInUse = false;
        }

        if (Input.GetAxis("ThrustTrigger") == 0)
        {
            isAxisLeftInUse = false;
        }


        if (!canAttack)
            return;


        if (Input.GetButtonDown("Slash") || Input.GetAxis("SlashTrigger") != 0)
        {
            if(!isAxisRightInUse && canAttack)
            {
                Debug.Log(attaqueDuCombo);
                attaqueDuCombo++;

                if (attaqueDuCombo > 2)
                {
                    attaqueDuCombo = 0;
                }

                Debug.Log(attaqueDuCombo);

                CmdTutoAttack();
                disableAttack();
                leSoundPlayer.CmdPlaySound(0);
                leAnimationController.CmdSlashAttack(attaqueDuCombo);

                isAxisRightInUse = true;

                
            }
        }
        else if ((Input.GetButtonDown("Thrust") || Input.GetAxis("ThrustTrigger") != 0) && !spellInCooldown)
        {

            if (!isAxisLeftInUse && canAttack && isOld)
            {
                attaqueDuCombo = -1;
                CmdTutoSpecial();

                spellInCooldown = true;

                wCd.StartCooldownSweap();

                disableAttack();
                leSoundPlayer.CmdPlaySound(1);
                leAnimationController.CmdSweepAttack();
                isAxisLeftInUse = true;
            }
            else if (!isAxisLeftInUse && canAttack && !isOld)
            {
                attaqueDuCombo = -1;
                CmdTutoSpecial();
                spellInCooldown = true;

                wCd.StartCooldownThrust();

                disableAttack();
                leSoundPlayer.CmdPlaySound(3);

                ThrustAttack();
                isAxisLeftInUse = true;
            }
        }
    }

    [Command]
    void CmdTutoAttack()
    {
        ObjectifManager.INSTANCE.setNbrAttackNormal();
    }

    [Command]
    void CmdTutoSpecial()
    {
        ObjectifManager.INSTANCE.setNbrSpeciaAttack();
    }

    public void rajeunir()
    {
        isOld = false;
        wCd.ChangeState(isOld);
    }

    public void vieillir()
    {
        isOld = true;
        wCd.ChangeState(isOld);
    }

    public void disableAttack()
    {
        canAttack = false;
    }

    public void enableAttack()
    {
        canAttack = true;
    }

    public void StartAttack()
    {
        if (!hasAuthority)
            return;

        canCombo = true;

        lePlayerController.disableMovement();

        if (isOld)
            Weapon.InitialiserAttack(slashDamageOld);
        else
        {
            if (attaqueDuCombo == 2)
                Weapon.InitialiserWhirlwind(slashDamageYoung);
            else
                Weapon.InitialiserAttack(slashDamageYoung);
        }
            
    }

    public void StartSweep()
    {
        if (!hasAuthority)
            return;

        lePlayerController.disableMovement();

        Weapon.InitialiserSweep(sweepDamage);
    }

    [ClientRpc]
    public void RpcEndAttack()
    {
        if (!hasAuthority)
            return;

        Weapon.StopAttack();

        lePlayerController.enableMovement();
        enableAttack();
    }

    public void EndAttack()
    {
        if (!hasAuthority)
            return;

        Weapon.StopAttack();

        lePlayerController.enableMovement();
        enableAttack();
    }

    public void EndCombo()
    {
        canCombo = false;
        attaqueDuCombo = -1;
    }

    void ThrustAttack()
    {
        if (!hasAuthority)
            return;

        leAnimationController.CmdThrustAttack();
        canAttack = false;
        lePlayerController.disableMovement();

        Weapon.InitialiserAttack(thrustDamage);

        rBody.AddForce(lePlayerController.GetForwardChar() * ForceThrustAttack, ForceMode.Impulse);

        //yield return timeDashAttack;


       /* sword.GetComponent<WarriorWeapon>().StopAttack();

        lePlayerController.enableMovement();
        canAttack = true;*/
    }

    public void StopThrust()
    {
        if (!hasAuthority)
            return;

        rBody.velocity = Vector3.zero;
    }

    public void StartPSAttaque()
    {
        if (!hasAuthority)
            return;

        leAnimationController.CmdParticleAttack(attaqueDuCombo);
    }

    public void StartPSSweep()
    {
        if (!hasAuthority)
            return;

        leAnimationController.CmdParticlSweep();
    }

    public void StartPSThrust()
    {
        if (!hasAuthority)
            return;

        leAnimationController.CmdParticlThrust();
    }

    public void StartPSLigne()
    {
        if (!hasAuthority)
            return;

        leAnimationController.CmdLigneDeVitesse();
    }

    public void StopPSLigne()
    {
        if (!hasAuthority)
            return;

        leAnimationController.CmdLigneDeVitesseStop();
    }
}
