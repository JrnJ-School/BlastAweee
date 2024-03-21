using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaBlastRadiusPowerUp : PowerUp
{
    private PlayerController _playerController;

    public float ExplosionRange { get; private set; } = 3.0f;

    public MegaBlastRadiusPowerUp()
    {
        OnExpired += PowerUpOnExpired;
    }

    public MegaBlastRadiusPowerUp(float duration)
        : base(duration)
    {
        OnExpired += PowerUpOnExpired;
    }

    public override void OnPickup(PlayerController player)
    {
        _playerController = player;
        _playerController.Gun.BulletPrefab.GetComponent<BombBullet>().SetExplosionRange(ExplosionRange);
    }

    private void PowerUpOnExpired()
    {
        _playerController.Gun.BulletPrefab.GetComponent<BombBullet>().ResetExplosionRange();
    }
}
