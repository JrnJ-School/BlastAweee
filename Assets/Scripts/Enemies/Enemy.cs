using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : Entity
{
    [field: SerializeField]
    public float DetectionRange { get; private set; }

    [field: SerializeField]
    public LayerMask CanInteruptLayerMasks { get; private set; }

    [field: SerializeField]
    public LayerMask CanAttackLayerMasks { get; private set; }

    public Transform Target { get; set; }

    private void Update()
    {
        OnUpdate();
    }

    public virtual void OnUpdate()
    {
        if (Target == null)
        {
            CheckForTarget();
        }

        Move();
    }

    private void CheckForTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, DetectionRange, CanAttackLayerMasks);

        foreach (Collider2D collider in colliders)
        {
            Vector2 direction = (collider.transform.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, DetectionRange, CanInteruptLayerMasks);
            
            if (hit.collider != null)
            {
                if (LayerMask.LayerToName(hit.collider.gameObject.layer) == "Player")
                {
                    Target = collider.gameObject.transform;
                }
            }
        }
    }

    protected override void EntityDied()
    {
        StatisticsManager.EnemyKillStatistic.AddValue(1);
        DropLoot();

        base.EntityDied();
    }

    public virtual void Move()
    {

    }

    protected virtual void DropLoot()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Target.transform == null)
            return;

        if (collision.transform != Target.transform)
            return;

        Debug.Log("ATTACK Trigger");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DetectionRange);
    }
}
