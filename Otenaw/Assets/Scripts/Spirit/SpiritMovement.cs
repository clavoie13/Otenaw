using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritMovement : MonoBehaviour {

    [SerializeField]
    float speedMove;
    [SerializeField]
    Transform charTransform;

    Rigidbody rbody;
    float inputV;
    float inputH;
    float pressionJoystick;

    private bool canMove = true;
    private float angleCam;
    private SpiritAnimationController monAC;

    void Start()
    {
        monAC = GetComponent<SpiritAnimationController>();
        rbody = GetComponent<Rigidbody>();
        angleCam = ObjectifManager.INSTANCE.transCamera.eulerAngles.y;
    }

    private void OnEnable()
    {
        
    }

    void Update()
    {
        if (!canMove)
            return;

        inputV = Input.GetAxis("Vertical");
        inputH = Input.GetAxis("Horizontal");

        Vector3 targetDir = Vector3.zero;

        if (Mathf.Abs(Input.GetAxis("Vertical")) >= 0.1 || Mathf.Abs(Input.GetAxis("Horizontal")) >= 0.1)
        {
            targetDir = new Vector3(inputH, 0.0f, inputV);
            charTransform.rotation = Quaternion.LookRotation(Quaternion.AngleAxis(angleCam, Vector3.up) * targetDir);
            //charTransform.rotation = Quaternion.AngleAxis(angleCam, Vector3.up);
        }

        pressionJoystick = Mathf.Clamp01(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).magnitude);

        monAC.CmdChangeSpeed(pressionJoystick);
    }

    void FixedUpdate()
    {
        if (!canMove)
            return;

        Move();
    }

    private void Move()
    {
        Vector3 movement;

        movement = (charTransform.forward) * pressionJoystick * speedMove * Time.deltaTime;

        rbody.velocity = movement;
    }

    public void disableMovement()
    {
        canMove = false;
        rbody.velocity = Vector3.zero;
    }

    public void enableMovement()
    {
        canMove = true;
    }

    public Vector3 GetForwardChar()
    {
        return charTransform.forward;
    }

    void OnDisable()
    {
        rbody.velocity = Vector3.zero;
        canMove = false;

    }
}
