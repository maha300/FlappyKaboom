using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Auto destroy when off-screen
        if (transform.position.x < -12f)
            Destroy(gameObject);
    }
}

