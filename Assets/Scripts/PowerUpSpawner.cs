using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [field: SerializeField, Header("Components")]
    public Transform SpawnParent { get; private set; }

    [field: SerializeField]
    public Transform PowerUpSpawnLocations { get; private set; }

    [field: SerializeField]
    public List<Vector2> SpawnLocations { get; private set; }

    [field: SerializeField]
    public List<GameObject> PowerUpsPrefabs { get; private set; }

    [field: SerializeField, Header("Variables")]
    public float SpawnTime { get; private set; }
    private float _powerUpSpawnTimer = 0.0f;

    private bool _doSpawning = true;

    private void Awake()
    {
        // Get Spawn Locations
        SpawnLocations = new();
        for (int i = 0; i < PowerUpSpawnLocations.childCount; i++)
        {
            SpawnLocations.Add(PowerUpSpawnLocations.GetChild(i).position);
        }
    }

    void Update()
    {
        if (!_doSpawning)
            return;

        _powerUpSpawnTimer += Time.deltaTime;
        if (_powerUpSpawnTimer >= SpawnTime)
        {
            SpawnPowerUp();
        }
    }

    public void SpawnPowerUp(Transform location)
    {
        SpawnPowerUp(location, null);
    }
    public void SpawnPowerUp(GameObject powerUpPrefab)
    {
        SpawnPowerUp(null, powerUpPrefab);
    }
    public void SpawnPowerUp(Transform location = null, GameObject powerUpPrefab = null)
    {
        // Get Random location if none set
        Vector2 locationPos = Vector2.zero;
        if (location == null)
        {
            locationPos = SpawnLocations[(int)Random.Range(0.0f, SpawnLocations.Count)];
        }
        else
        {
            locationPos = location.position;
        }

        // Get Random PowerUp if none set
        if (powerUpPrefab == null)
        {
            powerUpPrefab = PowerUpsPrefabs[(int)Random.Range(0.0f, PowerUpsPrefabs.Count)];
        }

        SpawnPowerUp(locationPos, powerUpPrefab);
    }
    public void SpawnPowerUp(Vector2 location, GameObject powerUpPrefab)
    {
        // Spawn
        Instantiate(powerUpPrefab, location, Quaternion.identity, SpawnParent);

        ResetTimer();
    }

    private void ResetTimer()
    {
        _powerUpSpawnTimer = 0.0f;
    }
}
