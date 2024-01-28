using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Death_FlyIntoScreen : MonoBehaviour
{
    private float passedTime = 0f;

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        Destroy(gameObject.GetComponent<FollowTarget>());
        Destroy(gameObject.GetComponent<NavMeshAgent>());
        
        foreach(Collider c in GetComponents<Collider> ())
        {
            Destroy(c);
        }

        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(new Vector3(0f, 0.25f, -0.5f) * 100f, ForceMode.Impulse);
        TriggerAudioCollection.Instance.PlayAudioSource(EAudioType.SFX_Fly_Away, transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        passedTime += Time.deltaTime;
        _rigidbody.AddForce(new Vector3(0f, 0.2f, -0.5f) * (10f * Time.deltaTime), ForceMode.Acceleration);

        if (passedTime > 2f)
        {
            Destroy(gameObject);
        }
    }
}
