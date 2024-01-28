using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

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

    public bool TakeDamage(float amount, DamageType type)
    {
        health -= amount;
        Debug.Log("Took " + amount + " damage. Remaining health: " + health);
        TriggerAudioCollection.Instance.PlaySound(EAudioType.Narration_Ouch);

        if (health <= 0)
        {
            Die(type);
        }

        return health > 0;
    }

    private void Die(DamageType type)
    {
        if (isPlayer)
        {
            PlayerController.Instance.GameOver();
            TriggerAudioCollection.Instance.PlaySound(EAudioType.Narration_ThatMustHaveHurt);
        }
        else
        {
            switch (type)
            {
                case DamageType.Crush:
                    {
                        gameObject.AddComponent<Death_Flatten>();
                        break;
                    }
                case DamageType.KnockbackLeft:
                case DamageType.KnockbackRight:
                    {
                        gameObject.AddComponent<Death_FlyIntoScreen>();
                        break;
                    }
                default:
                    {
                        Destroy(gameObject);
                        break;
                    }
            }
        }
    }

}
