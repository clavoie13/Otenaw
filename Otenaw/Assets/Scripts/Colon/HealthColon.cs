using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HealthColon : Health {

    [SerializeField]
    bool animationHit = true;

    [SerializeField]
    GameObject willPrefab;

    [SerializeField]
    int nbrWillToSpawn = 5;

    [SerializeField]
    float forceWill = 10f;

    [SerializeField]
    float anglePush = 0.5f;

    [SerializeField]
    GameObject robotHud;

    [SerializeField]
    Renderer meshRenderer;

    public bool dead = false;

    ColonAnimationController monAC;
    Rigidbody rbody;
    private RewindColon monRewind;
    private FastForwardColon monFF;

    [SerializeField]
    GameObject monColliderMort;

    [SerializeField]
    bool isChronoBoomer;

    private SoundPlayer monSoundPlayer;
    private SlowControllerRobot monSCC;

    private void Start()
    {
        
        monAC = GetComponent<ColonAnimationController>();
        rbody = GetComponent<Rigidbody>();
        monRewind = GetComponent<RewindColon>();
        monFF = GetComponent<FastForwardColon>();
        monSCC = GetComponent<SlowControllerRobot>();

        monSoundPlayer = GetComponent<SoundPlayer>();

        InstancierHud();

        //Invoke("RpcActiverGravite", 7f);

    }

    private void Update()
    {
        if (meshRenderer == null)
            return;

        if (meshRenderer.isVisible)
        {
            robotHud.SetActive(true);
        }
        else
        {
            robotHud.SetActive(false);
        }

        //Si il est mort, alors on ajoute un force continue vers le bas (faire une gravite)
        if (dead)
        {
            rbody.AddForce(Vector3.Normalize(Vector3.down) * 0.75f, ForceMode.Impulse);
        }
    }

    public override void TakeDamage(int damage, Vector3 position)
    {
        if (!isServer)
            return;

        if(monFF.entrainFF)
            monFF.stopFastForward();

        if (monRewind.entrainDeRewind)
            monRewind.stopRewind();

        ObjectifManager.INSTANCE.nbrAttaquerRobot = true;
        currentHealth -= damage;

        //Sync le hud sur les 2 clients
        RpcSyncHud(damage);

        if (currentHealth <= 0 && !dead)
        {
            for (int i = 0; i < nbrWillToSpawn; i++)
            {
                RpcDropperDeLaWill(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

                if(isChronoBoomer)
                    GetComponent<BoomTimerController>().RpcStopTimer();
                //GameObject temp = Instantiate(willPrefab, transform.position, Quaternion.identity) as GameObject;
                //NetworkServer.Spawn(temp);
                //temp.GetComponent<WillController>().RpcspawnWill(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            }

            currentHealth = health;
            GetComponent<chasserVillageois>().stopEverything();
            //GetComponent<Colon>().disableMovement();
            monAC.RpcDeath();
            dead = true;

            RpcActiverGravite(position);
            monSoundPlayer.RpcPlaySound(0);


            StartCoroutine(delayDeath());
            return;
        }

        if (animationHit)
        {
            GetComponent<chasserVillageois>().stopEverything();
            monAC.RpcHit();
            


            rbody.drag = 0;
            rbody.AddForce(Vector3.Normalize(position) * 10f, ForceMode.Impulse);
            StartCoroutine(delaisPush());
        }

        monSoundPlayer.RpcPlaySound(1);

    }

    [ClientRpc]
    void RpcDropperDeLaWill(float x, float z)
    {
        GameObject temp = Instantiate(willPrefab, transform.position, Quaternion.identity) as GameObject;
        temp.GetComponent<Rigidbody>().AddForce(new Vector3(x, anglePush, z).normalized * forceWill, ForceMode.Impulse);
    }

    [ClientRpc]
    void RpcActiverGravite(Vector3 position)
    {

        dead = true;
        GetComponent<NetworkTransform>().transformSyncMode = NetworkTransform.TransformSyncMode.SyncNone;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;

        rbody.drag = 0;
        rbody.useGravity = true;
        rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        rbody.AddForce(Vector3.Normalize(new Vector3(position.x, 2f, position.z)) * 20f, ForceMode.Impulse);


        //Activer le collider mort
        StartCoroutine(RpcDelayCollider());

    }

    [ClientRpc]
    void RpcEnleverGravite()
    {
        //rbody.useGravity = false;
       rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
       // GetComponent<NetworkTransform>().transformSyncMode = NetworkTransform.TransformSyncMode.SyncRigidbody3D;
    }

    IEnumerator delayDeath()
    {

        yield return new WaitForSeconds(5.5f);

        killColon();
    }

    IEnumerator RpcDelayCollider()
    {
        yield return new WaitForSeconds(0.1f);

        monColliderMort.SetActive(true);
    }

    IEnumerator delaisPush()
    {
        yield return new WaitForSeconds(0.1f);

        rbody.drag = 100;
             
    }

    public void killColon()
    {
        //Sync s'il est mort
        monAC.RpcRespawn();
        dead = false;
        RpcEnleverGravite();
        rbody.velocity = Vector3.zero;
        rbody.drag = 100;

        //Desactiver le materiel du collider
        RpcDesactiverCollider();

        RpcSyncActive();
        monAC.RpcResetAnimator();
        monRewind.clearRewind();
        monSCC.removeAllBou();
    }

    [ClientRpc]
    void RpcDesactiverCollider ()
    {
        monColliderMort.SetActive(false);
    }

    public void InstancierHud()
    {
        robotHud = Instantiate(robotHud) as GameObject;
        robotHud.transform.SetParent(ObjectifManager.INSTANCE.entityCanvas.transform, false);

        maHealthBar = robotHud.GetComponent<NpcHealthBar>();
        maHealthBar.Initisalisation(health, currentHealth);

        if(isChronoBoomer)
        {
            GetComponent<BoomTimerController>().Initialiser(robotHud.GetComponent<BoomerHud>());
        }

        robotHud.GetComponent<UpdateUiPosition>().activer(gameObject);
    }

}
