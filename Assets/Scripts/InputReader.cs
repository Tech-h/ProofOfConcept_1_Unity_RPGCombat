using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputReader : MonoBehaviour
{
    public Vector2 MouseDelta;
    public Vector2 MoveComposite;

    public Action OnJumpPerformed;

    private InputAction controls;

    private void Awake()
    {
        controls = GetComponent<InputAction>();
    }

    private void OnEnable()
    {
        if (controls != null)
            return;

        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        MouseDelta = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveComposite = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        OnJumpPerformed?.Invoke();
    }
}
