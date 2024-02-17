using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [field: SerializeField, Header("Components")]
    public Rigidbody2D Rb { get; private set; }

    [field: SerializeField]
    public GameObject Visual { get; private set; }

    [field: SerializeField]
    public ParticleSystem OnHitParticleSystemPrefab { get; private set; }

    [field: SerializeField, Header("Variables")]
    public float Speed { get; private set; }

    [field: SerializeField]
    public float HitDamage { get; private set; }

    public Quaternion Direction { get; set; } = Quaternion.identity;

    public virtual float DespawnTime { get; } = 15.0f;

    private float _timer = 0.0f;
    private bool _hit = false;

    public void Go(Quaternion direction)
    {
        Direction = direction;
        transform.rotation = Direction;
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

    private void OnHit()
    {
        Rb.velocity = Vector2.zero;
        _hit = true;

        Visual.SetActive(false);

        // Instantiate the particle system prefab
        ParticleSystem hitParticle = Instantiate(OnHitParticleSystemPrefab, transform.position, Quaternion.identity, transform);
        hitParticle.Play();

        // Destroy Bullet after Particle finished playing
        Destroy(gameObject, hitParticle.main.duration);
    }

    protected virtual void DoHitDamage()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
            return;

        OnHit();
    }
}
