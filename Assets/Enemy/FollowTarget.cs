using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    public Transform followTarget;
    private NavMeshAgent _nav;
    public float speed = 5f;
    public float updateRate = 0.4f;

    
    private Vector3 _destination;



    // Start is called before the first frame update
    void Start()
    {
        if (!followTarget)
        {
            followTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }

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
    }

    public void ApplyKnockback(Vector2 direction)
    {
        Debug.Log("Applying Knockback!");
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(new Vector3(direction.x, direction.y, 0f), ForceMode.Impulse);
    }
}
