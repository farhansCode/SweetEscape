using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    public GameObject candyPrefab;
    public Transform player;

    public float spawnEveryZUnits = 10f; // Spawn every 10 units moved
    public float fixedY = 2.0f;
    private float[] lanes = { -2.5f, 0f, 2.5f };

    private float nextSpawnZ;

    void Start()
    {
        if (player == null || candyPrefab == null)
        {
            Debug.LogError("CandySpawner: Player or candyPrefab not assigned!");
            enabled = false;
            return;
        }

        // Start spawning just ahead of the player
        nextSpawnZ = player.position.z + spawnEveryZUnits;
    }

    void Update()
    {
        if (player.position.z >= nextSpawnZ)
        {
            SpawnCandy();
            nextSpawnZ += spawnEveryZUnits; // Schedule next spawn
        }
    }

    void SpawnCandy()
    {
        float x = lanes[Random.Range(0, lanes.Length)];
        float y = fixedY;
        float z = player.position.z + 30f + Random.Range(-2f, 2f); // forward and varied

        Vector3 spawnPos = new Vector3(x, y, z);
        Instantiate(candyPrefab, spawnPos, Quaternion.identity);

        Debug.Log("Spawned candy at: " + spawnPos);
    }
}
