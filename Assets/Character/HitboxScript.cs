using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class HitboxScript : MonoBehaviour
{
    public float damageAmount = 10f;
    public float verticalKnockback = 5f;
    public float horizontalKnockback = 10f;
    public bool affectsPlayer = false;
    public bool affectsEnemies = false;
    public DamageType damageType = DamageType.Crush;
    public bool noBubble = false;


    private List<Collider> _alreadyHit;
    
    // Start is called before the first frame update
    void Start()
    {
        _alreadyHit = new List<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other) return;
        if (_alreadyHit.Contains(other)) return;
        _alreadyHit.Append(other);
        Debug.Log("Hitbox collided!");
        var healthManager = other.gameObject.GetComponent<HealthManager>();
        if (!healthManager) return;
        if (affectsPlayer && other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Hitbox with player!");
            var playerPosition = other.transform.position;
            var horizontalDirection = (playerPosition - transform.position).normalized.x > 0 ? 1 : -1;
            var usedDamageType = damageType;
            if (damageType == DamageType.KnockbackRight)
            {
                if (horizontalDirection < 0)
                {
                    usedDamageType = DamageType.KnockbackLeft;
                }
            }
            var survived = healthManager.TakeDamage(damageAmount, usedDamageType);
            if (survived)
            {
                PlayerController.Instance.ApplyKnockback(new Vector2(horizontalKnockback * horizontalDirection, verticalKnockback));
            }
        }
        if (affectsEnemies && other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hitbox with enemy!");
            var horizontalDirection = (other.gameObject.transform.position - PlayerController.Instance.transform.position).normalized.x > 0 ? 1 : -1;
            var usedDamageType = damageType;
            if (damageType == DamageType.KnockbackRight)
            {
                if (horizontalDirection < 0)
                {
                    usedDamageType = DamageType.KnockbackLeft;
                }
            }

            if (!noBubble)
            {
                OnomatopoeiaSpawner.Instance.InstantiateAt(other.transform.position + Vector3.up);
            }
            var survived = healthManager.TakeDamage(damageAmount, usedDamageType);
            if (survived)
            {
                var otherFollowTarget = other.gameObject.GetComponent<FollowTarget>();
                otherFollowTarget.ApplyKnockback(new Vector2(horizontalKnockback * horizontalDirection,
                    verticalKnockback));
            }
        }
    }
}
