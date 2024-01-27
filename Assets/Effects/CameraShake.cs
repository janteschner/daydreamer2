using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public AnimationCurve curve;
    public float shakeTime = 0.5f;
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

    public void Shake(float strength)
    {
        StartCoroutine(RunCameraShake(strength));
    }
    
    public IEnumerator RunCameraShake(float strength)
    {
        Vector3 startPosition = transform.position;
        float timeUsed = 0f;

        while (timeUsed < shakeTime)
        {
            timeUsed += Time.deltaTime;
            float curveMultiplier = curve.Evaluate(timeUsed / (shakeTime * strength));
            transform.position = startPosition + Random.insideUnitSphere * (curveMultiplier * strength);
            yield return null;
        }

        transform.position = startPosition;
    }
}
