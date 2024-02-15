using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [field: SerializeField, Header("Components")]
    public Rigidbody2D Rb { get; private set; }

    [field: SerializeField, Header("Variables")]
    public float Speed { get; private set; }

    [field: SerializeField]
    public float MaxHealth { get; private set; }
    public float Health { get; private set; }

    [HideInInspector]
    public float ActiveMoveSpeed = 0.0f;

    public void Damage(float amount)
    {
        if (Health - amount <= 0)
        {
            EnemyDied();
            return;
        }

        Health -= amount;
    }

    public void Heal(float amount)
    {
        if (Health + amount > MaxHealth)
        {
            Health = MaxHealth;
            return;
        }

        Health += amount;
    }

    private void EnemyDied()
    {

    }
}
