using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WarriorMiniHudController : NetworkBehaviour {

    [SerializeField]
    GameObject warriorMiniHud;

    [SerializeField]
    Renderer oldRenderer;

    [SerializeField]
    Renderer youngRenderer;

    InteractionTipi iTipi;

    // Use this for initialization
    void Start () {
        InstancierHud();
    }
	
	// Update is called once per frame
	void Update () {
        if (oldRenderer.isVisible || youngRenderer.isVisible)
        {
            warriorMiniHud.SetActive(true);
        }
        else
        {
            warriorMiniHud.SetActive(false);
        }
    }

    void InstancierHud()
    {
        warriorMiniHud = Instantiate(warriorMiniHud) as GameObject;
        warriorMiniHud.transform.SetParent(ObjectifManager.INSTANCE.entityCanvas.transform, false);

        GetComponent<WarriorHealth>().InitialiserMiniHB(warriorMiniHud.GetComponent<MiniNewHealthBar>(), warriorMiniHud.GetComponent<NpcStatusBar>());

        iTipi = warriorMiniHud.GetComponent<InteractionTipi>();

        warriorMiniHud.GetComponent<UpdateUiPosition>().activer(gameObject);
    }

    public InteractionTipi GetITipi()
    {
        return iTipi;
    }

    public void ReleaseVillageois(GameObject leTipi)
    {
        CmdRealeseVillagers(leTipi);
    }

    [Command]
    public void CmdRealeseVillagers(GameObject leTipi)
    {
        Debug.Log("CmdReleaseVillagers");
        if (leTipi.GetComponent<TipiManager>().nbrVillageois < 1)
            return;

        leTipi.GetComponent<TipiManager>().ReleaseVillager();
        //GetComponent<TipiJellyShot>().CmdStartJelly();
    }
}
