using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, InputActions.ILocomotionActions, InputActions.IAttacksActions
{
    public float horizontalMove;

    public Action OnJumpPerformed;
    public Action OnWeakPerformed;
    public Action OnWeakUpPerformed;
    public Action OnWeakSidePerformed;
    public Action OnWeakDownPerformed;

    public Action OnMenuOpenPerformed;

    public bool menuOpen;
    public bool shielding;

    private InputActions inputActions;
    
    
    private void OnEnable()
    {
        if (inputActions != null)
            return;

        inputActions = new InputActions();
        inputActions.Locomotion.SetCallbacks(this);
        inputActions.Locomotion.Enable();
        inputActions.Attacks.SetCallbacks(this);
        inputActions.Attacks.Enable();

    }

    private void OnDisable()
    {
        inputActions.Locomotion.Disable();
        inputActions.Attacks.Disable();
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

    public void OnWeak(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        OnWeakPerformed?.Invoke();
    }
    
    public void OnWeakUp(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        OnWeakUpPerformed?.Invoke();
    }

    public void OnWeakSide(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        OnWeakSidePerformed?.Invoke();
    }
    
    public void OnWeakDown(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        OnWeakDownPerformed?.Invoke();
    }

    public void OnShield(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shielding = true;
        }
        else
        {
            shielding = false;
        }
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnMenuOpenPerformed?.Invoke();

        menuOpen = (menuOpen) ? false : true;
    }
}
