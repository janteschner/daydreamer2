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
    
    public void InstantiateAt(Vector3 position)
    {
        Instantiate(onomatopoeiaPrefab, position, Quaternion.identity);
    }
}
