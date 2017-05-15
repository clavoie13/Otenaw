using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class TipiManager : NetworkBehaviour {

    [SerializeField]
    Transform spawnPoint;

    GameObject tipiHud;
    UIVillageoisDansTipi villTipiHud;

    float delaySpawn = 0;

    [SyncVar][HideInInspector]
    public float currentTime = 0;

    [SyncVar(hook = "UpdateSecond")]
    [HideInInspector]
    int currentSecond = 0;

    [Header("Customizer la distance entre villageois qui sorte")]
    [SerializeField]
    float intervalSpawn = 1.5f;

    [Header("Spawner Robots")]
    [SerializeField]
    [Tooltip("Liste des spawner a etre affecter par ce trigger")]
    GameObject[] tableauSpawners;

    [SerializeField]
    [Tooltip("Inscrire le nombre de robot a spawner pour le spawner au meme index que le tableau des spawner.")]
    int[] tableauNbrRobotDuSpawn;

    [Header("Customizer le tipi")]
    [SyncVar(hook = "UpdateNbrVillageois")]
    public int nbrVillageois;

    private int counterSpawn;

    
    bool genererOverTime;

    [Header("Pour generer des villageois over time dans le tipi !")]
    [SerializeField]
    float timeBetweenGen;

    [SerializeField]
    GameObject monFeuWowWowPowPow;

    [SerializeField]
    GameObject TipiNormal;

    [SerializeField]
    GameObject TipiFeu;

    [SerializeField]
    GameObject BoomTipi;


    public int nbrMaxVillageois = 5;

    private SoundPlayer monSoundPlayer;


    // Use this for initialization
    void Start () {

        monSoundPlayer = GetComponent<SoundPlayer>();

        counterSpawn = nbrVillageois;

        //Verification si le tipi spawn des villageois
        if (nbrMaxVillageois > 0)
        {
            monFeuWowWowPowPow.SetActive(false);
        }
        else
        {
            //Le tipi est un tipi qui ne spawn pas de villageois, donc il est mort
            //TipiMort();
        }

    }

    public void InitialiserHud(GameObject hud)
    {
        tipiHud = hud;
        //tipiHud.GetComponentInChildren<VillageoisDansTipi>().Initialiser(nbrVillageois, nbrMaxVillageois);
        //tipiHud.GetComponent<Horloge>().Initialiser(timeBetweenGen, this);
        villTipiHud = tipiHud. GetComponent<UIVillageoisDansTipi>();

        villTipiHud.Initialiser(nbrMaxVillageois, nbrVillageois, timeBetweenGen, this);

        if (nbrVillageois < nbrMaxVillageois)
        {
            genererOverTime = true;
        }
        else
        {
            tipiHud.GetComponent<Horloge>().SetMax();
            genererOverTime = false;
        }     
    }

    //Quand le warrior release les villageois d'un tipi

    public void ReleaseVillager()
    {
        if (nbrVillageois == 0)
            return;

        monSoundPlayer.CmdPlaySound(1);

        ObjectifManager.INSTANCE.setNbrOuvertTipi();

        counterSpawn = nbrVillageois;
        nbrVillageois = 0;
        genererOverTime = true;

        InvokeRepeating("Spawn", delaySpawn, intervalSpawn);

        for (int i = 0; i < tableauSpawners.Length; i++)
        {
            ActiverSpawner(i);
        }    
    }

    private void ActiverSpawner(int i)
    {
        if (i >= tableauNbrRobotDuSpawn.Length)
        {
            int j = 0;
            tableauSpawners[i].GetComponent<spawner>().TriggeredSpawn(tableauNbrRobotDuSpawn[j]);
        }
        else
        {
            tableauSpawners[i].GetComponent<spawner>().TriggeredSpawn(tableauNbrRobotDuSpawn[i]);
        }
    }

    void UpdateNbrVillageois(int value)
    {
        //tipiHud.GetComponentInChildren<VillageoisDansTipi>().UpdateVillageois(value);
        villTipiHud.UpdateVillageois(value);
    }
    

    //Fonction pour spawner le villageois
    private void Spawn()
    {
        if(counterSpawn == 0)
        {
            CancelInvoke();
            genererOverTime = true;
            return;
        }

        GameObject obj = VillageoisPool.INSTANCE.GetPooledVillageois();

        if (obj == null)
            return;

        RpcspawnVillageoisClient(obj);

        counterSpawn--;
    }

    [ClientRpc]
    void RpcspawnVillageoisClient(GameObject villageois)
    {
        villageois.transform.position = spawnPoint.position;
        villageois.transform.rotation = spawnPoint.rotation;

        StartCoroutine(MyCoroutine(villageois));
        //villageois.GetComponent<EntitySpawnSetup>().InitializeEntity();      
    }

    IEnumerator MyCoroutine(GameObject villageois)
    {
        yield return new WaitForSeconds(0.5f);

        villageois.GetComponent<EntitySpawnSetup>().InitializeEntity();
    }

    //pour gen des villageois
    public void AddVillageois ()
    {
        nbrVillageois += 1;
        GetComponent<TipiJellyShot>().RpcStartJelly();
        if (nbrVillageois >= nbrMaxVillageois)
        {
            //RpcSetMax();
            genererOverTime = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isServer)
            return;

        if (!genererOverTime)
            return;

        currentTime += Time.deltaTime;

        currentSecond = Mathf.CeilToInt(timeBetweenGen - currentTime);

        if (currentTime >= timeBetweenGen)
        {
            currentTime = 0;
            currentSecond = (int)timeBetweenGen;
            AddVillageois();
        }     
    }

    [ClientRpc]
    void RpcSetMax()
    {
        //tipiHud.GetComponent<Horloge>().SetMax();
    }

    void UpdateSecond(int cur)
    {
        tipiHud.GetComponent<Horloge>().UpdateCoutdown(cur.ToString());
    }

    public void TipiMort()
    {
        //Enlever mon tag pour etre certain que les colons ne viennent pas attaquer un tipi mort
        tag = "Untagged";

        //Desactiver mes positions
        GetComponent<TipiPositionManager>().desactiverTousLesPositions();

        //Call les OnDisable de mes components
        gameObject.GetComponent<EntitySpawnSetup>().DisableTipiEntity();

        monFeuWowWowPowPow.SetActive(true);
        TipiNormal.SetActive(false);
        TipiFeu.SetActive(true);

        BoomTipi.SetActive(false);
        BoomTipi.SetActive(true);



        monFeuWowWowPowPow.GetComponent<FeuSons>().Son();



    }

    private void OnDisable()
    {
    }
}
