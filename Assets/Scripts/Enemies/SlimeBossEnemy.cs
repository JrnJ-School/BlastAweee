using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBossEnemy : SlimeEnemy
{
    [field: SerializeField]
    public float TimeBetweenSlimeSpawns { get; private set; }

    [field: SerializeField]
    public GameObject SlimeEnemyPrefab { get; private set; }

    [field: SerializeField]
    public GameObject KeyPrefab { get; private set; }

    private float _slimeSpawnTimer = 0.0f;

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (Target == null) return;

        _slimeSpawnTimer += Time.deltaTime;

        if (_slimeSpawnTimer >= TimeBetweenSlimeSpawns)
        {
            _slimeSpawnTimer = 0.0f;
            Instantiate(SlimeEnemyPrefab, this.transform);
            Instantiate(SlimeEnemyPrefab, this.transform);
            Instantiate(SlimeEnemyPrefab, this.transform);
            Instantiate(SlimeEnemyPrefab, this.transform);
        }
    }

    protected override void DropLoot()
    {
        Instantiate(KeyPrefab, this.transform.position, Quaternion.identity);
    }
}
