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
        _nav.SetDestination(_destination);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputReader.Instance.menuOpen)
        {
            _nav.enabled = false;
        }
        else
        {
            _nav.enabled = true;
        }
    }
    
    public void ApplyKnockback(Vector2 direction)
    {
        Debug.Log("Applying Knockback!");
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(new Vector3(direction.x, direction.y, 0f), ForceMode.Impulse);
    }
}
