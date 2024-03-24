using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [field: SerializeField]
    private float AttackDamage { get; set; }

    [field: SerializeField]
    private float AttackCooldown { get; set; }

    private bool _canAttack = true;
    private float _attackCooldownTimer;

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (!_canAttack)
        {
            _attackCooldownTimer -= Time.deltaTime;

            if (_attackCooldownTimer <= 0.0f)
            {
                _canAttack = true;
            }
        }
    }

    protected virtual void Attack(Entity entity)
    {
        _attackCooldownTimer = AttackCooldown;
        _canAttack = false;

        entity.Damage(AttackDamage);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Target == null || Target.transform == null)
            return;

        if (collision.transform != Target.transform)
            return;

        if (_canAttack)
        {
            if (collision.TryGetComponent<Entity>(out Entity entity))
            {
                Attack(entity);
            }
        }
    }
}
