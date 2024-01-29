using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    Animator AgentAnim;
    
    public Transform followTarget;
    public float speed = 5f;
    public float updateRate = 0.4f;

    public float attackRange = 10.0f;
    
    private NavMeshAgent _nav;
    private Vector3 _destination;
    private float _distance;

    public float AgentVelocity { get { return _nav.velocity.x; } }
    public float AgentAirVelocity { get { return _nav.velocity.y; } }

    public bool IsInReach { get { return (_nav.remainingDistance > 0 && _nav.remainingDistance < attackRange); } }
    public bool IsActive { get { return (_nav != null && _nav.isActiveAndEnabled); } }


    // Start is called before the first frame update
    void Start()
    {
        if (!followTarget)
        {
            followTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
        AgentAnim = GetComponent<Animator>();

        _nav = GetComponent<NavMeshAgent>();
        _nav.speed = speed;
       
        InvokeRepeating(nameof(UpdateNavigation), 0f, updateRate);
    }

    void UpdateNavigation()
    {
        _destination = followTarget.transform.position;
        if (_nav.isOnNavMesh)
        {
            _nav.SetDestination(_destination);
        }

    
        _distance = _nav.remainingDistance;
        //Debug.Log("Distance:" + _distance);
        Debug.Log("Velocity:" + _nav.velocity);

        if (AgentAnim.GetCurrentAnimatorStateInfo(0).IsTag("attacking"))
        {
            _nav.speed = 0;
        }
        else
        {
            _nav.speed = speed;
        }
       
    }

    public void ApplyKnockback(Vector2 direction)
    {
        // Debug.Log("Applying Knockback!");
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(new Vector3(direction.x, direction.y, 0f), ForceMode.Impulse);
    }
}
