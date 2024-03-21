using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoKnockbackPowerUp : PowerUp
{
    private PlayerController _playerController;

    public NoKnockbackPowerUp()
    {
        OnExpired += PowerUpOnExpired;
    }

    public NoKnockbackPowerUp(float duration)
        : base(duration)
    {
        OnExpired += PowerUpOnExpired;
    }

    public override void OnPickup(PlayerController player)
    {
        _playerController = player;
        _playerController.TakesKnockback = false;
    }

    private void PowerUpOnExpired()
    {
        _playerController.TakesKnockback = true;
    }
}
