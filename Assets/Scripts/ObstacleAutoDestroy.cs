using UnityEngine;

public class ObstacleAutoDestroy : MonoBehaviour
{
    private Transform player;
    public float destroyDistanceBehind = 10f;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        if (transform.position.z < player.position.z - destroyDistanceBehind)
        {
            Destroy(gameObject);
        }
    }
}
