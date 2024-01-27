using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{

    private Animator animator;
    private CharacterController controller;
    private InputReader input;

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
    }

    private void HandleWeakDown()
    {
        animator.SetTrigger("Shoot");
    }

    private void HandleWeakSide()
    {
        animator.SetTrigger("Melee");
    }

    private void HandleWeakUp()
    {
        animator.SetTrigger("Throw");
    }

    private void HandleWeak()
    {
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocity", controller.velocity.x);

    }
}
