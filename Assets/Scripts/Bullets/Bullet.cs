using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [field: SerializeField, Header("Components")]
    private Rigidbody2D Rb { get; set; }

    [field: SerializeField]
    private GameObject Visual { get; set; }

    [field: SerializeField]
    private bool HasDamageParticles { get; set; }

    [field: SerializeField]
    private ParticleSystem OnHitParticleSystemPrefab { get; set; }

    [field: SerializeField, Header("Variables")]
    private float Speed { get; set; }

    [field: SerializeField]
    public float HitDamage { get; private set; }
    public GameObject Owner { get; private set; }

    private Quaternion Direction { get; set; } = Quaternion.identity;

    public virtual float DespawnTime { get; } = 15.0f;

    private float _timer = 0.0f;
    private bool _hit = false;

    public virtual void Go(Quaternion direction, GameObject owner)
    {
        Direction = direction;
        transform.rotation = Direction;
        Owner = owner;
    }

    private void Update()
    {
        if (!_hit)
        {
            Move();
            CheckForDespawn();
        }
    }

    public virtual void Move()
    {
        Rb.velocity = transform.right * Speed;
    }

    private void CheckForDespawn()
    {
        _timer += Time.deltaTime;

        if (_timer >= DespawnTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnHit(Collider2D collision)
    {
        Rb.velocity = Vector2.zero;
        _hit = true;

        Visual.SetActive(false);

        DoHitDamage(collision);

        // Instantiate the particle system prefab
        if (!HasDamageParticles)
        {
            Destroy(gameObject);
            return;
        }

        ParticleSystem hitParticle = Instantiate(OnHitParticleSystemPrefab, transform.position, Quaternion.identity, transform);
        hitParticle.Play();

        // Destroy Bullet after Particle finished playing
        Destroy(gameObject, hitParticle.main.duration);
    }

    protected virtual void DoHitDamage(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Entity entity))
        {
            return;
        }

        entity.Damage(HitDamage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp") || collision.CompareTag("Bullet"))
            return;
        if (collision.gameObject == Owner)
            return;

        OnHit(collision);
    }
}
