using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFirePowerUpItem : PowerUpPickupable
{
    public override PowerUp ToPowerUp()
    {
        return new RapidFirePowerUp(Duration)
        {
            Name = Name,
            Icon = Icon
        };
    }
}
