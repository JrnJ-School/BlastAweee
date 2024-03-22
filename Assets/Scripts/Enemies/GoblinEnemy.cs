using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemy : MeleeEnemy
{
    public override void Move()
    {
        if (Target == null)
        {
            return;
        }

        Vector2 _moveDirection = (Target.position - transform.position).normalized;
        Rb.velocity = _moveDirection * Speed;
    }
}
