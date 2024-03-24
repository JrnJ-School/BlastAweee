using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : Enemy, IGunEntity
{
    [field: SerializeField]
    private float DistanceToKeep { get; set; }

    [field: SerializeField]
    private BowGun Gun { get; set; }

    private Quaternion _aimDirection = Quaternion.identity;

    protected override void OnUpdate()
    {
        if (Target != null)
        {
            AimGun();
        }
        base.OnUpdate();
    }

    protected override void Move()
    {
        // Evade Player instead of going towards it
        // so the skeleton will keep a distance from the player and shoot it with the bow
        if (Target == null)
        {
            // Handle the case when the target is not set
            return;
        }

        Vector2 directionToPlayer = (transform.position - Target.position).normalized;
        Vector2 targetPosition = (Vector2)Target.position + directionToPlayer * DistanceToKeep;

        // Check if the enemy is already at the desired distance
        if (Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            // Calculate the velocity to reach the target position
            Vector2 velocity = (targetPosition - (Vector2)transform.position).normalized * Speed;

            // Set the velocity directly
            Rb.velocity = velocity;
        }
        else
        {
            // If already at the desired distance, stop moving
            Rb.velocity = Vector2.zero;
        }
    }

    public void AimGun()
    {
        // Calculate Angle
        Vector2 direction = new Vector2(Target.position.x, Target.position.y) - new Vector2(Gun.Pivot.position.x, Gun.Pivot.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _aimDirection = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));

        // Aim Gun
        Gun.Aim(_aimDirection);
    }
}
