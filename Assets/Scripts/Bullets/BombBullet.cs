using UnityEngine;

public class BombBullet : Bullet
{
    [field: SerializeField]
    private float ExplosionRange { get; set; }

    [field: SerializeField]
    private LayerMask LayerMask { get; set; }

    private float _defaultExplosionRange;

    public override void Go(Quaternion direction, GameObject owner)
    {
        base.Go(direction, owner);
        _defaultExplosionRange = ExplosionRange;
    }
    protected override void DoHitDamage(Collider2D collision)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, ExplosionRange, LayerMask);

        foreach (Collider2D collider in colliders)
        {
            if (Owner == collider.gameObject)
                continue;

            collider.GetComponent<Entity>().Damage(HitDamage);
        }

        AudioManager.Play(Sound.SoundId.BombExplode);
    }

    public void SetExplosionRange(float newRange)
    {
        ExplosionRange = newRange;
    }

    public void ResetExplosionRange()
    {
        ExplosionRange = _defaultExplosionRange;
    }
}
