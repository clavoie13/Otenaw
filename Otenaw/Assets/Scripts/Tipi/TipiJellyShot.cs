using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class TipiJellyShot : NetworkBehaviour {

    [SerializeField]
    GameObject tipi;

    [SerializeField]
    float speed = 1f;

    [SerializeField]
    float taileMax = 1.2f;

    float tM;

    private bool DoIt = false;
    private bool goUp = true;
    // Use this for initialization

    private Vector3 scaleOriginal;

	void Start () {
        scaleOriginal = tipi.transform.localScale;
        tM = scaleOriginal.x * taileMax;
	}
	
	// Update is called once per frame
	void Update () {
		if(DoIt)
        {
            if (goUp)
            {
                tipi.transform.localScale = new Vector3(tipi.transform.localScale.x + (Time.deltaTime * speed), tipi.transform.localScale.y + (Time.deltaTime * speed), tipi.transform.localScale.z + (Time.deltaTime * speed));

                if (tipi.transform.localScale.x >= tM)
                    goUp = false;
            }
            else
            {
                tipi.transform.localScale = new Vector3(tipi.transform.localScale.x - (Time.deltaTime * speed), tipi.transform.localScale.y - (Time.deltaTime * speed), tipi.transform.localScale.z - (Time.deltaTime * speed));

                if (tipi.transform.localScale.x <= scaleOriginal.x)
                {
                    tipi.transform.localScale = scaleOriginal;
                    goUp = true;
                    DoIt = false;
                }
            }
        }
	}

    [ClientRpc]
    public void RpcStartJelly()
    {
        tipi.transform.localScale = scaleOriginal;
        DoIt = true;
    }

    [Command]
    public void CmdStartJelly()
    {
        RpcStartJelly();
    }

    public void StartJelly()
    {
        tipi.transform.localScale = scaleOriginal;
        DoIt = true;
    }
}
