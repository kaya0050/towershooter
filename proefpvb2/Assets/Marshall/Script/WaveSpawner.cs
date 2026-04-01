using System.Collections;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int normalEnemies;
    public int bigEnemies;
    public int smallEnemies;
    public float spawnRate;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;

    public Transform spawnPoint;

    public GameObject normalEnemyPrefab;
    public GameObject bigEnemyPrefab;
    public GameObject smallEnemyPrefab;

    private int currentWaveIndex = 0;
    private bool isSpawning = false;

    void Start()
    {

    }

    public IEnumerator StartNextWave()
    {
        if (currentWaveIndex >= waves.Length)
        {
            Debug.Log("Alle waves voltooid!");
            yield break;
        }

        isSpawning = true;

        Wave wave = waves[currentWaveIndex];

        Debug.Log("Start wave: " + (currentWaveIndex + 1));

        yield return StartCoroutine(SpawnEnemies(wave));

        isSpawning = false;
        currentWaveIndex++;
    }

    IEnumerator SpawnEnemies(Wave wave)
    {
        for (int i = 0; i < wave.normalEnemies; i++)
        {
            SpawnEnemy(normalEnemyPrefab);
            yield return new WaitForSeconds(wave.spawnRate);
        }

        for (int i = 0; i < wave.bigEnemies; i++)
        {
            SpawnEnemy(bigEnemyPrefab);
            yield return new WaitForSeconds(wave.spawnRate);
        }

        for (int i = 0; i < wave.smallEnemies; i++)
        {
            SpawnEnemy(smallEnemyPrefab);
            yield return new WaitForSeconds(wave.spawnRate);
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
