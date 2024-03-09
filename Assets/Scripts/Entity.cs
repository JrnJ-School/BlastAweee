using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    public bool TakingKnockback { get; private set; }
    public virtual bool IsPlayer { get; } = false;

    protected Vector2 _moveDirection = Vector2.zero;
    private float _knockbackTimer;
    private float _knockbackTime;

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

    // Knockback
    public void TakeKnockback(float direction, float speed, float time)
    {
        _moveDirection = new Vector2(
            Mathf.Cos(direction * Mathf.Deg2Rad),
            Mathf.Sin(direction * Mathf.Deg2Rad)
            ).normalized;

        ActiveMoveSpeed = speed;
        TakingKnockback = true;
        _knockbackTime = time;
    }
    protected void DoTakeKnockback()
    {
        _knockbackTimer += Time.deltaTime;

        // Check for End of Dash
        if (_knockbackTimer >= _knockbackTime)
        {
            FinishTakeKnockback();
            return;
        }
    }
    protected void FinishTakeKnockback()
    {
        TakingKnockback = false;
        _knockbackTimer = 0.0f;
        _knockbackTime = 0.0f;
        ActiveMoveSpeed = Speed;
    }
}
