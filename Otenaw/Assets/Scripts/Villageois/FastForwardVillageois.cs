using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForwardVillageois : FastForward {

    public float multiplicationSpeed = 2f;
    public float dureFastForward = 2f;


    public bool entrainFF = false;
    private villageois leVillageois;
    private VillageoisAnimationController monAC;
    private RewindVillageois monRC;
    private allerVersTemple monAVT;
    float timeDepuisRewind = 0;


    // Use this for initialization
    void Start () {
        leVillageois = GetComponent<villageois>();
        monAC = GetComponent<VillageoisAnimationController>();
        monRC = GetComponent<RewindVillageois>();
        monAVT = GetComponent<allerVersTemple>();
    }
	
	// Update is called once per frame
	void Update () {
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

        ObjectifManager.INSTANCE.setNbrFFNpc();

        if (monRC.entrainDeRewind)
        {
            monRC.stopRewind();
        }

        monAC.RpcStartFF();

        entrainFF = true;
        leVillageois.speedUp(multiplicationSpeed);
        //update status effect dans le ui
        RpcShowStatusEffect();
    }

    public void stopFastForward()
    {
        monAC.RpcStopFF();

        entrainFF = false;
        //enlever le status effect du ui
        RpcStopStatusEffect();
        leVillageois.speedDown(multiplicationSpeed);
        monAVT.resumetMovment();
    }

    private void OnDisable()
    {
        if (entrainFF)
            stopFastForward();
    }
}
