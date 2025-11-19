using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 6f;
    private Rigidbody2D rb;
    public bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;  // Stop movement after death

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.linearVelocity = Vector2.up * jumpForce;
    }

    // CALL THIS TO KILL THE BIRD
    public void Die()
    {
        if (isDead) return;

        isDead = true;

        // Stop movement
        rb.linearVelocity = Vector2.zero;

        // Optional: freeze rotation, stop physics, etc.
        rb.gravityScale = 2f;

        Debug.Log("Bird died");

        // Optional place to trigger animations, sounds, restart script, etc.
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Auto-detect collisions with pipes or ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
}
