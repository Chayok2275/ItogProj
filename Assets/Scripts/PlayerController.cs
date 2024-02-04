using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _fallVelocity = 0f;
    private CharacterController _characterController;
    private Vector3 _MoveVector;
    private bool SprintingNow = false;

    public float JumpForce = 1f;
    public float Gravity = 9.8f;
    public float Speed = 10f;
    public float SpeedAcceleration = 1f;


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame

    private void Update()
    {
        // Jump
        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -JumpForce;
        }

        // Movement
        _MoveVector = Vector3.zero;
        if (SprintingNow == true) 
        {
            Speed = Speed / SpeedAcceleration;
            SprintingNow = false;
        }
        if (Input.GetKey(KeyCode.LeftShift) && (SprintingNow == false))
        {
            SprintingNow = true;
            Speed = Speed * SpeedAcceleration;
        }

        if (Input.GetKey(KeyCode.W))
        {
            _MoveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _MoveVector += -transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _MoveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _MoveVector += -transform.right;
        }
    }

    void FixedUpdate()
    {

        // Move
        _characterController.Move(Time.fixedDeltaTime * Speed * _MoveVector);


        // Gravity
        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if(_characterController.isGrounded)
        {
            _fallVelocity = 0f;
        }
    }

}
