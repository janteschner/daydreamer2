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
    public Action OnStrongPerformed;
    public Action OnStrongUpPerformed;
    public Action OnStrongSidePerformed;
    public Action OnStrongDownPerformed;


    public Action OnMenuOpenPerformed;

    public bool menuOpen;
    public bool shielding;

    private InputActions inputActions;

    private float _cooldownUltil = 0f;
    private float _noMoveUltil = 0f;
    
    public static InputReader Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }

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

    private void Cooldown(float seconds)
    {
        _cooldownUltil = Time.time + seconds;
    }
    
    private void NoMoveFor(float seconds)
    {
        _noMoveUltil = Time.time + seconds;
    }

    private bool OnCooldown()
    {
        return Time.time < _cooldownUltil;
    }
    private bool CannotMove()
    {
        return Time.time < _noMoveUltil;
    }
    


    public void OnMove(InputAction.CallbackContext context)
    {
        if (CannotMove())
        {
            horizontalMove = 0f;
        }
        else
        {
            horizontalMove = context.ReadValue<float>();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (CannotMove()) return;
        if (!context.performed)
            return;
        OnJumpPerformed?.Invoke();
    }

    public void OnWeak(InputAction.CallbackContext context)
    {
        if (OnCooldown()) return;
        if (!context.performed)
            return;
        Cooldown(1f);

        OnWeakPerformed?.Invoke();
    }
    
    public void OnWeakUp(InputAction.CallbackContext context)
    {
        if (OnCooldown()) return;
        if (!context.performed)
            return;
        Cooldown(0.8f);

        OnWeakUpPerformed?.Invoke();
    }

    public void OnWeakSide(InputAction.CallbackContext context)
    {
        if (OnCooldown()) return;
        if (!context.performed)
            return;
        Cooldown(1f);
        NoMoveFor(1f);

        OnWeakSidePerformed?.Invoke();
    }
    
    public void OnWeakDown(InputAction.CallbackContext context)
    {
        if (OnCooldown()) return;
        if (!context.performed)
            return;
        Cooldown(0.2f);

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

    public void OnStrong(InputAction.CallbackContext context)
    {
        if (OnCooldown()) return;
        if (!context.performed)
            return;
        Cooldown(1f);

        OnStrongPerformed?.Invoke();
    }

    public void OnStrongUp(InputAction.CallbackContext context)
    {
        if (OnCooldown()) return;
        if (!context.performed)
            return;
        Cooldown(1.6f);
        NoMoveFor(1.6f);

        OnStrongUpPerformed?.Invoke();
    }

    public void OnStrongSide(InputAction.CallbackContext context)
    {
        if (OnCooldown()) return;
        if (!context.performed)
            return;
        Cooldown(3f);

        OnStrongSidePerformed?.Invoke();

    }

    public void OnStrongDown(InputAction.CallbackContext context)
    {
        if (OnCooldown()) return;
        if (!context.performed)
            return;
        Cooldown(1f);

        OnStrongDownPerformed?.Invoke();
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnMenuOpenPerformed?.Invoke();

        menuOpen = (menuOpen) ? false : true;
    }
}
