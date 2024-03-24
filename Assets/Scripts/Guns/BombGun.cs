using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGun : Gun
{
    public override void Shoot()
    {
        base.Shoot();
    }

    public override void ShootSound()
    {
        AudioManager.Play(Sound.SoundId.BombShoot);
    }
}
