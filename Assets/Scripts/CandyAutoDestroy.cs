using UnityEngine;

public class CandyAutoDestroy : MonoBehaviour
{
    private Transform player; // now private
    public float destroyDistanceBehind = 10f;

    void Start()
    {
        // Automatically find the Player in the scene at runtime
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
