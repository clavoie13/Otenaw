using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footStep : MonoBehaviour {

    SoundPlayer monSoundPlayer;
    int monRandom = 0;


	// Use this for initialization
	void Start () {

        monSoundPlayer = gameObject.GetComponent<SoundPlayer>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void jouerSon()
    {
        monRandom = Random.Range(7, 12);
        monSoundPlayer.playSound(monRandom);
    }
}
