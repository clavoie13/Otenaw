using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonWeapon : MonoBehaviour {

    int damage;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Villageois" || other.gameObject.tag == "Tipi" || other.gameObject.tag == "Warrior")
        {
            other.GetComponent<Health>().TakeDamage(damage);
            GetComponentInParent<SoundPlayer>().RpcPlaySound(2);
        }
    }

    public void InitialiserAttack(int dmg)
    {
        damage = dmg;
        GetComponent<Collider>().enabled = true;
    }

    public void StopAttack()
    {
        GetComponent<Collider>().enabled = false;
    }
}
