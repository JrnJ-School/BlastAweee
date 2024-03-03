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
    public LayerMask LayerMask { get; private set; }

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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, DetectionRange, LayerMask);

        foreach (Collider2D collider in colliders)
        {
            //Vector2 direction = (collider.transform.position - transform.position).normalized;
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, DetectionRange, LayerMask);

            //// Check if there is a hit
            //if (hit.collider != null && hit.collider == collider)
            //{
            //    // You may want to add additional checks here based on your requirements

            //}
            //else
            //{
            //    Debug.Log($"Collider: {collider} | Hit: {hit.collider}");
            //    Debug.Log("meow");
            //}

            Target = collider.gameObject.transform;
        }
    }

    protected override void EntityDied()
    {
        StatisticsManager.EnemyKillStatistic.AddValue(1);

        base.EntityDied();
    }

    public virtual void Move()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DetectionRange);
    }
}
