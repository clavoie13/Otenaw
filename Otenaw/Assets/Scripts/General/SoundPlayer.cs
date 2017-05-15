using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class SoundPlayer : NetworkBehaviour {

    [SerializeField]
    AudioClip []listSoundFX;

    private AudioSource audioPlayer;

    // Use this for initialization
    void Start() {
        audioPlayer = GetComponent<AudioSource>();
	}
	
    [Command]
    public void CmdPlaySound(int index)
    {
        RpcPlaySound(index);
    }

    [ClientRpc]
    public void RpcPlaySound(int index)
    {
        audioPlayer.clip = listSoundFX[index];
        audioPlayer.Play();
    }

    public void playSound(int index)
    {
        //Je fais un autre verif du audio player car pour le feu il est tjr a null la premiere fois...
        if (audioPlayer == null)
        {
            audioPlayer = GetComponent<AudioSource>();
        }

        audioPlayer.clip = listSoundFX[index];
        audioPlayer.Play();
    }
}
