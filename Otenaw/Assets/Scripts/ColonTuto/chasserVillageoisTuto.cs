using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class chasserVillageoisTuto : NetworkBehaviour
{

    const int c_aucunePriorite = -1;

    [SerializeField] GameObject hitBox;
    [SerializeField] int degat;
    [SerializeField] GameObject maTarget;
    UnityEngine.AI.NavMeshAgent agent;

    [SerializeField] float cooldownAnimationAttack;


    bool canAttack = true;
    bool canMove = true;

    Rewind monRewind;
    ColonAnimationController monAC;

    //On prend cette vitesse de rotation quand le colon est trop proche de la target pour continuer a avancer mais pas dans le bonne angle
    float rotationSpeed = 5f;

    //Fonction pour initialiser la chasse
    public void initialize()
    {
        if (!isServer)
            return;

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.enabled = true;

    }

    void Start()
    {
        monRewind = GetComponent<Rewind>();
        monAC = GetComponent<ColonAnimationController>();
    }


    // Update is called once per frame
    void Update () {

        if (!isServer)
            return;

        //Si ma target existe encore
        if (maTarget.GetComponent<Entity>().isActive)
        {
            //Aller vers ma target
            agent.SetDestination(maTarget.transform.position);

            if (canAttack && canMove)
            {
                //Si je suis assez proche et face a ma target, j'attaque
                if (Vector3.Distance(this.transform.position, maTarget.transform.position) < 2.5)
                {
                    if (Vector3.Angle(maTarget.transform.position - this.transform.position, this.transform.forward) < 45)
                    {
                        monAC.RpcAttack();
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
        else
        {
           //Le villageois est save, aller vers le warrior
           maTarget = GameObject.FindGameObjectWithTag("Warrior");
            Debug.Log(maTarget.name);
        }

    }

    public void stopMovement()
    {
        agent.velocity = Vector3.zero;
        canMove = false;
        agent.Stop();
    }

    public void resumetMovment()
    {
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

    public void StartAttack()
    {
        canAttack = false;
        stopMovement();

        hitBox.GetComponent<ColonWeapon>().InitialiserAttack(degat);
    }

    public void EndAttack()
    {
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

        sword.GetComponent<ColonWeapon>().InitialiserAttack(degat);
        sword.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);


        yield return new WaitForSeconds(cooldownAnimationAttack);


        sword.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        sword.GetComponent<ColonWeapon>().StopAttack();

        if (!monRewind.entrainDeRewind && monEntity.isActive) //Si je suis mort pendant ma coroutine je ne dois pas resume mes mouvements)
        {
            resumetMovment();
        }

        canAttack = true;
    }*/
}
