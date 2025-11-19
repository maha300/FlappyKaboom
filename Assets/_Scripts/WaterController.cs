using UnityEngine;

public class WaterController : MonoBehaviour
{
    [Header("Water Movement")]
    public float jumpForce = 6f;          // Upward push when you press space
    public float gravity = -9f;           // Downward pull
    public float maxFallSpeed = -5f;      // Limits fall speed

    [Header("Water Position Limits")]
    public float topLimit = 3f;           // Highest Y the water can reach
    public float bottomLimit = -3f;       // Lowest Y the water can fall

    [Header("Fish Settings")]
    public Transform fish;                // Drag your fish GameObject here
    public float rotationMultiplier = 5f; // Controls how fast the fish rotates

    private float verticalVelocity = 0f;

    void Update()
    {
        HandleWaterMovement();
        RotateFish();
    }

    void HandleWaterMovement()
    {
        // When you press space → water rises
        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        }

        // Apply gravity to bring water back down
        verticalVelocity += gravity * Time.deltaTime;

        // Limit how fast water can fall
        verticalVelocity = Mathf.Max(verticalVelocity, maxFallSpeed);

        // Move the water vertically
        transform.Translate(0, verticalVelocity * Time.deltaTime, 0);

        // Clamp the water between limits
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, bottomLimit, topLimit);
        transform.position = pos;
    }

    void RotateFish()
    {
        if (fish == null) return;

        // tilt fish up when rising, down when falling
        float rotationZ = verticalVelocity * rotationMultiplier;

        fish.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
