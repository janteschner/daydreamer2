using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPiano : MonoBehaviour
{
    public GameObject pianoPrefab;

    public Transform summoningSpot;

    public float summonHeight = 30f;

    public void SummonInFrontOfParent()
    {
        SummonAPiano(summoningSpot.position);
    }

    public void SummonAPiano(Vector3 position)
    {
        Instantiate(pianoPrefab, new Vector3(position.x, summonHeight, position.z), Quaternion.Euler(Random.Range(-10f, 10f),Random.Range(-10f, 10f),Random.Range(-10f, 10f)));
    }
}
