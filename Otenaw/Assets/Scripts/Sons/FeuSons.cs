using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeuSons : MonoBehaviour {

    public void Son()
    {
        GetComponent<SoundPlayer>().playSound(0);
    }
}
