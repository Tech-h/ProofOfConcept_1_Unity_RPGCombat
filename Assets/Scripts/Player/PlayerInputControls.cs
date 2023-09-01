using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerInputControls : MonoBehaviour
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

    public Vector2 OnMove()
    {
        return moveDirection;
    }

    public void MouseMove(InputAction.CallbackContext context)
    {

    }

    public void OnJump(InputAction.CallbackContext context)
    {

    }

    public void OnAttack(InputAction.CallbackContext context)
    {

    }
    
    public void OnPause(InputAction.CallbackContext context)
    {

    }
}
