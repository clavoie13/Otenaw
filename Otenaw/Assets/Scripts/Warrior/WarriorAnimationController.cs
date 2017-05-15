using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class WarriorAnimationController : NetworkBehaviour
{
    [SerializeField]
    Animator monAnimatorOld;
    [SerializeField]
    Animator monAnimatorYoung;

    [SerializeField]
    GameObject character;

    float speed;
    [SyncVar][HideInInspector]
    bool old = false;

    [SerializeField]
    GameObject OA1;

    [SerializeField]
    GameObject OA2;

    [SerializeField]
    GameObject OA3;

    [SerializeField]
    GameObject YA1;

    [SerializeField]
    GameObject YA2;

    [SerializeField]
    GameObject YA3;

    [SerializeField]
    GameObject SpecialYoung;

    [SerializeField]
    GameObject SpecialVieux;

    [SerializeField]
    GameObject LigneDeVitessePcqSaVaVite;

    GameObject lePoofSwap;
    GameObject leOA1;
    GameObject leOA2;
    GameObject leOA3;
    GameObject leYA1;
    GameObject leYA2;
    GameObject leYA3;
    GameObject leSpecialY;
    GameObject leSpecialO;

    void Start()
    {
            leOA1 = Instantiate(OA1, new Vector3(-100, -100, -100), Quaternion.identity) as GameObject;

            leOA2 = Instantiate(OA2, new Vector3(-100, -100, -100), Quaternion.identity) as GameObject;

            leOA3 = Instantiate(OA3, new Vector3(-100, -100, -100), Quaternion.identity) as GameObject;

            leYA1 = Instantiate(YA1, new Vector3(-100, -100, -100), Quaternion.identity) as GameObject;

            leYA2 = Instantiate(YA2, new Vector3(-100, -100, -100), Quaternion.identity) as GameObject;

            leYA3 = Instantiate(YA3, new Vector3(-100, -100, -100), Quaternion.identity) as GameObject;

            leSpecialY = Instantiate(SpecialYoung, new Vector3(-100, -100, -100), Quaternion.identity) as GameObject;

            leSpecialO = Instantiate(SpecialVieux, new Vector3(-100, -100, -100), Quaternion.identity) as GameObject;

            leYA1 = Instantiate(YA1, new Vector3(-100, -100, -100), Quaternion.identity) as GameObject;
    }

    [Command]
    public void CmdSlashAttack(int index)
    {
        RpcSlashAttack(index);
    }

    [Command]
    public void CmdSweepAttack()
    {
        RpcSweepAttack();
    }

    [Command]
    public void CmdThrustAttack()
    {
        RpcThrustAttack();
    }

    [Command]
    public void CmdChangeSpeed(float s)
    {
        RpcChangeSpeed(s);
    }

    [Command]
    public void CmdChangeSpeedSpell(float s)
    {
        RpcChangeSpeedSpell(s);
    }

    [Command]
    public void CmdHit()
    {
        RpcHit();
    }

    [Command]
    public void CmdParticleAttack(int index)
    {
        RpcSlashAttackPS(index);
    }

    [Command]
    public void CmdParticlSweep()
    {
        RpcSweepAttackPS();
    }

    [Command]
    public void CmdParticlThrust()
    {
        RpcThrustPS();
    }

    [Command]
    public void CmdLigneDeVitesse()
    {
        RpcLigneDeVitesse();
    }

    [Command]
    public void CmdLigneDeVitesseStop()
    {
        RpcLigneDeVitesseStop();
    }

    [Command]
    public void CmdDance()
    {
        RpcDance();
    }

    [Command]
    public void CmdDeath()
    {
        RpcDeath();
    }

    [ClientRpc]
    void RpcDance()
    {
        if (old)
        {
            monAnimatorOld.SetTrigger("Victory");
        }
        else
        {
            monAnimatorYoung.SetTrigger("Victory");
        }
    }

    [ClientRpc]
    void RpcSlashAttack(int index)
    {
        if (old)
        {
            if (index == 0)
            {
                monAnimatorOld.SetTrigger("Attack");
            }
            else if (index == 1)
            {
                monAnimatorOld.SetTrigger("Attack2");
            }
            else
            {
                monAnimatorOld.SetTrigger("Attack3");
            }
        }
        else
        {
            if (index == 0)
            {
                monAnimatorYoung.SetTrigger("Attack");
            }
            else if (index == 1)
            {
                monAnimatorYoung.SetTrigger("Attack2");
            }
            else
            {
                monAnimatorYoung.SetTrigger("Attack3");
            }
        }

    }

    [ClientRpc]
    void RpcSlashAttackPS(int index)
    {
        if (old)
        {
            if (index == 0)
            {
                leOA1.transform.position = character.transform.position;
                leOA1.transform.rotation = character.transform.rotation;
                leOA1.SetActive(false);
                leOA1.SetActive(true);
            }
            else if (index == 1)
            {
                leOA2.transform.position = character.transform.position;
                leOA2.transform.rotation = character.transform.rotation;
                leOA2.SetActive(false);
                leOA2.SetActive(true);
            }
            else
            {
                leOA3.transform.position = character.transform.position;
                leOA3.transform.rotation = character.transform.rotation;
                leOA3.SetActive(false);
                leOA3.SetActive(true);
            }
        }
        else
        {
            if (index == 0)
            {
                leYA1.transform.position = character.transform.position;
                leYA1.transform.rotation = character.transform.rotation;
                leYA1.SetActive(false);
                leYA1.SetActive(true);
            }
            else if (index == 1)
            {
                leYA2.transform.position = character.transform.position;
                leYA2.transform.rotation = character.transform.rotation;
                leYA2.SetActive(false);
                leYA2.SetActive(true);
            }
            else
            {
                leYA3.transform.position = character.transform.position;
                leYA3.transform.rotation = character.transform.rotation;
                leYA3.SetActive(false);
                leYA3.SetActive(true);
            }
        }
        
    }

    [ClientRpc]
    void RpcSweepAttack()
    {
        monAnimatorOld.SetTrigger("Sweep_Attack");
    }

    [ClientRpc]
    void RpcLigneDeVitesse()
    {
        LigneDeVitessePcqSaVaVite.SetActive(false);
        LigneDeVitessePcqSaVaVite.SetActive(true);
    }

    [ClientRpc]
    void RpcLigneDeVitesseStop()
    {
        LigneDeVitessePcqSaVaVite.SetActive(false);
    }

    [ClientRpc]
    void RpcSweepAttackPS()
    {
        leSpecialO.transform.position = character.transform.position + (Vector3.up * 1.5f);
        leSpecialO.SetActive(false);
        leSpecialO.SetActive(true);
    }

    [ClientRpc]
    void RpcThrustPS()
    {
        leSpecialY.transform.position = character.transform.position;
        leSpecialY.transform.rotation = character.transform.rotation;
        leSpecialY.SetActive(false);
        leSpecialY.SetActive(true);
    }

    [ClientRpc]
    void RpcThrustAttack()
    {
        monAnimatorYoung.SetTrigger("Thrust_Attack");
    }

    [ClientRpc]
    void RpcThrustAttackPS()
    {
        leSpecialY.transform.position = character.transform.position;
        leSpecialY.SetActive(false);
        leSpecialY.SetActive(true);
    }

    [ClientRpc]
    void RpcChangeSpeed(float s)
    {
        speed = s;

        if (old)
        {
            monAnimatorOld.SetFloat("Run_Speed", speed);
        }
        else
        {
            monAnimatorYoung.SetFloat("Run_Speed", speed);
        }
    }

    [ClientRpc]
    void RpcChangeSpeedSpell(float s)
    {
        if (old)
        {
            monAnimatorOld.SetFloat("SpeedSpell", s);
        }
        else
        {
            monAnimatorYoung.SetFloat("SpeedSpell", s);
        }
    }

    public void ChangeSpeedSpell(float s)
    {
        if (old)
        {
            monAnimatorOld.SetFloat("SpeedSpell", s);
        }
        else
        {
            monAnimatorYoung.SetFloat("SpeedSpell", s);
        }
    }

    [ClientRpc]
    void RpcHit()
    {
        if (old)
        {
            monAnimatorOld.SetTrigger("Hit");
        }
        else
        {
            monAnimatorYoung.SetTrigger("Hit");
        }
    }

    [ClientRpc]
    void RpcDeath()
    {
        if (old)
        {
            monAnimatorOld.SetTrigger("Death");
        }
        else
        {
            monAnimatorYoung.SetTrigger("Death");
        }
    }

    public void DevenirVieux()
    {
        old = true;
    }

    public void DevenirJeune()
    {
        old = false;
    }
}
