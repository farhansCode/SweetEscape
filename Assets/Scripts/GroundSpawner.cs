using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTilePrefab;
    public Transform player;
    public int numTilesOnScreen = 5;
    public float tileLength = 30f;

    private float zSpawn = 0f;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < numTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (player.position.z > zSpawn - (numTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteOldestTile();
        }
    }

   void SpawnTile()
{
    GameObject tileObj = Instantiate(groundTilePrefab, new Vector3(0, 0, zSpawn), Quaternion.identity);
    GroundTile tile = tileObj.GetComponent<GroundTile>();

    // 50% chance to get candy (or just force true for now)
    tile.containsCandy = Random.value > 0.5f; 

    zSpawn += tileLength;
}


    void DeleteOldestTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
