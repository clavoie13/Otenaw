using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class chasserVillageoisBoom : chasserVillageois {

    [SerializeField]
    GameObject explosionParticule;

    GameObject laParticuleExplosion;

    SoundPlayer monSoundPlayer;

    // Use this for initialization
    void Start () {
		monRewind = GetComponent<Rewind>();
        monAC = GetComponent<ColonAnimationController>();
        objectPooler = GameObject.FindGameObjectWithTag("Pool");
        leWarrior = GameObject.FindGameObjectWithTag("Warrior");
        laParticuleExplosion = Instantiate(explosionParticule, new Vector3(-100, -100, -100), Quaternion.identity) as GameObject;

        monSoundPlayer = GetComponent<SoundPlayer>();
    }

    // Update is called once per frame
    override protected void Update()
    {
        if (!isServer)
            return;

        //Si jai pas de tipi, il faut m'en trouver un
        if (maTarget == null)
        {
            trouverTargetQuandJaiRien();
        }
        //Si ma target existe encore
        if (maTarget.GetComponent<Entity>().isActive)
        {
            //Si jai changer de target, je dois alors permet le recacul de mon chemin vers ma target
            if (jaiChangerDeTarget)
            {
                temps = 0;
            }
            else
            {
                temps += Time.deltaTime;
            }

            //Faire mon action tipi si je peux
            if (canMove == true && monRewind.entrainDeRewind == false)
            {
                actionTipi(ref temps);
            }
        }
        else
        {
            //J'ai pu de target je dois en trouver une quand meme
            prioriteGoalPresent = c_aucunePriorite;

            //Faire flasher mon champ de vision pour refaire le onTriggerEnter
            //monChampDeVision.enabled = false;
            //monChampDeVision.enabled = true;
            //trouverTargetQuandJaiRien();
            trouverTargetQuandJaiRien();
        }
    }

    public override void StartAttack()
    {
        if (!isServer)
            return;

        if (!monRewind.entrainDeRewind)
        {
            monSoundPlayer.RpcPlaySound(2);
            canAttack = false;
            stopMovement();
        }
    }

    public override void EndAttack()
    {
        if (!isServer)
            return;

        if (GetComponent<EntitySpawnSetup>().isActive == true)
        {
            if (!monRewind.entrainDeRewind)
            {
                RpcShowExplosion();

                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10f);

                int i = 0;
                while (i < hitColliders.Length)
                {
                    if (hitColliders[i].tag == "Villageois" || hitColliders[i].tag == "Tipi" || hitColliders[i].tag == "Warrior")
                    {
                        hitColliders[i].GetComponent<Health>().TakeDamage(10);
                    }

                    i++;
                }

                canAttack = true;
                GetComponent<HealthColon>().TakeDamage(10000, (transform.forward * -1));

            }
        }
    }

    public override void jaiVuQuelqueChose(Collider other)
    {
        //NE PAS EFFACER CETTE FONCTION, ON DOIT EMPECHER DE CALLER jaiVuQuelChose de la classe chasserVillageois
        Debug.Log("Je vois quelque chose en tant que colon BOOM pis je men criss");
    }

    protected override void trouverTargetQuandJaiRien()
    {
        if (!isServer)
            return;

        List<GameObject> tableauPourLesPlusProches;
        GameObject lePlusProche = null;
        float distanceDuPlusProche = Mathf.Infinity;
        float distanceDuCourant;

        //Trouver le tipi le plus proche
        if (lePlusProche == null)
        {
            tableauPourLesPlusProches = objectPooler.GetComponent<TipiActifManager>().retournerListeTipiActif();

            //Si ya des tipis sur la map, trouver le plus proche
            if (tableauPourLesPlusProches.Count > 0) //JUSTE POUR DES TESTES ICICICICICICICICICICICICICICICICICICI
            {
                foreach (GameObject tipiCourant in tableauPourLesPlusProches)
                {
                    distanceDuCourant = verifierDistance(tipiCourant.transform.position);
                    if (distanceDuCourant < distanceDuPlusProche)
                    {
                        distanceDuPlusProche = distanceDuCourant;
                        lePlusProche = tipiCourant;
                    }
                }

                //Si pendant que je cherchais le plus proche des tipi, le tipi est mort, on se met rien comme target
                if (lePlusProche != null)
                {
                    //Maintenant que jai le tipi le plus proche, je dois trouver le point le plus proche
                    lePlusProche = trouverUnePositionTipi(lePlusProche, true);

                    //Je reserve cette position la
                    lePlusProche.GetComponent<TipiPosition>().jeReserveLaPosition();
                }
                else
                {
                    Debug.Log("Le tipi le plus proche est null");
                    //prioriteGoalPresent = c_aucunePriorite;
                }
            }
            else
            {
                //Si ya pas de villageois n'y de tipi, on cherche le warrior
                //lePlusProche = leWarrior;
            }
        }

        //Assigner la nouvelle target et sa priorite
        //Je dois faire une verification, car defois en debut de game, le warrior est pas encore spawner. On veut alors que le colon fasse rien
        if (lePlusProche != null)
        {
            //prioriteGoalPresent = trouverLaPriorite(lePlusProche);
            maTarget = lePlusProche;
            jaiChangerDeTarget = true;
        }
    }

    [ClientRpc]
    void RpcShowExplosion()
    {
        laParticuleExplosion.transform.position = transform.position;
        laParticuleExplosion.SetActive(false);
        laParticuleExplosion.SetActive(true);
    }

    void OnEnable()
    {
        base.OnEnable();
    }
}
