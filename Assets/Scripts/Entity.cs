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
    [HideInInspector]
    public float TargetMoveSpeed = 0.0f;

    private void Awake()
    {
        Health = MaxHealth;
    }

    public void Damage(float amount)
    {
        if (Health - amount <= 0)
        {
            EntityDied();
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

    protected virtual void EntityDied()
    {
        // provide killer to award xp or something

        Destroy(gameObject);
    }
}
