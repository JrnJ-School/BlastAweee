using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : Enemy
{
    [field: SerializeField]
    public float TimeBetweenJumps { get; private set; }

    [field: SerializeField]
    public float JumpDuration { get; private set; }

    public float TimeTillJump { get; private set; } = 0.0f;
    public float TimeJumping { get; private set; } = 0.0f;

    private void Awake()
    {
        TimeTillJump = TimeBetweenJumps;
    }

    public override void OnUpdate()
    {
        TimeTillJump -= Time.deltaTime;

        base.OnUpdate();
    }

    public override void Move()
    {
        if (Target == null)
        {
            return;
        }

        if (TimeTillJump > 0.0f)
        {
            return;
        }

        if (TimeJumping >= JumpDuration)
        {
            TimeTillJump = TimeBetweenJumps;
            TimeJumping = 0.0f;
            StopMoving();
            return;
        }

        Vector2 _moveDirection = (Target.position - transform.position).normalized;
        Rb.velocity = _moveDirection * Speed;

        TimeJumping += Time.deltaTime;
    }

    private void StopMoving()
    {
        Rb.velocity = Vector2.zero;
    }
}
