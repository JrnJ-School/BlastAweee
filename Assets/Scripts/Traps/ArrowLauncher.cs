using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : Gun
{
    [field: SerializeField]
    public float AimRotation { get; private set; }

    protected override void OnAwake()
    {
        Aim(new Quaternion(0.0f, 0.0f, AimRotation, 0.0f));
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}
