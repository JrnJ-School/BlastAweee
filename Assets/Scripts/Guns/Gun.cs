using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [field: SerializeField, Header("Components")]
    public Transform Pivot { get; private set; }

    [field: SerializeField]
    public Transform BulletSpawn { get; private set; }

    [field: SerializeField]
    public PlayerController Owner { get; private set; }

    [field: SerializeField, Header("Variables")]
    public float TimeBetweenShots { get; private set; } // In Seconds

    [field: SerializeField]
    public float KnockbackSpeed { get; private set; }

    [field: SerializeField]
    public float KnockbackTime { get; private set; }

    [field: SerializeField]
    public GameObject BulletPrefab { get; private set; }

    private bool _isEnabled = true;
    private float _timer = 0.0f;
    private Quaternion _aimDirection = Quaternion.identity;

    private void Update()
    {
        if (!_isEnabled)
        {
            return;
        }

        TryAutoShoot();
    }

    #region Aiming
    public virtual void Aim(Quaternion aimDirection)
    {
        _aimDirection = aimDirection;
        Pivot.rotation = _aimDirection;
    }
    #endregion

    #region Shooting
    public virtual void Shoot()
    {
        // Spawn Bullet
        GameObject bullet = Instantiate(BulletPrefab, BulletSpawn.position, Quaternion.identity, transform);
        bullet.GetComponent<Bullet>().Go(_aimDirection);

        // Knockback Player
        Owner.TakeKnockback((_aimDirection.eulerAngles.z + 180.0f) % 360.0f, KnockbackSpeed, KnockbackTime);
    }

    public void Enable()
    {
        _isEnabled = true;
    }

    public void Disable()
    {
        _isEnabled = false;
    }

    private void TryAutoShoot()
    {
        _timer += Time.deltaTime;

        if (_timer >= TimeBetweenShots)
        {
            Shoot();
            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        _timer = 0.0f;
    }
    #endregion Shooting
}
