using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    public GameObject shieldPrefab;
    public Transform player;

    private float nextSpawnZ = 0f;
    private float fixedY = 2.0f;
    private float[] lanes = { -2.5f, 0f, 2.5f };

    void Start()
    {
        if (shieldPrefab == null || player == null)
        {
            Debug.LogError("ShieldSpawner: Missing prefab or player!");
            enabled = false;
            return;
        }

        ScheduleNextSpawn();
    }

    void Update()
    {
        if (player.position.z >= nextSpawnZ)
        {
            SpawnShield();
            ScheduleNextSpawn();
        }
    }

    void ScheduleNextSpawn()
    {
        // Next spawn is 60–80 units ahead of current player Z
        float interval = Random.Range(60f, 80f);
        nextSpawnZ = player.position.z + interval;
        Debug.Log($" Next Shield scheduled at Z = {nextSpawnZ:F2}");
    }

    void SpawnShield()
    {
        float x = lanes[Random.Range(0, lanes.Length)];
        float z = player.position.z + 25f;
        Vector3 spawnPos = new Vector3(x, fixedY, z);

        Instantiate(shieldPrefab, spawnPos, Quaternion.identity);
        Debug.Log($" Spawned Shield at {spawnPos}");
    }
}
