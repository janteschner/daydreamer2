using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRandomEnemy()
    {
        var existingEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (existingEnemies.Length > 3) return;
        
        var random = new System.Random();
        
        //colors
        var randomIndex = random.Next(0, enemyPrefabs.Count);
        var selectedPrefab = enemyPrefabs[randomIndex];

        var randomX = random.NextDouble() * 14 - 7;
        Instantiate(selectedPrefab, new Vector3((float)randomX, 10f, 0), Quaternion.Euler(0, 0, 0));

    }
}
