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

        if (InputReader.Instance.menuOpen)
        {
            _nextSpawn += Time.deltaTime;
        }
    }

    void SpawnTrain()
    {
        TriggerAudioCollection.Instance.PlayAudioSource(EAudioType.SFX_Train_Annoucement, 1, true);
        Instantiate(trainPrefab, transform);
        StartCoroutine(SecondSound());
    }
    private IEnumerator SecondSound()
    {
        yield return new WaitForSeconds(3f);
        TriggerAudioCollection.Instance.PlayAudioSource(EAudioType.SFX_Train, 1, true);
    }
}
