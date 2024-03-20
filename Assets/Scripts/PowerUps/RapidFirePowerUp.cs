using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFirePowerUp : PowerUp
{
    public float ShootSpeedModifier { get; } = 0.5f;

    private PlayerController _playerController;

    public RapidFirePowerUp()
    {
        OnExpired += PowerUpOnExpired;
    }

    public RapidFirePowerUp(float duration)
        : base(duration)
    {
        OnExpired += PowerUpOnExpired;
    }

    public override void OnPickup(PlayerController player)
    {
        _playerController = player;
        _playerController.Gun.SetTimeBetweenShots(_playerController.Gun.GetBaseTimeBetweenShots() * ShootSpeedModifier);
    }

    private void PowerUpOnExpired()
    {
        _playerController.Gun.ResetTimeBetweenShots();
    }
}
