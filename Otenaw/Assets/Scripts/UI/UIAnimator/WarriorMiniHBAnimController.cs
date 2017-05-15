using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMiniHBAnimController : MonoBehaviour {

    [SerializeField]
    GameObject noise;

    [SerializeField]
    GameObject deadImg;

    Animator noiseAnimator;
    Animator deadAnimator;

    bool isActive = false;

	// Use this for initialization
	void Start () {
        noiseAnimator = noise.GetComponent<Animator>();
        deadAnimator = deadImg.GetComponent<Animator>();
	}
	
    //pour changer la vitesse et la dirrection du noise
    public void SetNoiseSpeed(float newSpeed)
    {
        noiseAnimator.SetFloat("speed", newSpeed);
    }

    //changer l'anim pour un pulse low
    public void PulseLow()
    {
        deadAnimator.SetBool("Low", true);
        if (!isActive)
        {
            deadAnimator.SetTrigger("In");
            isActive = true;
        }
    }

    //changer l'anim pour un pulse high
    public void PulseHigh()
    {
        deadAnimator.SetBool("Low", false);
        if (!isActive)
        {
            deadAnimator.SetTrigger("In");
            isActive = true;
        }
    }

    //arreter l'anim
    public void StopPulse()
    {
        if (isActive)
        {
            deadAnimator.SetTrigger("Out");
            isActive = false;
        }
    }
}

