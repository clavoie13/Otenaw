using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWarrior : MonoBehaviour {

    [SerializeField]
    float m_DampTime = 0.5f;

    GameObject maCamera;

    private Vector3 m_MovSpeed;

    public float shakeTimer;
    public float shakeAmount;

    // Use this for initialization
    void Start () {
        maCamera = Camera.main.transform.parent.gameObject;

    }
	
	// Update is called once per frame
	void FixedUpdate() {
            maCamera.transform.position = Vector3.SmoothDamp(maCamera.transform.position, transform.position, ref m_MovSpeed, m_DampTime);
    }

    void Update()
    {
        if (shakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

            maCamera.transform.position = new Vector3(maCamera.transform.position.x + ShakePos.x, +maCamera.transform.position.y + ShakePos.y, maCamera.transform.position.z);

            shakeTimer -= Time.deltaTime;
        }
    }

    public void ShakeCamera(float shakePowwow, float shakeDur)
    {
        shakeAmount = shakePowwow;
        shakeTimer = shakeDur;
    }
}
