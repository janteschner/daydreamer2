using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float health;
    [SerializeField]
    private float attackRange;
    [SerializeField] private Collider Collider;
    [SerializeField] private LayerMask AttackLayer;

    [SerializeField] bool isPlayer = false, isEnemy = false;
    [SerializeField] GameObject spawnPoint;


    public float Health { get => health; set => health = value; }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.layer);
        //if(collision.gameObject.layer == 8)
        //{
        //    collision.gameObject.transform.SetParent(transform, false);
        //    collision.gameObject.transform.position= Vector3.zero;
        //}

        //if(collision.gameObject.layer == 7)
        //{
        //    Health -= 10;
        //}

        //if(collision.gameObject.layer == 6)
        //{

        //}

    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.transform.SetParent(spawnPoint.transform, false);
            collision.gameObject.transform.position = spawnPoint.transform.position;
        }
        
        if ((isPlayer && collision.gameObject.layer == 7) || (isEnemy && collision.gameObject.layer == 6))
        {
            if (Health > 0)
            {
                Health -= 10;
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }

    private void CheckCollision()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, AttackLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

    }
}
