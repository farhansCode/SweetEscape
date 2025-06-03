using UnityEngine;

public class GroundTile : MonoBehaviour
{
    
    public ObstacleSpawner obstacleSpawner;
    
    public bool containsCandy = false;

    void Start()
{
   

    if (obstacleSpawner != null)
    {
        obstacleSpawner.SpawnObstacles();
    }
}

}
