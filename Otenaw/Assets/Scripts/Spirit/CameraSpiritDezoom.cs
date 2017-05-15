using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpiritDezoom : MonoBehaviour {

    [SerializeField]
    float m_DampTime = 0.1f;

    /*[SerializeField]
    float deZoomMax = -30f;*/
    
    /*[SerializeField]
    float deZoomSpeed = 5f;*/

    //private float deZoomMin = -25f;
    private GameObject maCamera;
    private Vector3 vectorDezoomMax;
    private Vector3 vectorDezoomMin;
    private Vector3 m_MovSpeed;

    private float maxRight;
    private float maxLeft;
    private float maxUp;
    private float maxDown;

    // Use this for initialization
    void Start()
    {
        //maCamera = Camera.main.transform.parent.gameObject;
        //deZoomMin = Camera.main.transform.position.z;

        /*vectorDezoomMax = new Vector3(0, 0, deZoomMax);
        vectorDezoomMin = new Vector3(0, 0, deZoomMin);*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        maCamera.transform.position = Vector3.SmoothDamp(maCamera.transform.position, transform.position, ref m_MovSpeed, m_DampTime);

        maCamera.transform.position = new Vector3(Mathf.Clamp(maCamera.transform.position.x, maxRight, maxLeft), maCamera.transform.position.y, Mathf.Clamp(maCamera.transform.position.z, maxUp, maxDown));

        /*if (Input.GetAxis("SlashTrigger") >= 0.1f)
        {
            Camera.main.transform.localPosition = Vector3.MoveTowards(Camera.main.transform.localPosition, vectorDezoomMax, deZoomSpeed * Input.GetAxis("SlashTrigger") * Time.deltaTime);
        }
        else
        {
            Camera.main.transform.localPosition = Vector3.MoveTowards(Camera.main.transform.localPosition, vectorDezoomMin, (deZoomSpeed * 2) * Time.deltaTime);
        }*/
    }

    public void setCamera(Transform transCam)
    {
        maCamera = Camera.main.transform.parent.gameObject;
        maCamera.transform.localRotation = transCam.localRotation;

        Camera.main.transform.localPosition = new Vector3(0f, 0f, transCam.localPosition.y);


        maxRight = ObjectifManager.INSTANCE.CamRightMax.transform.position.x;
        maxLeft = ObjectifManager.INSTANCE.CamLeftMax.transform.position.x;
        maxUp = ObjectifManager.INSTANCE.CamUpMax.transform.position.z;
        maxDown = ObjectifManager.INSTANCE.CamDownMax.transform.position.z;
    }
}
