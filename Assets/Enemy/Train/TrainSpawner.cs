using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawner : MonoBehaviour
{
    public float minDelay = 10f;

    public float maxDelay = 20f;

    public GameObject trainPrefab;

    private float _nextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        _nextSpawn = Time.time + Random.Range(minDelay, maxDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextSpawn)
        {
            SpawnTrain();
            _nextSpawn = Time.time + Random.Range(minDelay, maxDelay);
        }
    }

    void SpawnTrain()
    {
        Instantiate(trainPrefab, transform);
    }
}
