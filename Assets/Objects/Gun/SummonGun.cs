using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonGun : MonoBehaviour
{
    public Transform spawnTransform;
    public GameObject worldGunObject;

    public void SummonInFrontOfParent()
    {
        SummonAPiano(spawnTransform);
    }
    
    public void SummonAPiano(Transform transform)
    {
        Instantiate(worldGunObject, transform.position, transform.rotation);
    }
}
