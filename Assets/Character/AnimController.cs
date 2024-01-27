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

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
        input = gameObject.GetComponent<InputReader>();

        audioCollection.PlayAudioSource(EAudioType.Narration_ThisIsJane, 0.9f, false);
        System.Random rand = new System.Random();
        Time.timeScale = 0.0f;


        input.OnWeakPerformed += HandleWeak;
        input.OnWeakUpPerformed += HandleWeakUp;
        input.OnWeakSidePerformed += HandleWeakSide;
        input.OnWeakDownPerformed += HandleWeakDown;


    }

    private void HandleWeakDown()
    {
        animator.SetTrigger(TriggerShoot);
    }

    private void HandleWeakSide()
    {
        animator.SetTrigger(TriggerMelee);
    }

    private void HandleWeakUp()
    {
        animator.SetTrigger(TriggerThrow);
    }

    private void HandleWeak()
    {
        animator.SetTrigger(TriggerHit);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat(Velocity, controller.velocity.x);
        animator.SetFloat(AirDirection, controller.velocity.y);

        animator.SetBool(Grounded, controller.isGrounded);

    }
}
