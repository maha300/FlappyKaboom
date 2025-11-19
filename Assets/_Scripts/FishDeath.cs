using UnityEngine;
using UnityEngine.SceneManagement;

public class FishDeath : MonoBehaviour
{
    public WaterController waterController;
    public float restartDelay = 1.2f;

    void Start()
    {
        if (waterController == null)
            waterController = FindObjectOfType<WaterController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle") || col.CompareTag("KillZone"))
        {
            Die();
        }
    }

    void Die()
    {
        // Stop water movement
        waterController.enabled = false;

        // Optional: stop world scrolling
        MoveLeft[] movers = FindObjectsOfType<MoveLeft>();
        foreach (var m in movers) m.enabled = false;

        // Optional: rotate fish downward like a death animation
        transform.rotation = Quaternion.Euler(0, 0, -90);

        // Restart scene after delay
        Invoke("Restart", restartDelay);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

