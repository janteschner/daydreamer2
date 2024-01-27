using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainOnomatopoeia : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            // other.gameObject.GetComponent<PlayerController>().ApplyKnockback(new Vector2(14, 25));
            OnomatopoeiaSpawner.Instance.InstantiateAt(other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position), 0.8f);
        }
    }
}
