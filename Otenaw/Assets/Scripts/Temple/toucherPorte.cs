using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class toucherPorte : NetworkBehaviour {

    private SoundPlayer monSoundPlayer;
    private AudioSource monAudioSource;

    void Start()
    {
        monSoundPlayer = GetComponent<SoundPlayer>();
        monAudioSource = GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (!isServer)
            return;

        if (other.tag == "Villageois")
        {
            //Desactiver le villageois
            RpcDisableVillageois(other.gameObject);
            RpcChangerPitch();
            monSoundPlayer.RpcPlaySound(0);
            ObjectifManager.INSTANCE.SauverVillageois();
        }
    }

    [ClientRpc]
    void RpcChangerPitch()
    {
        monAudioSource.pitch = Random.Range(1, 1.5f);
    }

    [ClientRpc]
    void RpcDisableVillageois(GameObject villageois)
    {
        //villageois.GetComponent<EntitySpawnSetup>().isActive = false;
        //Si le villageois a un sous objectif a declencher
        if (villageois.GetComponent<sousObjectif>() != null)
        {
            villageois.gameObject.GetComponent<sousObjectif>().activerSO();
        }

        villageois.GetComponent<EntitySpawnSetup>().DisableEntity();

    }

}
