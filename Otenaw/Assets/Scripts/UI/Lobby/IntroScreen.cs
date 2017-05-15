using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Prototype.NetworkLobby;

public class IntroScreen : MonoBehaviour {

    [SerializeField]
    Button firstSelect;

    [SerializeField]
    RawImage monImage;

    [SerializeField]
    AudioSource monAudio;

    [SerializeField]
    Image noir;

    [SerializeField]
    float dureeVideo;

    GameObject musicPlayer;

    AudioSource musicPlayerAudio;

    MovieTexture maMovie;

    bool fade = false;
    bool fadeIn = false;

    float speed = 2f;

    private void Update()
    {
        if (!fade)
            return;

        if (fadeIn)
        {
            musicPlayerAudio.volume -= Time.deltaTime / speed;

            if (musicPlayerAudio.volume == 0)
                fade = false;
        }
        else
        {
            musicPlayerAudio.volume += Time.deltaTime / speed;

            if (musicPlayerAudio.volume >= 0.5f)
            {
                fade = false;
                musicPlayerAudio.volume = 0.5f;
            }
        }
    }

    //selectionner le premier bouton quand est enable
    private void OnEnable()
    {
        maMovie = monImage.mainTexture as MovieTexture;
        maMovie.loop = false;

        musicPlayer = GameObject.Find("MusicPlayer");
        musicPlayerAudio =  musicPlayer.GetComponent<AudioSource>();

        fadeIn = true;
        fade = true;

        StartCoroutine(WaitForIt());
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForEndOfFrame();
        firstSelect.Select();

        yield return new WaitForSeconds(3f);
        maMovie.Play();
        monAudio.Play();
        noir.gameObject.SetActive(false);

        yield return new WaitForSeconds(dureeVideo);
        noir.gameObject.SetActive(true);
        fadeIn = false;
        fade = true;
    }

    public void OnBackButton()
    {
        maMovie.Stop();
        monAudio.Stop();
        noir.gameObject.SetActive(true);
        musicPlayerAudio.volume = 0.5f;
        LobbyManager.INSTANCE.GoBackButton();
    }

}
