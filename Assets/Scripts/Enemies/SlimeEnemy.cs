using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MeleeEnemy
{
    [field: SerializeField]
    private float TimeBetweenJumps { get; set; }

    [field: SerializeField]
    private float JumpDuration { get; set; }

    private float TimeTillJump { get; set; } = 0.0f;
    private float TimeJumping { get; set; } = 0.0f;

    private Vector3 _targetPositionWhenJumped = Vector3.zero;
    private bool _isJumping = false;

    protected override void OnAwake()
    {
        TimeTillJump = TimeBetweenJumps;
    }

    protected override void OnUpdate()
    {
        TimeTillJump -= Time.deltaTime;

        base.OnUpdate();
    }

    protected override void Move()
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

        if (!_isJumping)
        {
            StartJump();
        }

        Vector3 _moveDirection = (_targetPositionWhenJumped - transform.position).normalized;
        Rb.velocity = _moveDirection * Speed;

        TimeJumping += Time.deltaTime;
    }

    private void StartJump()
    {
        _targetPositionWhenJumped = Target.position;
        _isJumping = true;
    }

    private void StopMoving()
    {
        Rb.velocity = Vector3.zero;
        _isJumping = false;
    }
}
