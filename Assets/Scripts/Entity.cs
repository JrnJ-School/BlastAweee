using System;
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

    public bool TakesKnockback { get; set; } = true;

    public virtual bool IsPlayer { get; } = false;

    protected Vector2 _moveDirection = Vector2.zero;

    private float _knockbackTimer;
    private float _knockbackTime;
    private bool _isInvincible = false;

    public event Action<float> HealthChangedEvent;

    private void Awake()
    {
        Health = MaxHealth;
    }

    public void SetInvincible(bool invincible)
    {
        _isInvincible = invincible;
        Health = MaxHealth;
    }

    public void Damage(float amount)
    {
        if (_isInvincible) return;

        if (Health - amount <= 0)
        {
            EntityDied();
            return;
        }

        Health -= amount;
        HealthChangedEvent?.Invoke(Health);
    }

    public void Heal(float amount)
    {
        if (_isInvincible) return;

        if (Health + amount > MaxHealth)
        {
            Health = MaxHealth;
            return;
        }

        Health += amount;
        HealthChangedEvent?.Invoke(Health);
    }

    protected virtual void EntityDied()
    {
        // provide killer to award xp or something

        Destroy(gameObject);
    }

    // Knockback
    public void TakeKnockback(float direction, float speed, float time)
    {
        if (!TakesKnockback) return;

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
        // Should be possible, but for safety
        if (!TakesKnockback)
        {
            FinishTakeKnockback();
            return;
        }

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
