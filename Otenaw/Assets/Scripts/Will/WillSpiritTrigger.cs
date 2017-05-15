using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillSpiritTrigger : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spirit")
        {

            if (other.gameObject.GetComponent<SpiritMovement>().enabled)
            {
                transform.parent.gameObject.GetComponent<WillController>().gainWill(other.gameObject);
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}