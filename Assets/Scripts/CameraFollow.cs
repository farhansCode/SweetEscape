using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // The player
    public Vector3 offset = new Vector3(0, 5, -10); // Camera position relative to player
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target); // Keeps the camera facing the player
    }
}
