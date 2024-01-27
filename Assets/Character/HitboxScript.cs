using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class HitboxScript : MonoBehaviour
{
    public float damageAmount = 10f;
    public float verticalKnockback = 5f;
    public float horizontalKnockback = 10f;
    public bool affectsPlayer = false;
    public bool affectsEnemies = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hitbox collided!");
        var healthManager = other.gameObject.GetComponent<HealthManager>();
        if (!healthManager) return;
        if (affectsPlayer && other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Hitbox with player!");
            healthManager.TakeDamage(damageAmount);
            var playerPosition = other.transform.position;
            var horizontalDirection = (playerPosition - transform.position).normalized.x > 0 ? 1 : -1;
            PlayerController.Instance.ApplyKnockback(new Vector2(horizontalKnockback * horizontalDirection, verticalKnockback));
        }
        if (affectsEnemies && other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hitbox with enemy!");
            healthManager.TakeDamage(damageAmount);
            OnomatopoeiaSpawner.Instance.InstantiateAt(other.transform.position);
            var horizontalDirection = (other.gameObject.transform.position - PlayerController.Instance.transform.position).normalized.x > 0 ? 1 : -1;
            var otherFollowTarget = other.gameObject.GetComponent<FollowTarget>();
            otherFollowTarget.ApplyKnockback(new Vector2(horizontalKnockback * horizontalDirection, verticalKnockback));
        }
    }
}
