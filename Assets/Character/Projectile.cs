using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Vector3 direction;


    Rigidbody body;

    public Vector3 Direction { get => direction; set => direction = value; }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.AddForce(Direction, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerAudioCollection.Instance.PlaySound(EAudioType.SFX_Cake);
    }
}
