using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForwardColon : FastForward
{

    public float multiplicationSpeed = 2f;
    public float dureFastForward = 2f;


    public bool entrainFF = false;
    private Colon leColon;
    private ColonAnimationController monAC;
    private RewindColon monRC;
    float timeDepuisRewind = 0;


    // Use this for initialization
    void Start()
    {
        leColon = GetComponent<Colon>();
        monAC = GetComponent<ColonAnimationController>();
        monRC = GetComponent<RewindColon>();
    }

    void Update()
    {
        if (!entrainFF)
            return;

        timeDepuisRewind += Time.deltaTime;


        if (timeDepuisRewind < dureFastForward)
            return;

        timeDepuisRewind = 0;
        stopFastForward();
        return;
    }

    public override void startFastForward()
    {
        if (entrainFF)
            return;

        if (monRC.entrainDeRewind)
        {
            monRC.stopRewind();
        }
        
        monAC.RpcStartFF();

        entrainFF = true;
        leColon.speedUp(multiplicationSpeed);
        //update status effect dans le ui
        RpcShowStatusEffect();
        timeDepuisRewind = 0;
    }

    public void stopFastForward()
    {
        monAC.RpcStopFF();
        entrainFF = false;
        //enlever le status effect du ui
        RpcStopStatusEffect();
        leColon.speedDown(multiplicationSpeed);
    }
}
