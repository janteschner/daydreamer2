using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 10f;

    private float _elapsedLifetime = 0f;

    private void Update()
    {
        if (!InputReader.Instance.menuOpen)
        {
            transform.Translate(transform.right * (speed * Time.deltaTime));
            _elapsedLifetime += Time.deltaTime;
        }
        if (_elapsedLifetime > lifetime)
        {
            Destroy(this);
        }
    }
}
