using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBossEnemy : SlimeEnemy
{
    [field: SerializeField]
    private float TimeBetweenSlimeSpawns { get; set; }

    [field: SerializeField]
    private GameObject SlimeEnemyPrefab { get; set; }

    [field: SerializeField]
    private GameObject KeyPrefab { get; set; }

    private float _slimeSpawnTimer = 0.0f;

    protected override void OnUpdate()
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
