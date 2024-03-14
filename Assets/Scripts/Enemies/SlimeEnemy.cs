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

    private Vector3 _targetPositionWhenJumped = Vector3.zero;
    private bool _isJumping = false;

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
