using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class spawner : NetworkBehaviour
{

    [SerializeField]
    Transform spawnPosition;

    [SerializeField]
    GameObject Portal;

    [SerializeField]
    GameObject Poof;

    [Space(10)]
    [Header("Options Level Designer")]

    [SerializeField]
    [Tooltip("Cocher si vous voulez que ce spawner spawn des BoomBot.")]
    bool boombot;

    [SerializeField]
    [Tooltip("Cocher si vous voulez spawner des ennemies over time. default is trigger only.")]
    bool overTime;

    [SerializeField]
    float timeSpawnOvertimeMin = 10f;
    [SerializeField]
    float timeSpawnOvertimeMax = 20f;

    float timeRandom;

    [SerializeField]
    int nbrColonToSpawnOverTime = 2;

    private bool estTriggered = false;
    //teps passer entre chaque spawn quand triggered
    private float timeElapsed = 0f;
    //nombre de spawn a effectuer quand triggered
    private int spawnCompteur = 0;
    //temps entre les spawn quand triggered
    private float intervalTrigger = 1f;

    SoundPlayer monSoundPlayer;
    bool jeSuisPasPret = true;
    bool startFade = false;
    float timer = 0f;
    float timeToFade = 1f;
    float SBaseX;
    float SBaseY;
    float SBaseZ;

    bool canSpawn = true;

    private void Start()
    {
        EventManager.StartListening("EventStop", StopSpawn);
        monSoundPlayer = GetComponent<SoundPlayer>();
        SBaseX = Portal.transform.localScale.x;
        SBaseY = Portal.transform.localScale.y;
        SBaseZ = Portal.transform.localScale.z;
    }

    public void SpawnOverTime()
    {
        if (!canSpawn)
            return;

        RpcShowPortal();
        estTriggered = true;
        spawnCompteur += nbrColonToSpawnOverTime;
        timeRandom = Random.Range(timeSpawnOvertimeMin, timeSpawnOvertimeMax);
        Invoke("SpawnOverTime", timeRandom);
    }

    public void StopSpawn()
    {
        canSpawn = false;
    }

    public void TriggeredSpawn(int nbrToSpawn)
    {
        if (!canSpawn)
            return;

        RpcShowPortal();
        spawnCompteur += nbrToSpawn;
        timeElapsed = intervalTrigger;
        estTriggered = true;
    }

    private void Update()
    {
        if (!canSpawn)
            return;

        if (jeSuisPasPret)
        {

            if(ObjectifManager.INSTANCE.ready && isServer)
            {
                jeSuisPasPret = false;

                timeRandom = Random.Range(timeSpawnOvertimeMin, timeSpawnOvertimeMax);

                if (overTime)
                    Invoke("SpawnOverTime", timeRandom);
            }
        }

        if (startFade)
        {
            timer += Time.deltaTime;

            float lerp = timer / timeToFade;

            float valueScaleX = Mathf.Lerp(SBaseX, 0f, lerp);
            float valueScaleY = Mathf.Lerp(SBaseY, 0f, lerp);
            float valueScaleZ = Mathf.Lerp(SBaseZ, 0f, lerp);

            Portal.transform.localScale = new Vector3(valueScaleX, valueScaleY, valueScaleZ);

            if (valueScaleX <= 0 && valueScaleY <= 0 && valueScaleZ <= 0)
            {
                timer = 0;
                startFade = false;
                Portal.transform.localScale = new Vector3(SBaseX, SBaseY, SBaseZ);
                Portal.SetActive(false);
                monSoundPlayer.playSound(1);
                Debug.Log("allo");
            }
        }

        if (!estTriggered)
            return;

        timeElapsed += Time.deltaTime;

        if (timeElapsed >= intervalTrigger)
        {
            Spawn();
            spawnCompteur--;

            if (spawnCompteur == 0)
            {
                estTriggered = false;
                RpcHidePortal();
            }
                
            timeElapsed = 0f;           
        }
        
             
    }

    private void Spawn()
    {
        if (!canSpawn)
            return;

        if (!isServer)
            return;
        //Aller chercher un objet dans la pool

        GameObject obj;

        if (!boombot)
        {
            obj = EnemyPool.INSTANCE.GetPooledEnemy();
        }
        else
        {
            obj = EnemyPoolBoomBot.INSTANCE.GetPooledEnemy();
        }
        

        if (obj == null)
            return;

        obj.GetComponent<EntitySpawnSetup>().isActive = true;
        RpcspawnEnemyClient(obj);
        
    }

    [ClientRpc]
    void RpcspawnEnemyClient(GameObject enemy)
    {
        enemy.transform.position = spawnPosition.position;
        enemy.transform.rotation = spawnPosition.rotation;

        StartCoroutine(MyCoroutine(enemy));
        //enemy.GetComponent<EntitySpawnSetup>().InitializeEntity();
    }

    [ClientRpc]
    void RpcShowPortal()
    {
        Portal.SetActive(true);
        monSoundPlayer.playSound(0);
    }

    [ClientRpc]
    void RpcHidePortal()
    {
        StartCoroutine(DelayPortal(false));
    }

    IEnumerator MyCoroutine(GameObject enemy)
    {
        yield return new WaitForSeconds(0.9f);
            Poof.SetActive(false);
            Poof.SetActive(true);

        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<EntitySpawnSetup>().InitializeEntity();

        yield return new WaitForSeconds(0.5f);
        enemy.GetComponent<EntitySpawnSetup>().EnableSpawn();
    }

    IEnumerator DelayPortal(bool condition)
    {
        yield return new WaitForSeconds(2f);

        /*Portal.SetActive(condition);
        monSoundPlayer.playSound(1);*/

        startFade = true;

    }
}
