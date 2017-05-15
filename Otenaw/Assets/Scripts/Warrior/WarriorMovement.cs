using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class WarriorMovement : NetworkBehaviour
{
    [SerializeField] float speedMove;
    [SerializeField]
    float speedMoveVieux;
    [SerializeField]
    float speedMoveJeune;
    [SerializeField]
    float multiplicateurFF = 1f;
    [SerializeField] Transform charTransform;

    Rigidbody rbody;
    float inputV;
    float inputH;
    float pressionJoystick;

    private bool canMove = true;
    private WarriorAnimationController leAnimationController;

    [SyncVar]
    private float forceSlowBou = 1;

    // Use this for initialization
    void Start()
    {
        speedMove = speedMoveJeune;
        rbody = GetComponent<Rigidbody>();
        leAnimationController = GetComponent<WarriorAnimationController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
            return;

        inputV = Input.GetAxis("Vertical");
        inputH = Input.GetAxis("Horizontal");

        Vector3 targetDir = Vector3.zero;

        if (Mathf.Abs(Input.GetAxis("Vertical")) >= 0.1f || Mathf.Abs(Input.GetAxis("Horizontal")) >= 0.1f)
        {
            targetDir = new Vector3(inputH, 0.0f, inputV);
            charTransform.rotation = Quaternion.LookRotation(targetDir);
        }

        pressionJoystick = Mathf.Clamp01(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).magnitude);

        leAnimationController.CmdChangeSpeed(pressionJoystick);
    }

    void FixedUpdate()
    {
        if (!canMove)
            return;

        Move();
    }

    [Command]
    public void CmdChangerBou(float force)
    {
        forceSlowBou = force;
    }

    public void rajeunir()
    {
        speedMove = speedMoveJeune;
    }

    public void vieillir()
    {
        speedMove = speedMoveVieux;
    }

    public void changeMultiplicateur(float s)
    {
        multiplicateurFF = s;
    }

    private void Move()
    {
        Vector3 movement;

        movement = (charTransform.forward /*+ charTransform.right*/) * ((pressionJoystick * speedMove * Time.deltaTime * multiplicateurFF) / forceSlowBou);

        movement = new Vector3(movement.x, rbody.velocity.y, movement.z);

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
        return charTransform.forward /*+ charTransform.right*/;
    }

    /*public void mettreMortLeWarrior()
    {
        leAnimationController.CmdDeath();
    }*/

    /*public void gagner()
    {
        leAnimationController.CmdDance();
    }*/

    void OnDisable()
    {
        canMove = false;
    }
}
