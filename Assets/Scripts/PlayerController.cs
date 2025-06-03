using UnityEngine;
using TMPro; 

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float laneDistance = 2.5f; // Left, Center, Right
    private int currentLane = 1;

    private CharacterController controller;
    private Vector3 moveVector;
    public float jumpForce = 8f;
    private float verticalVelocity;
    public float gravity = 20f;
    private int score = 0;
    public TMP_Text scoreText; 

    public int lives = 3;

    private bool shieldActive = false;
    private float shieldTimer = 0f;
    public float shieldDuration = 5f; // Shield lasts 5 seconds



    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveVector = Vector3.forward * forwardSpeed;

        // Lane switching
        if (Input.GetKeyDown(KeyCode.A) && currentLane > 0)
            currentLane--;
        if (Input.GetKeyDown(KeyCode.D) && currentLane < 2)
            currentLane++;

        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (currentLane == 0) targetPosition += Vector3.left * laneDistance;
        else if (currentLane == 2) targetPosition += Vector3.right * laneDistance;

        Vector3 diff = targetPosition - transform.position;
        moveVector.x = diff.x * 10f;

        // Jumping
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
            if (Input.GetKeyDown(KeyCode.Space))
                verticalVelocity = jumpForce;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.y = verticalVelocity;
        controller.Move(moveVector * Time.deltaTime);


        if (shieldActive)
        {
        shieldTimer -= Time.deltaTime;

        if (shieldTimer <= 0f)
         {
            shieldActive = false;
            Debug.Log("Shield expired!");
         }
        }
    }

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Candy"))
    {
        score += 1;
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        Debug.Log("Collected Candy! Score: " + score);
        Destroy(other.gameObject);
    }

    if (other.CompareTag("Obstacle"))
    {
        if (shieldActive)
        {
            Destroy(other.gameObject); // Smash the obstacle!
            Debug.Log("Obstacle destroyed by shield!");
        }
        else
        {
            GameManager.instance.LoseLife();
            Destroy(other.gameObject);
        }
    }
    else if (other.CompareTag("ShieldPowerUp"))
    {
        ActivateShield();
        Destroy(other.gameObject); // Destroy the shield pickup after collecting
    }
}

public int GetScore()
{
    return score;
}

public int GetLives()
{
    return lives;
}

void ActivateShield()
{
    shieldActive = true;
    shieldTimer = shieldDuration;
    Debug.Log("Shield Activated!");
}




}
