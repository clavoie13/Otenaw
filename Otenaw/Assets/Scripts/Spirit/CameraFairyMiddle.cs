using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFairyMiddle : MonoBehaviour {

    public bool DezoomAutomatique = false;
    private GameObject fairy;
    private GameObject warrior;

    private const float DISTANCE_MARGIN = 10f;

    private Vector3 middlePoint;
    private float distanceFromMiddlePoint;
    private float distanceBetweenPlayers;
    private float cameraDistance;
    private float aspectRatio;
    private float fov;
    private float tanFov;
    private float multiplicateurCamera = 0;
    private Vector3 m_ZoomSpeed;
    private Vector3 m_MoveSpeed;
    private float m_DampTime = 0.4f;
    Vector3 fixeZoomOut;



    float speedDeplacement;

    // Use this for initialization
    void Start () {
        warrior = GameObject.FindGameObjectWithTag("Warrior");
        fairy = gameObject;

        aspectRatio = (float)Screen.width / (float)Screen.height;
        tanFov = Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 2.0f);
        fixeZoomOut = Camera.main.transform.localPosition;
        middlePoint = ObjectifManager.INSTANCE.transform.position;
        Camera.main.transform.localPosition = fixeZoomOut;
    }

    void Update()
    {
        if (Input.GetButtonDown("Slash"))
        {
            DezoomAutomatique = !DezoomAutomatique;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {


        Vector3 newCameraPos = Camera.main.transform.parent.transform.position;

        newCameraPos.x = middlePoint.x;
        newCameraPos.z = middlePoint.z - 2f;

        Debug.Log(fixeZoomOut);


        Camera.main.transform.parent.transform.position =  Vector3.SmoothDamp(Camera.main.transform.parent.transform.position, newCameraPos, ref m_MoveSpeed, m_DampTime);
        //Camera.main.transform.parent.transform.position = newCameraPos;

        // Find the middle point between players.
        Vector3 vectorBetweenPlayers = fairy.transform.position - warrior.transform.position;


        if (DezoomAutomatique)
            middlePoint = warrior.transform.position + 0.5f * vectorBetweenPlayers;
        else
            middlePoint = ObjectifManager.INSTANCE.transform.position;

        // Calculate the new distance.
        distanceBetweenPlayers = vectorBetweenPlayers.magnitude;

        cameraDistance = (distanceBetweenPlayers / 2.0f / aspectRatio) / tanFov;

        //cameraDistance *= aspectRatio;*****************************************************
        //cameraDistance = cameraDistance / 1.77f;

        // Set camera to new position.
        Vector3 dir = (Camera.main.transform.localPosition).normalized;

        if (warrior.transform.position.z - fairy.transform.position.z <= 0)
        {
            if (warrior.transform.position.x - fairy.transform.position.x <= 0)
            {
                multiplicateurCamera = (((Vector3.Angle(Vector3.left, warrior.transform.position - fairy.transform.position) / 90f)));
            }
            else
            {
                multiplicateurCamera = (((Vector3.Angle(Vector3.right, warrior.transform.position - fairy.transform.position) / 90f)));
            }
        }
        else
        {
            if (warrior.transform.position.x - fairy.transform.position.x <= 0)
            {
                multiplicateurCamera = (((Vector3.Angle(Vector3.right, fairy.transform.position - warrior.transform.position) / 90f)));
            }
            else
            {
                multiplicateurCamera = (((Vector3.Angle(Vector3.left, fairy.transform.position - warrior.transform.position) / 90f)));
            }
        }

        cameraDistance *= ((((aspectRatio + 0.2f) - 1) * multiplicateurCamera) + 1);



        if (cameraDistance <= 20f - DISTANCE_MARGIN)
        {
            cameraDistance = 20f - DISTANCE_MARGIN;
        }

        if(cameraDistance > (fixeZoomOut.z * -1) - DISTANCE_MARGIN)
        {
            cameraDistance = (fixeZoomOut.z * -1) - DISTANCE_MARGIN;
        }


        Vector3 nouveauZoom;

        if (DezoomAutomatique)
            nouveauZoom = Vector3.SmoothDamp(Camera.main.transform.localPosition, (dir * (cameraDistance + DISTANCE_MARGIN)), ref m_ZoomSpeed, m_DampTime);
        else
            nouveauZoom = Vector3.SmoothDamp(Camera.main.transform.localPosition, fixeZoomOut, ref m_ZoomSpeed, m_DampTime);

        Camera.main.transform.localPosition = nouveauZoom;
    }
}
