using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindColon : Rewind
{

    [SerializeField]
    bool isChronoBoomer;

    public float speed = 2f;
    public float speedAnimation = 2f;
    List<Vector3> lesTransforms;
    List<Quaternion> lesRotations;
    int index = 0;
    int indexMax = 0;

    private Colon leColon;
    private Vector3 previousPosition;
    private ColonAnimationController monAC;
    private FastForwardColon monFF;
    private Entity monEntity;

    float timeDepuisRewind = 0;

    // Use this for initialization
    void Start()
    {
        if (!isServer)
            return;

        monAC = GetComponent<ColonAnimationController>();
        monFF = GetComponent<FastForwardColon>();
        monEntity = GetComponent<Entity>();
        leColon = GetComponent<Colon>();
        lesTransforms = new List<Vector3>();
        lesRotations = new List<Quaternion>();
        InvokeRepeating("recordPosition", 0f, 0.1f);
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!entrainDeRewind)
            return;

        timeDepuisRewind += Time.deltaTime;

        if (index > indexMax)
        {
            if (timeDepuisRewind < 1f)
                return;

            timeDepuisRewind = 0;
            stopRewind();
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, lesTransforms[index], speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, lesRotations[index], speed * Time.deltaTime);


        if (transform.position == lesTransforms[index])
        {
            ++index;
        }
    }

    void recordPosition()
    {
        if (entrainDeRewind || !monEntity.isActive)
            return;

        if (transform.position == previousPosition)
            return;

        previousPosition = transform.position;
        lesTransforms.Insert(0, transform.position);
        lesRotations.Insert(0, transform.rotation);

        if (lesTransforms.Count > 40)
        {
            lesTransforms.RemoveAt(40);
            lesRotations.RemoveAt(40);
        }
    }

    public override void startRewind()
    {
        if (entrainDeRewind)
            return;

        ObjectifManager.INSTANCE.setNbrRewindNpc();

        if(monFF.entrainFF)
        {
            monFF.stopFastForward();
        }
        
        monAC.RpcStartRewind();
        index = 0;
        indexMax = lesTransforms.Count - 1;

        leColon.disableMovement();

        entrainDeRewind = true;

        //update status effect dans le ui
        RpcShowStatusEffect();

        if (isChronoBoomer)
            RpcStopTimer();

    }

    public void stopRewind()
    {
        monAC.RpcStopRewind();

        entrainDeRewind = false;

        //enlever le status effect du ui
        RpcStopStatusEffect();

        leColon.enableMovement();

        lesTransforms.Clear();
        lesRotations.Clear();
    }

    public override void clearRewind()
    {
        if (lesTransforms == null)
            return;

        lesTransforms.Clear();
        lesRotations.Clear();
    }
}
