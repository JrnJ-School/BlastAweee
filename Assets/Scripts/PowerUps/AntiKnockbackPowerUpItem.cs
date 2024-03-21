using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiKnockbackPowerUpItem : PowerUpPickupable
{
    public override PowerUp ToPowerUp()
    {
        return new NoKnockbackPowerUp(Duration)
        {
            Name = Name,
            Icon = Icon
        };
    }
}
