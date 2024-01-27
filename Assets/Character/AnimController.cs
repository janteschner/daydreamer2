using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{

    private Animator animator;
    private CharacterController controller;
    private InputReader input;
    private TriggerAudioCollection audioCollection;

    [SerializeField] private String Velocity = "Velocity";
    [SerializeField] private String AirDirection= "AirDirection";
    [SerializeField] private String Grounded = "Grounded";
    [SerializeField] private String TriggerShoot = "Shoot";
    [SerializeField] private String TriggerMelee = "Melee";
    [SerializeField] private String TriggerThrow = "Throw";
    [SerializeField] private String TriggerX = "Shoot";

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
        input = gameObject.GetComponent<InputReader>();
        audioCollection = GameObject.FindGameObjectWithTag("Sound").GetComponent<TriggerAudioCollection>();

        System.Random rand = new System.Random();

        input.OnWeakPerformed += HandleWeak;
        input.OnWeakUpPerformed += HandleWeakUp;
        input.OnWeakSidePerformed += HandleWeakSide;
        input.OnWeakDownPerformed += HandleWeakDown;

        audioCollection.PlayAudioSource(EAudioType.NarrationOpening, 0.9f);

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
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat(Velocity, controller.velocity.x);
        animator.SetFloat(AirDirection, controller.velocity.y);

        animator.SetBool(Grounded, controller.isGrounded);

    }
}