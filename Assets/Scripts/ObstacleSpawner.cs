using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;

    public float spawnEveryZUnits = 15f; // Spawn obstacles every 15 units moved
    private float nextSpawnZ;

    private float fixedY = 0.5f;
    private float[] lanes = { -2.5f, 0f, 2.5f };

    void Start()
    {
        if (player == null || obstaclePrefab == null)
        {
            Debug.LogError("ObstacleSpawner: Player or obstaclePrefab not assigned!");
            enabled = false;
            return;
        }

        nextSpawnZ = player.position.z + spawnEveryZUnits;
    }

    void Update()
    {
        if (player.position.z >= nextSpawnZ)
        {
            SpawnObstacles(); // blocks 2 out of 3 lanes
            nextSpawnZ += spawnEveryZUnits;
        }
    }

    public void SpawnObstacles()
    {
        int openLaneIndex = Random.Range(0, lanes.Length); // pick a lane to leave empty

        for (int i = 0; i < lanes.Length; i++)
        {
            if (i == openLaneIndex) continue;

            float x = lanes[i];
            float y = fixedY;
            float z = player.position.z + 30f + Random.Range(-1f, 1f);

            Vector3 spawnPos = new Vector3(x, y, z);
            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        }

        Debug.Log("Spawned obstacle set — left lane " + lanes[openLaneIndex] + " open.");
    }
}
