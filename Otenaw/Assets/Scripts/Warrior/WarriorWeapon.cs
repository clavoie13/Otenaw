using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using XInputDotNetPure;

public class WarriorWeapon : NetworkBehaviour {

    [SerializeField]
    BoxCollider boxCollider;

    [SerializeField]
    SphereCollider sphereCollider;

    [SerializeField]
    SphereCollider smalSphereCollider;

    int damage;
    bool sweep = false;
    bool whirlWind = false;
    bool slash = false;

    void Update()
    {
        Debug.Log(slash);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (!isServer)
            return;

        Debug.Log(other.name);

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log(sweep);
            Debug.Log(whirlWind);
            

            if (sweep)
            {
                CmdTakeDamageSweap(other.gameObject, damage, other.gameObject.transform.position - sphereCollider.transform.position);
                //other.GetComponent<Health>().TakeDamage(damage, other.gameObject.transform.position - transform.position);
                XInputDotNetPure.GamePad.SetVibration(PlayerIndex.One, 0.15f, 0.15f);

            }
            else if(whirlWind)
            {
                CmdTakeDamage(other.gameObject, damage, other.gameObject.transform.position - smalSphereCollider.transform.position);
                XInputDotNetPure.GamePad.SetVibration(PlayerIndex.One, 0.15f, 0.15f);

                //other.GetComponent<Health>().TakeDamage(damage, transform.forward);
            }
            else if(slash)
            {
                CmdTakeDamage(other.gameObject, damage, boxCollider.transform.forward);
                XInputDotNetPure.GamePad.SetVibration(PlayerIndex.One, 0.15f, 0.15f);

                //other.GetComponent<Health>().TakeDamage(damage, transform.forward);
            }

            /*if (!hasAuthority)
                return;*/

            //XInputDotNetPure.GamePad.SetVibration(PlayerIndex.One, 0.15f, 0.15f);
        }
    }

    public void InitialiserAttack(int dmg)
    {
        sweep = false;
        whirlWind = false;
        slash = true;

        damage = dmg;
        boxCollider.enabled = true;
    }

    public void InitialiserSweep(int dmg)
    {
        sweep = true;
        whirlWind = false;
        slash = false;

        damage = dmg;
        sphereCollider.enabled = true;
    }

    public void InitialiserWhirlwind(int dmg)
    {
        sweep = false;
        whirlWind = true;
        slash = false;

        damage = dmg;
        smalSphereCollider.enabled = true;
    }

    public void StopAttack()
    {
        Debug.Log("StopAttack");
        boxCollider.enabled = false;
        sphereCollider.enabled = false;
        smalSphereCollider.enabled = false;

        sweep = false;
        whirlWind = false;
        slash = false;

        if (!hasAuthority)
            return;

        XInputDotNetPure.GamePad.SetVibration(PlayerIndex.One, 0f, 0f);

    }

    [Command]
    void CmdTakeDamage(GameObject ennemi, int damage, Vector3 bonjour)
    {
        ennemi.GetComponent<Health>().TakeDamage(damage, bonjour);
    }

    [Command]
    void CmdTakeDamageSweap(GameObject ennemi, int damage, Vector3 bonjour)
    {
        Debug.Log("CmdTakeDamage");
        ennemi.GetComponent<Health>().TakeDamage(damage, bonjour);
    }
}
