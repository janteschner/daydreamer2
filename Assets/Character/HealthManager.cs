using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
        [SerializeField]
        private float health = 100;
        
        [SerializeField]
        private bool isPlayer;


        public float Health
        {
                get => health;
        }

        public void TakeDamage(float amount)
        {
                health -= amount;
                if (health <= 0)
                {
                        Die();
                }
        }

        private void Die()
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
