using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prototype.NetworkLobby;

public class EndGameController : MonoBehaviour {

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip otenawVictory;

    bool fadeMusic = false;
    bool fadeIn = false;

    float speedIn = 5f;
    float speed = 2.5f;

    private void Update()
    {
        if (!fadeMusic)
            return;

        if(!fadeIn)
        {
            audioSource.volume -= Time.deltaTime / speedIn;
            if(audioSource.volume == 0)
            {
                audioSource.Stop();
                fadeIn = true;
            }
        }
        else
        {
            audioSource.volume += Time.deltaTime / speed;
            if (audioSource.volume >= 0.5f)
            {
                audioSource.volume = 0.5f;
                audioSource.clip = otenawVictory;
                audioSource.loop = false;
                audioSource.Play();
                fadeMusic = false;
            }
        }
    }

    public void TerminerLeJeu()
    {
        LobbyManager.INSTANCE.GoBackButton();
    }


    public void SetFade()
    {
        fadeMusic = true;
    }

}
