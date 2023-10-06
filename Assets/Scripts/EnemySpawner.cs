using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public float spawnInterval = 5.0f; // Time interval between spawns
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;


    // Start is called before the first frame update
    void Start()
    {

         // Calculate the distance from the camera to the object
            float zDistance = transform.position.z - Camera.main.transform.position.z;

            // Get camera bounds
            Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDistance));
            Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, zDistance));

            minX = bottomLeft.x;
            maxX = topRight.x;
            minY = bottomLeft.y;
            maxY = topRight.y;
            
        // Start the spawn coroutine
        StartCoroutine(SpawnEnemies());
    }

    // Coroutine to spawn enemies
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Generate a random position within camera bounds
            Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            // Instantiate the enemy at the random position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Wait for the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
