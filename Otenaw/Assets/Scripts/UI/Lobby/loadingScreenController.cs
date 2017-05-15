using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prototype.NetworkLobby;

public class loadingScreenController : MonoBehaviour {

    [SerializeField]
    Animator monAnim;

    [SerializeField]
    RectTransform monRectransform;

    public void ShowScreen()
    {
        monAnim.Rebind();
        LobbyManager.INSTANCE.loadingPanel.gameObject.SetActive(true);
    }

    public void HideScreen()
    {
        GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public void Desactivate()
    {
        LobbyManager.INSTANCE.loadingPanel.gameObject.SetActive(false);
    }
}
