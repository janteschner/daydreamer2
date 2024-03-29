using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform SpawnLocation;
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] float ScaleFactor = 2.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        var direction = InputReader.Instance.horizontalMove > 0 ? -90 : 90;
        GameObject prefab = Instantiate(ProjectilePrefab, SpawnLocation.position, Quaternion.Euler(0, 0,direction));
        prefab.GetComponent<Projectile>().Direction = transform.forward * ScaleFactor;
    }
}
