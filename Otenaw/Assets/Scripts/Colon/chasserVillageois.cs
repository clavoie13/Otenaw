using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class chasserVillageois : NetworkBehaviour
{

    protected const int c_aucunePriorite = -1;

    [SerializeField]
    protected GameObject hitBox;

    [SerializeField]
    protected int degat;
    protected GameObject maTarget;
    protected UnityEngine.AI.NavMeshAgent agent;

    [SerializeField]
    protected float cooldownAnimationAttack;

    protected enum prioriteGoalLoin { tipi, joueur, villageois };

    public int prioriteGoalPresent = c_aucunePriorite;

    protected bool canAttack = true;
    protected bool canMove = true;

    protected Rewind monRewind;
    protected ColonAnimationController monAC;

    protected GameObject objectPooler;
    protected GameObject leWarrior;

    [SerializeField]
    protected SphereCollider monChampDeVision;

    //On prend cette vitesse de rotation quand le colon est trop proche de la target pour continuer a avancer mais pas dans le bonne angle
    protected float rotationSpeed = 5f;

    protected float temps;

    protected bool jaiChangerDeTarget = false;

    void Start()
    {
        monRewind = GetComponent<Rewind>();
        monAC = GetComponent<ColonAnimationController>();
        objectPooler = GameObject.FindGameObjectWithTag("Pool");
        leWarrior = GameObject.FindGameObjectWithTag("Warrior");
    }

    //Fonction pour initialiser la chasse
    public void initialize()
    {
        if (!isServer)
            return;

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.enabled = true;

    }

    //
    protected void EventStop()
    {
        if (!isServer)
            return;

        stopEverything();

        monAC.RpcDesactivate();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!isServer)
            return;

        //Si j'ai une target
        if (prioriteGoalPresent > c_aucunePriorite)
        {
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

                if (canMove == true && monRewind.entrainDeRewind == false)
                {
                    //Faire des actions selon mon type de target
                    switch (prioriteGoalPresent)
                    {
                        case (int)prioriteGoalLoin.villageois:
                            actionVillageois(ref temps);
                            break;

                        case (int)prioriteGoalLoin.tipi:
                            actionTipi(ref temps);
                            break;

                        case (int)prioriteGoalLoin.joueur:
                            actionWarrior(ref temps);
                            break;

                        default:
                            break;
                    }
                }
            }
            else
            {
                //J'ai pu de target je dois en trouver une quand meme
                prioriteGoalPresent = c_aucunePriorite;

                //Faire flasher mon champ de vision pour refaire le onTriggerEnter
                monChampDeVision.enabled = false;
                monChampDeVision.enabled = true;
                //trouverTargetQuandJaiRien();
            }
        }
        else
        {
            //J'ai pu de target je dois en trouver une quand meme
            trouverTargetQuandJaiRien();
        }
    }

    //Action a faire quand ma target est un Tipi
    protected void actionTipi(ref float temps)
    {
        if (jaiChangerDeTarget || agent.hasPath == false || temps >= 0.2)
        {
            jaiChangerDeTarget = false;
            temps = 0f;

            //Aller vers ma target
            agent.SetDestination(maTarget.transform.position);
            agent.stoppingDistance = 0.5f;
        }

        if (canAttack && canMove)
        {
            //Si je suis assez proche et face a ma target, j'attaque
            if (Vector3.Distance(this.transform.position, maTarget.transform.position) < 1.5f)
            {
                Vector3 positionDuTipi = maTarget.transform.parent.position;

                if (Vector3.Angle(positionDuTipi - this.transform.position, this.transform.forward) < 15)
                {
                    monAC.RpcAttack();
                    canAttack = false;
                }
                else
                {
                    Vector3 direction = (positionDuTipi - transform.position).normalized;
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
                }
            }
        }
    }

    //Action a faire quand ma target est un Tipi
    protected void actionVillageois(ref float temps)
    {
        //Aller vers ma target
        if (jaiChangerDeTarget || temps >= 0.2)
        {
            agent.SetDestination(maTarget.transform.position);
            jaiChangerDeTarget = false;
            agent.stoppingDistance = 1.5f;

        }

        if (canAttack && canMove)
        {
            //Si je suis assez proche et face a ma target, j'attaque
            if (Vector3.Distance(this.transform.position, maTarget.transform.position) < 2.5)
            {
                if (Vector3.Angle(maTarget.transform.position - this.transform.position, this.transform.forward) < 45)
                {
                    monAC.RpcAttack();
                    canAttack = false;

                }
                else
                {
                    Vector3 direction = (maTarget.transform.position - transform.position).normalized;
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
                }
            }
        }
    }

    //Action a faire quand ma target le warrior
    protected void actionWarrior(ref float temps)
    {
        //Aller vers ma target
        if (jaiChangerDeTarget || temps >= 0.2f)
        {
            agent.SetDestination(maTarget.transform.position);
            jaiChangerDeTarget = false;
            agent.stoppingDistance = 1.7f;
            temps = 0f;
        }

        if (canAttack && canMove)
        {
            //Si je suis assez proche et face a ma target, j'attaque calasse
            if (Vector3.Distance(this.transform.position, maTarget.transform.position) < 2.5)
            {
                if (Vector3.Angle(maTarget.transform.position - this.transform.position, this.transform.forward) < 45)
                {
                   monAC.RpcAttack();
                   canAttack = false;

                }
                else
                {
                    Vector3 direction = (maTarget.transform.position - transform.position).normalized;
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
                }
            }
        }
    }

    //Quand mon champ de vision a vu de quoi d'interessant (Je pense que je pourrais le desactivier si je poursuie un villageois)
    public virtual void jaiVuQuelqueChose(Collider other)
    {
        if (!isServer)
            return;

        int prioriteDetecter = c_aucunePriorite;

        prioriteDetecter = trouverLaPriorite(other.gameObject);

        //Si la priorite detecte est meilleur que la prio courante, on change de target
        if (comparerPriorite(prioriteGoalPresent, prioriteDetecter))
        {
            //Avant de changer, je verifie si c'est un tipi, si oui je dois confirmer qu'il reste de la place
            if (other.tag == "Tipi")
            {
                GameObject positionTipi = trouverUnePositionTipi(other.gameObject, false);
                if (positionTipi != null)
                {
                    maTarget = positionTipi;

                    //Je reserve cette position la
                    positionTipi.GetComponent<TipiPosition>().jeReserveLaPosition();
                    prioriteGoalPresent = prioriteDetecter;
                }
            }
            else
            {
                //Si jai deja une target
                if (maTarget != null)
                {
                    //Si ma target est une position tipi
                    if (maTarget.tag == "PositionTipi")
                    {
                        maTarget.GetComponent<TipiPosition>().jeLibereLaPoisition();
                    }
                }

                maTarget = other.gameObject;
                prioriteGoalPresent = prioriteDetecter;
                jaiChangerDeTarget = true;
            }
        }
    }

    //Fonction pour trouver la priorite de ma target
    protected int trouverLaPriorite(GameObject aIdentifier)
    {
        int prioriteDetecter = c_aucunePriorite;

        if (aIdentifier.tag == "Villageois")
        {
            prioriteDetecter = (int)prioriteGoalLoin.villageois;
        }
        else
        {
            if (aIdentifier.tag == "Tipi" || aIdentifier.tag == "PositionTipi")
            {
                prioriteDetecter = (int)prioriteGoalLoin.tipi;
            }
            else
            {
                if (aIdentifier.tag == "Warrior")
                {
                    prioriteDetecter = (int)prioriteGoalLoin.joueur;
                }
            }
        }

        return prioriteDetecter;
    }

    public void stopEverything()
    {
        stopMovement();
        hitBox.GetComponent<ColonWeapon>().StopAttack();
        monAC.RpcResetAnimator();

    }

    public void stopMovement()
    {
        
        agent.velocity = Vector3.zero;
        agent.Stop();
        canMove = false;
    }

    public void resumetMovment()
    {
        if (!isServer)
            return;

        canAttack = true;
        canMove = true;
        agent.ResetPath();
        agent.Resume();
    }

    public void changeSpeed(float speed)
    {
        if (!isServer)
            return;

        agent.speed = speed;
    }

    //Fonction pour comparer les priorites
    protected bool comparerPriorite(int prioCourant, int prioDetecte)
    {
        if (prioDetecte > prioCourant)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Fonction pour trouver un objectif quand j'ai rien dans mon champ de vision
    protected virtual void trouverTargetQuandJaiRien()
    {
        if (!isServer)
            return;

        List<GameObject> tableauPourLesPlusProches;
        GameObject lePlusProche = null;
        float distanceDuPlusProche = Mathf.Infinity;
        float distanceDuCourant;

        tableauPourLesPlusProches = objectPooler.GetComponent<VillageoisActifManager>().retournerListeVillageoisActif();

        //Si ya des villageois de spawner, trouver le plus proche
        if (tableauPourLesPlusProches.Count > 0)
        {
            foreach (GameObject villageoisCourant in tableauPourLesPlusProches)
            {
                if (villageoisCourant.GetComponent<EntitySpawnSetup>().isActive)
                {
                    distanceDuCourant = verifierDistance(villageoisCourant.transform.position);
                    if (distanceDuCourant < distanceDuPlusProche)
                    {
                        distanceDuPlusProche = distanceDuCourant;
                        lePlusProche = villageoisCourant;
                    }
                }
            }
        }

        //Si nous n'avons pas trouve de villageois actif
        if(lePlusProche == null)
        {
            tableauPourLesPlusProches.Clear();

            //Si ya pas de villageois actif sur la map, on cherche le tipi le plus proche
            //tableauPourLesPlusProches = objectPooler.GetComponent<TipiActifManager>().retournerListeTipiActif();

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
                    prioriteGoalPresent = c_aucunePriorite;
                }
            }
            else
            {
                //Si ya pas de villageois n'y de tipi, on cherche le warrior
                lePlusProche = leWarrior;
            }
        }

        //Assigner la nouvelle target et sa priorite
        //Je dois faire une verification, car defois en debut de game, le warrior est pas encore spawner. On veut alors que le colon fasse rien
        if (lePlusProche != null)
        {
            prioriteGoalPresent = trouverLaPriorite(lePlusProche);
            maTarget = lePlusProche;
            jaiChangerDeTarget = true;
        }
    }

    //Pour trouver la distance entre le colon et l'objet detecte
    protected float verifierDistance(Vector3 position)
    {
        float distance = Mathf.Infinity;

        //Verifier la distance a vol d'oiseau
        distance = Vector3.Distance(transform.position, position);

        return distance;

        //Vielle partie de code qui ne fonctionne pas car entre le setDestination et le calcul du path il y a trop de temps
        /*agent.SetDestination(position);

        //Si un chemin existe
        if (agent.CalculatePath(position, agent.path) == true)
        {
            if (agent.pathStatus != UnityEngine.AI.NavMeshPathStatus.PathInvalid)
            {
                distance = agent.remainingDistance;
            }
            //ICIICICICICICICICICICI Je dois reset la destination 
        }

        return distance;*/
    }

    public virtual void StartAttack()
    {
        if (!isServer)
            return;

        if (!monRewind.entrainDeRewind)
        {
            canAttack = false;
            stopMovement();

            hitBox.GetComponent<ColonWeapon>().InitialiserAttack(degat);
        }
    }

    public virtual void EndAttack()
    {
        if (!isServer)
            return;

        hitBox.GetComponent<ColonWeapon>().StopAttack();

        if (GetComponent<EntitySpawnSetup>().isActive == true)
        {
            if (!monRewind.entrainDeRewind)
            {
                resumetMovment();
            }

            canAttack = true;
        }
    }

    /*IEnumerator Attack()
    {
        canAttack = false;
        stopMovement();

        hitbox.GetComponent<ColonWeapon>().InitialiserAttack(degat);
        sword.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);


        yield return new WaitForSeconds(cooldownAnimationAttack);


        sword.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        hitbox.GetComponent<ColonWeapon>().StopAttack();

        if (!monRewind.entrainDeRewind && monEntity.isActive) //Si je suis mort pendant ma coroutine je ne dois pas resume mes mouvements
        {
            resumetMovment();
        }

        canAttack = true;
    }*/

    protected GameObject trouverUnePositionTipi(GameObject leTipi, bool pourTest)
    {
        //SEULEMENT POUR DEBUGGER LE PROBLEME DE LARENA
        if (leTipi == null)
        {
            if (pourTest)
            {
                Debug.Log("Trouver quelque chose");
            }
            else
            {
                Debug.Log("Jai vu quelque chose");
            }

        }

        List<GameObject> lesPositions = leTipi.GetComponent<TipiPositionManager>().trouverPositionLibre();

        float distancePlusCourteCourante = Mathf.Infinity;
        float distanceCourante = Mathf.Infinity;

        int indexPlusProche = -1;

        if (lesPositions.Count != 0)
        {
            for (int i = 0; i < lesPositions.Count; i++)
            {
                distanceCourante = verifierDistance(lesPositions[i].transform.position);


                if (distanceCourante < distancePlusCourteCourante)
                {
                    distancePlusCourteCourante = distanceCourante;

                    indexPlusProche = i;
                }
            }

            if (indexPlusProche == -1)
            {
                return null;
            }
            else
            {
                return lesPositions[indexPlusProche];
            }
        }
        else
        {
            return null;
        }
    }

    protected void libereTarget()
    {
        if (maTarget != null)
        {
            if (maTarget.GetComponent<TipiPosition>() != null)
            {
                maTarget.GetComponent<TipiPosition>().jeLibereLaPoisition();
            }
        }
    }

    protected void OnDisable()
    {
        libereTarget();
        EventManager.StopListening("EventStop", EventStop);
    }

    protected void OnEnable()
    {
        canAttack = true;
        canMove = true;
        hitBox.GetComponent<ColonWeapon>().StopAttack();
        EventManager.StartListening("EventStop", EventStop);
    }

}
