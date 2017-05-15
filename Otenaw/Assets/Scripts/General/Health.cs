using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class Health : NetworkBehaviour {

    public int health = 1;

    protected int currentHealth;

    [HideInInspector]
    public NpcHealthBar maHealthBar;

    // Use this for initialization
    void Start () {
        currentHealth = health;
	}

    public virtual void TakeDamage(int damage)
    {
    }

    public virtual void TakeDamage(int damage, Vector3 position)
    {
    }

    [ClientRpc]
    protected void RpcSyncHud(int damage)
    {
        maHealthBar.LoseLife(damage);
    }

    [ClientRpc]
    protected virtual void RpcSyncActive()
    {
        gameObject.GetComponent<EntitySpawnSetup>().DisableEntity();
    }

    protected virtual void OnEnable()
    {
        currentHealth = health;

        if (maHealthBar == null)
            return;  
        maHealthBar.Initisalisation(health, currentHealth);
    }

    protected virtual void OnDisable()
    {
        if (maHealthBar == null)
            return;

        maHealthBar.hideBar();
    }

}
