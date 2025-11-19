using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    [Header("Water Reference")]
    public Transform water;        // Drag your WaterContainer here

    [Header("Spawn Settings")]
    public float spawnInterval = 2f;
    public float verticalOffset = 1.5f; // size of spawn range above/below fish

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 1f, spawnInterval);
    }

    void SpawnObstacle()
    {
        if (water == null)
        {
            Debug.LogError("Water reference not set on ObstacleSpawner!");
            return;
        }

        // Choose a Y position relative to water
        float randomY = water.position.y + Random.Range(-verticalOffset, verticalOffset);

        Vector3 spawnPos = new Vector3(
            transform.position.x, // spawner’s X stays the same
            randomY,
            0f
        );

        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
