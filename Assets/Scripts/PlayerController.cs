using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction playerInput;

    private Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {
        playerInput = GetComponent<InputAction>();
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Update()
    {
     //
    }

}
