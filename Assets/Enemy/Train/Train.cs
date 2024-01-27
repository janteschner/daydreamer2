using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 10f;

    private float _elapsedLifetime = 0f;
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().ApplyKnockback(new Vector2(14, 25));
            OnomatopoeiaSpawner.Instance.InstantiateAt(other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position), 0.8f);
                
        }
    }

    private void Update()
    {
        transform.Translate(transform.right * (speed * Time.deltaTime));
        _elapsedLifetime += Time.deltaTime;
        if (_elapsedLifetime > lifetime)
        {
            Destroy(this);
        }
    }
}
