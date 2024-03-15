using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFirePowerUp : PowerUp
{
    public float ShootSpeedModifier { get; } = 0.5f;

    private PlayerController _playerController;

    public override void OnPickup(PlayerController player)
    {
        _playerController = player;
        _playerController.Gun.SetTimeBetweenShots(_playerController.Gun.GetBaseTimeBetweenShots() * ShootSpeedModifier);
    }

    public override void OnExpired()
    {
        _playerController.Gun.ResetTimeBetweenShots();   
    }
}
