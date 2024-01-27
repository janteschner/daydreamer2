using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnomatopoeiaSpawner : MonoBehaviour
{
    public GameObject onomatopoeiaPrefab;
    public static OnomatopoeiaSpawner Instance { get; private set; }


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
    
    public void InstantiateAt(Vector3 position, float size = 0.35f)
    {
        var newObject = Instantiate(onomatopoeiaPrefab, new Vector3(position.x, position.y, -0.5f), Quaternion.identity);
        newObject.transform.localScale = new Vector3(size, size, size);
        CameraShake.Instance.Shake(size);
    }
}
