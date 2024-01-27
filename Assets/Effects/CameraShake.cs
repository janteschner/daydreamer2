using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    public float strengthMod = 1f;
    public float durationMod = 1f;
    private Vector3 startPosition;
    private float _remainingShakeDuration = 0f;
    private float _shakeStrength = 1f;

    public static CameraShake Instance { get; private set; }
    
    
    
    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }

    void Start()
    {
        startPosition = transform.position;
    }

    public void Shake(float strength)
    {
        _remainingShakeDuration += strength * durationMod;
        _shakeStrength += strength * strengthMod;

    }

    private void Update()
    {
        if (_remainingShakeDuration > 0f)
        {
            Vector3 randomOffset = Random.insideUnitSphere * _shakeStrength;
            transform.localPosition = startPosition + randomOffset;
            _remainingShakeDuration -= Time.deltaTime;
            _shakeStrength -= Time.deltaTime;
        }
        else
        {
            _remainingShakeDuration = 0f;
            _shakeStrength = 0f;
            transform.localPosition = startPosition;
        }
    }
}
