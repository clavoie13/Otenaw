using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritSpellAnimController : MonoBehaviour {

    [SerializeField]
    Animator fastForwardAnimator;

    [SerializeField]
    Animator rewindAnimator;

    public void StartRewind()
    {
        rewindAnimator.SetBool("Trigger", true);
    }

    public void StopRewind()
    {
        rewindAnimator.SetBool("Trigger", false);
    }

    public void StartFastForward()
    {
        fastForwardAnimator.SetBool("Trigger", true);
    }

    public void StopFastForward()
    {
        fastForwardAnimator.SetBool("Trigger", false);
    }
}
