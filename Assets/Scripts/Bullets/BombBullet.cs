using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BombBullet : Bullet
{
    [field: SerializeField]
    public float ExplosionRange { get; private set; }

    [field: SerializeField]
    public LayerMask LayerMask { get; private set; }

    protected override void DoHitDamage()
    {
        Debug.Log("meow!");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, ExplosionRange, LayerMask);

        foreach (Collider2D collider in colliders)
        {
            Debug.Log("Dmaage!");
            collider.GetComponent<Entity>().Damage(HitDamage);
        }
    }
}
