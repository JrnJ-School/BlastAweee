using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaBlastRadiusPowerUpItem : PowerUpPickupable
{
    public override PowerUp ToPowerUp()
    {
        return new MegaBlastRadiusPowerUp(Duration)
        {
            Name = Name,
            Icon = Icon
        };
    }
}
