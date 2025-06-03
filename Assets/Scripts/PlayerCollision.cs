using UnityEngine;

public class PlayerCollision : MonoBehaviour
{


void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Obstacle"))
    {
        GameManager.instance.LoseLife();

        // Disable the collider FIRST to stop further triggers
        other.enabled = false;

        // Then destroy the whole GameObject
        Destroy(other.gameObject);
    }
}


}
