using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{

    private Animator animator;
    private CharacterController controller;
    private InputReader input;
    [SerializeField] private TriggerAudioCollection audioCollection;

    [SerializeField] private String Velocity = "Velocity";
    [SerializeField] private String AirDirection= "AirDirection";
    [SerializeField] private String Grounded = "Grounded";
    [SerializeField] private String TriggerShoot = "Shoot";
    [SerializeField] private String TriggerMelee = "Melee";
    [SerializeField] private String TriggerThrow = "Throw";
    [SerializeField] private String TriggerHit = "Hit";
    [SerializeField] private String TriggerHorizontalAttack = "HorizontalAttack";
    [SerializeField] private String TriggerWaveGun = "Wave";
    [SerializeField] private String TriggerFryingPan = "FryingPan";
    [SerializeField] private String TriggerChompers = "Chompers";

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
        input = gameObject.GetComponent<InputReader>();
        

        input.OnWeakPerformed += HandleWeak;
        input.OnWeakUpPerformed += HandleWeakUp;
        input.OnWeakSidePerformed += HandleWeakSide;
        input.OnWeakDownPerformed += HandleWeakDown;
        input.OnStrongPerformed += HandleStrong;
        input.OnStrongUpPerformed += HandleStrongUp;
        input.OnStrongSidePerformed += HandleStrongSide;
        // input.OnStrongDownPerformed += HandleStrongDown;


    }

    private void HandleWeakDown()
    {
    }

    private void HandleWeakSide()
    {
        // animator.SetTrigger(TriggerMelee);
        animator.SetTrigger(TriggerHorizontalAttack);
    }

    public void PlayMissSound()
    {
        TriggerAudioCollection.Instance.PlaySound(EAudioType.SFX_Miss);
    }

    private void HandleWeakUp()
    {
        animator.SetTrigger(TriggerThrow);
    }

    private void HandleWeak()
    {
        animator.SetTrigger(TriggerHit);
    }

    private void HandleStrongSide()
    {
        // animator.SetTrigger(TriggerWaveGun);
    }
    
    private void HandleStrongUp()
    {
        animator.SetTrigger(TriggerFryingPan);
    }
    
    private void HandleStrong()
    {
        animator.SetTrigger(TriggerChompers);
    }
    
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat(Velocity, controller.velocity.x);
        animator.SetFloat(AirDirection, controller.velocity.y);

        animator.SetBool(Grounded, controller.isGrounded);

    }
}
