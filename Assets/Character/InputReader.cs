using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, InputActions.ILocomotionActions
{
    public float horizontalMove;

    public Action OnJumpPerformed;

    private InputActions inputActions;
    
    
    private void OnEnable()
    {
        if (inputActions != null)
            return;

        inputActions = new InputActions();
        inputActions.Locomotion.SetCallbacks(this);
        inputActions.Locomotion.Enable();
    }

    private void OnDisable()
    {
        inputActions.Locomotion.Disable();
    }

    public void Update()
    {
        Debug.Log(horizontalMove);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalMove = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        OnJumpPerformed?.Invoke();
    }
}
