using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]

public class PlayerStateMachine : StateMachine
{
    [Header("Movement Settings")]
    [SerializeField] public Vector3 Velocity;
    [SerializeField] public float MovementSpeed = 5f;
    [SerializeField] public float JumpForce = 5f;
    [SerializeField] public float LookRotationDampFactor = 10f;
    [Header("GroundCheckSettings")]
    [SerializeField] public float groundCheckRadius = 0.2f;
    [SerializeField] public Vector3 groundCheckOffset;
    [SerializeField] public LayerMask groundLayer;
    //[SerializeField] public float MovementSpeed { get; private set; } = 5f;
    //[SerializeField] public float JumpForce { get; private set; } = 5f;
    //[SerializeField] public float LookRotationDampFactor { get; private set; } = 10f;

    public bool isGrounded = true;

    public Transform MainCamera { get; private set; }
    public InputReader InputReader { get; private set; }
    public Animator Animator { get; private set; }
    public CharacterController Controller { get; private set; }

    private void Start()
    {
        MainCamera = Camera.main.transform;

        InputReader = GetComponent<InputReader>();
        Animator = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();

        SwitchState(new PlayerMoveState(this));
    }

    public void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius, groundLayer);
    }
}
