using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CombatController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float health;
    [SerializeField]
    private float attackRange;
    [SerializeField] private Collider Collider;
    [SerializeField] private LayerMask AttackLayer;

    [SerializeField] bool isPlayer = false;


    public float Health { get => health; set => health = value; }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != gameObject.layer)
        {
            Debug.Log("Collision on different layers!");

            if (collision.gameObject.layer is 7)
            {
                //Enemy hit!
                Debug.Log("Enemy was hit!!");
                var otherCombatController = collision.gameObject.GetComponent<CombatController>();
                if (otherCombatController)
                {
                    otherCombatController.TakeDamage(20);
                }
                Debug.Log("Trying to find FollowTarget!");
                var otherFollowTarget = collision.gameObject.GetComponent<FollowTarget>();
                if (otherFollowTarget)
                {
                    Debug.Log("FollowTarget foud!");
                    var closest = collision.ClosestPointOnBounds(collision.transform.position);
                    Debug.Log("closest: " + closest);
                    Debug.Log("position: " + collision.transform.position);
                    otherFollowTarget.ApplyKnockback(new Vector2(20, 0));
                } 
                else
                {
                    Debug.Log("No FollowTarget found!");
                }            }
            // if (collision.gameObject.layer is 6)
            // {
            //     //Player hit!
            //     Debug.Log("Player was hit!!");
            //     var otherCombatController = collision.gameObject.GetComponent<CombatController>();
            //     if (otherCombatController)
            //     {
            //         otherCombatController.TakeDamage(20);
            //     }
            //     
            //     PlayerController.Instance.ApplyKnockback(new Vector2(10, 10));
            // }
        }
        else
        {
            Debug.Log("Collision is on same layer...");
        }
    }

    public void TakeDamage(float amount)
    {
        Debug.Log(isPlayer ? "Player taking damage!" : "Enemy taking damage!");
        if (Health > 0)
        {
            Health -= amount;
            OnomatopoeiaSpawner.Instance.InstantiateAt(transform.position);
        }
        if(Health <= 0)
        {
            if (isPlayer)
            {
                PlayerController.Instance.GameOver();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void ThrowCake()
    {

    }
}
