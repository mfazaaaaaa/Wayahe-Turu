using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] prefabs; // Array of enemy prefabs
    public Vector3 spawnMin = new Vector3(-7, -3, 0);
    public Vector3 spawnMax = new Vector3(7, 3, 0);

    public float waveDuration = 60f; // Duration of each wave in seconds
    public int maxGhostCount = 20; // Lose condition: Maximum number of ghosts allowed
    public float spawnInterval = 2f; // Interval between spawns

    private int currentWave = 1; // Current wave number
    private int ghostCount = 0; // Number of ghosts currently spawned
    private int randomGhost;
    public TextMeshProUGUI timerText;
    private bool gameActive = true;

    private List<GameObject> activeEnemies = new List<GameObject>(); // List to track spawned enemies
    private Coroutine spawningCoroutine; // Reference to the spawning Coroutine

    public GameObject[] waveUI;
    public GameObject exploxion; // explotion effect

    void Start()
    {
        StartCoroutine(WaveManager());
    }

    void Update()
    {
        CheckLoseCondition();
    }

    private IEnumerator WaveManager()
    {
        while (gameActive && currentWave <= 4)
        {
            Debug.Log($"Starting Wave {currentWave}");

            // Start spawning enemies for the current wave
            waveUI[currentWave-1].SetActive(true);
            yield return new WaitForSeconds(2f);
            waveUI[currentWave-1] .SetActive(false);
            spawningCoroutine = StartCoroutine(SpawnEnemiesForWave(currentWave));
            yield return StartCoroutine(StartWaveTimer(waveDuration));

            // Wait for the wave duration to finish
            StopCoroutine(spawningCoroutine);

            // Stop spawning and clear active enemies
            ClearEnemies();

            currentWave++;
        }

        if (currentWave > 4)
        {   
            // waveUI[currentWave-1].SetActive(true);
            yield return new WaitForSeconds(2f);
            // waveUI[currentWave-1] .SetActive(false);
            WinGame();
        }
    }

    private IEnumerator StartWaveTimer(float duration)
    {
        float remainingTime = duration;

        while (remainingTime > 0)
        {
            timerText.text = $"Time: {remainingTime:F1} s"; // Update TMP text with remaining time
            yield return new WaitForSeconds(0.1f); // Update every 0.1 seconds for smooth display
            remainingTime -= 0.1f;
        }

        timerText.text = "Time: 0.0 s"; // Ensure timer shows 0 at the end
    }

    private IEnumerator SpawnEnemiesForWave(int wave)
    {
        while (true) // Continuously spawn enemies
        {
            int prefabIndex = GetPrefabIndexForWave(wave);
            if (wave <= 3)
            {
                randomGhost = Random.Range(0, wave);
            }
            else
            {
                randomGhost = Random.Range(0, 3);
            }
            int spawnCount = (wave == 4) ? 2 : 1; // Spawn 3 enemies at a time in wave 4, otherwise 1

            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();
                GameObject enemy = Instantiate(
                    prefabs[randomGhost],
                    spawnPosition,
                    Quaternion.identity
                );
                activeEnemies.Add(enemy);
                ghostCount++;
            }

            yield return new WaitForSeconds(spawnInterval); // Wait before spawning more enemies
        }
    }

    private int GetPrefabIndexForWave(int wave)
    {
        // Each wave uses a specific prefab index
        return Mathf.Clamp(wave - 1, 0, prefabs.Length - 1);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(spawnMin.x, spawnMax.x);
        float randomY = Random.Range(spawnMin.y, spawnMax.y);
        float randomZ = Random.Range(spawnMin.z, spawnMax.z);
        return new Vector3(randomX, randomY, randomZ);
    }

    private void ClearEnemies()
    {
        for (GameObject enemy in activeEnemies)
        {
            if (enemy != null)
            {
                // Destroy the enemy
                GameObject spawnedObject = Instantiate(exploxion, enemy.transform.position, Quaternion.identity);
                Destroy(enemy);
            }
        }
        activeEnemies.Clear();
        Debug.Log("Enemies cleared.");
        ghostCount = 0;
    }

    private void CheckLoseCondition()
    {
        if (ghostCount >= maxGhostCount)
        {
            LoseGame();
        }
    }

    public void RegisterEnemyDestroyed(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
            ghostCount--;
        }
    }

    private void WinGame()
    {
        gameActive = false;
        ClearEnemies();
        Debug.Log("You win! All waves completed.");
        SceneManager.LoadScene("Win");
    }

    private void LoseGame()
    {
        gameActive = false;
        Debug.Log("You lose! Too many ghosts spawned.");
        SceneManager.LoadScene("Lose");
    }
}
