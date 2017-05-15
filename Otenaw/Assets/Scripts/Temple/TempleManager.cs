using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TempleManager : NetworkBehaviour {

    [SerializeField]
    GameObject templeHudPrefab;

    [SerializeField]
    Renderer meshRenderer;

    GameObject templeHud;

    [SyncVar(hook = "UpdateHud")]
    int nbrVillageoisIn;

    ObjectifManager objManager;
    TempleHud thScript;

    private void Start()
    {
        objManager = ObjectifManager.INSTANCE;
        InstancierHud();
        InitialiserHud();
    }

    void Update()
    {
        nbrVillageoisIn = objManager.nbrVillageoisSauver;
        if (meshRenderer.isVisible)
        {
            templeHud.SetActive(true);
        }
        else
        {
            templeHud.SetActive(false);
        }
    }

    public void InstancierHud()
    {
        templeHud = Instantiate(templeHudPrefab) as GameObject;
        templeHud.transform.SetParent(ObjectifManager.INSTANCE.entityCanvas.transform, false);
        thScript = templeHud.GetComponent<TempleHud>();
        templeHud.GetComponent<UpdateUiPosition>().activer(gameObject);
    }

    void InitialiserHud()
    {
        thScript.SetObjectif(objManager.nbrObjectif);
    }

    void UpdateHud(int nb)
    {
        thScript.UpdateNbrSauver(nb);
    }
}
