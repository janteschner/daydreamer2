using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtPoint : MonoBehaviour
{
    public Transform playerTransform;

    public float damping = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var newX = Mathf.Lerp(0, playerTransform.position.x, damping);
        gameObject.transform.SetPositionAndRotation(new Vector3(newX, gameObject.transform.position.y, gameObject.transform.position.z), transform.rotation);
    }
}
