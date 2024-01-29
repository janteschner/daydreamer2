using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    FollowTarget AgentTarget;
    Animator AgentAnim;

    [SerializeField] float grounded = 2.0f;
    [SerializeField] int sleepTimer = 2000;

    bool isGrounded;
    bool isInReach;
    System.Random rand;

    // Start is called before the first frame update
    void Start()
    {
        AgentTarget = GetComponent<FollowTarget>();
        AgentAnim = GetComponent<Animator>();
        rand= new System.Random();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (!AgentTarget.IsUnityNull() && AgentTarget.IsActive)
        {
            AgentAnim.SetBool("Grounded", (AgentTarget.AgentAirVelocity == 0));
            AgentAnim.SetFloat("Velocity", Mathf.Abs(AgentTarget.AgentVelocity));
            AgentAnim.SetFloat("AirVelocity", AgentTarget.AgentAirVelocity);

          
            if (AgentTarget.IsInReach && !AgentAnim.GetNextAnimatorStateInfo(0).IsTag("attacking"))
            {
                int decision = rand.Next(0, 2);
                if (decision == 0)
                    AgentAnim.SetTrigger("Attack1");
                if (decision == 1)
                    AgentAnim.SetTrigger("Attack2");
            }
        }
    }
}
