using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraLookAtPoint : MonoBehaviour
{
    public Transform playerTransform;
    public float damping = 0.5f;
    public float LerpSpeed = 0.5f;
    public float LerpStrength = 0.1f;
    public float LerpToStartStrength = 0.1f;

    public bool UseCurveLerp;
    public float CurveDistance = 10;
    public AnimationCurve LerpCurve;

    protected Vector3 CameraStartPosition;
    
    public 
    // Start is called before the first frame update
    void Start()
    {
        CameraStartPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //var newX = Mathf.Lerp(0, playerTransform.position.x, damping);
        //gameObject.transform.SetPositionAndRotation(new Vector3(newX, gameObject.transform.position.y, gameObject.transform.position.z), transform.rotation);

        float LocalLerpStrength = LerpStrength;

        if (UseCurveLerp)
        {
            float dist = Vector3.Magnitude(CameraStartPosition - playerTransform.position) / CurveDistance;
            LocalLerpStrength = LerpCurve.Evaluate(dist) * LerpStrength;
        }
 
        
        // Lerps to player position
        Vector3 newPosition = Vector3.Lerp(CameraStartPosition, playerTransform.position, LocalLerpStrength);
        newPosition.z = CameraStartPosition.z;
        
        
        //Lerp Smooth
        newPosition = Vector3.Lerp(gameObject.transform.position, newPosition, LerpSpeed * Time.deltaTime);
        
        //Return to center
        newPosition = Vector3.Lerp(newPosition, CameraStartPosition, LerpToStartStrength * Time.deltaTime);

        gameObject.transform.position = newPosition;

    }
}
