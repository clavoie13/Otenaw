using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTipi : MonoBehaviour {

    [SerializeField]
    GameObject uiTipi;

    Quaternion rotation, rotationY;

    Vector3 cameraRelPosWarrior;

    Vector3 cameraRelPosTipi;

    Vector2 posCam, posTipi;

    float angleX, angleY;

    private void Start()
    {
        Invoke("allo", 1);
    }

    // Update is called once per framer
    void LateUpdate()
    {
        transform.rotation = rotationY;

        uiTipi.transform.rotation = rotation;
    }

    void allo()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Warrior");

        if (player == null || !player.GetComponent<WarriorMovement>().enabled)
            player = GameObject.FindGameObjectWithTag("Spirit");     
            

        cameraRelPosWarrior = Camera.main.transform.position - player.transform.position;
        cameraRelPosTipi = transform.position + cameraRelPosWarrior;

        posCam = new Vector2(cameraRelPosWarrior.z, cameraRelPosWarrior.y);

        Debug.Log(cameraRelPosWarrior);

        angleX = Vector2.Angle(posCam, Vector2.up);

        rotation = Quaternion.Euler(-angleX, 180f, 0f);

        posCam = new Vector2(cameraRelPosTipi.x, cameraRelPosTipi.z);
        posTipi = new Vector2(transform.position.x, transform.position.z);

        posCam = posCam - posTipi;

        angleY = Vector2.Angle(posCam, Vector2.up);

        rotationY = Quaternion.Euler(0, angleY, 0);
    }
}
