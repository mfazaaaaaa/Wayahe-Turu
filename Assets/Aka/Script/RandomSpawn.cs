using UnityEngine;

public class RandomSpawn: MonoBehaviour
{
    // Array of prefabs to spawn
    public GameObject[] prefabs;

    // Range for random spawn positions (you can adjust these values as needed)
    public Vector3 spawnMin = new Vector3(-7, -3, 0);
    public Vector3 spawnMax = new Vector3(7, 3,0);

    // Minimum and maximum spawn intervals for randomizing spawn times for each prefab
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 5f;

    // Store the spawn intervals for each prefab
    private float[] spawnIntervals;

    void Start()
    {
        // Initialize an array for spawn intervals for each prefab
        spawnIntervals = new float[prefabs.Length];

        // Assign a random spawn interval for each prefab
        for (int i = 0; i < prefabs.Length; i++)
        {
            spawnIntervals[i] = Random.Range(minSpawnInterval,minSpawnInterval);
            // Start the spawning process for each prefab with its custom interval
            StartCoroutine(SpawnPrefabWithInterval(i, spawnIntervals[i]));
        }
    }

    System.Collections.IEnumerator SpawnPrefabWithInterval(int prefabIndex, float interval)
    {
        // Keep spawning the prefab indefinitely
        while (true)
        {
            // Generate a random position within the defined range
            float randomX = Random.Range(spawnMin.x, spawnMax.x);
            float randomY = Random.Range(spawnMin.y, spawnMax.y);
            float randomZ = Random.Range(spawnMin.z, spawnMax.z);
            Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

            // Instantiate the prefab at the random position
            Instantiate(prefabs[prefabIndex], randomPosition, Quaternion.identity);

            // Wait for the specified random interval before spawning again
            yield return new WaitForSeconds(interval);
        }
    }
}
