using UnityEngine;

public class BombBullet : Bullet
{
    [field: SerializeField]
    public float ExplosionRange { get; private set; }

    [field: SerializeField]
    public LayerMask LayerMask { get; private set; }

    private float _defaultExplosionRange;

    private void Awake()
    {
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
