using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Death_Flatten : MonoBehaviour
{
    private float passedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        
        foreach(Collider c in GetComponents<Collider> ())
        {
            c.enabled = false;
        }
        
        foreach(HitboxScript h in GetComponentsInChildren<HitboxScript>())
        {
            Destroy(h);
        }

        var rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        rigidbody.velocity = Vector3.zero;

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.1f, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        passedTime += Time.deltaTime;
        if (passedTime > 2f)
        {
            Destroy(gameObject);
        }
    }
}
