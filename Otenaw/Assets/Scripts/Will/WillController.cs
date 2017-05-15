using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillController : MonoBehaviour
{

    [SerializeField]
    float speedMovement = 30f;
    [SerializeField]
    float forceWill = 1000f;
    [SerializeField]
    float anglePush = 0.5f;
    [SerializeField]
    float willAmount = 5;
    [SerializeField]
    GameObject attracZone;

    private bool canMove = false;
    private GameObject target;

    private SoundPlayer leSoundPlayer;


    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Spirit");
        leSoundPlayer = GetComponent<SoundPlayer>();
        Invoke("enableTrigger", 0.5f);
        Invoke("DestroyWill", 10f);
    }

    void enableTrigger()
    {
        attracZone.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (!canMove)
            return;

        if (target == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speedMovement * Time.deltaTime);
    }

    public void startMoving()
    {
        CancelInvoke();
        GetComponent<AudioSource>().Play();
        canMove = true;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
    }

    /*[ClientRpc]
    public void RpcspawnWill(float x, float z)
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(x, anglePush, z).normalized * forceWill, ForceMode.Impulse);
    }*/


    public void gainWill(GameObject spirit)
    {
        spirit.GetComponent<HealthSpirit>().CmdGainWill(willAmount);
    }

    void DestroyWill()
    {
        Destroy(gameObject);
    }
}
