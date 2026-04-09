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

    public PhaseSwitchScript phases;
    public InterfaceScript hud;

    public GameObject normalEnemyPrefab;
    public GameObject bigEnemyPrefab;
    public GameObject smallEnemyPrefab;
    public GameObject WinScherm;

    public int teSpawnenVijanden;
    public int verslagenVijanden;
    public int currentWaveIndex = 0;
    public bool isSpawning = false;

    void Start()
    {
        
    }

    private void Update()
    {
        if (currentWaveIndex >= waves.Length)
        {
            WinScherm.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public IEnumerator StartNextWave()
    {
        hud.updateWave();
        teSpawnenVijanden = 0;
        verslagenVijanden = 0;

        if (currentWaveIndex >= waves.Length)
        {
            Debug.Log("Alle waves voltooid!");
            yield break;
        }

        isSpawning = true;

        Wave wave = waves[currentWaveIndex];

        teSpawnenVijanden = wave.normalEnemies + wave.bigEnemies + wave.smallEnemies;

        Debug.Log("Start wave: " + (currentWaveIndex + 1));
        Debug.Log("Te spawnen vijanden: " + teSpawnenVijanden);


        yield return StartCoroutine(SpawnEnemies(wave));

        isSpawning = false;
        currentWaveIndex++;
    }

    IEnumerator SpawnEnemies(Wave wave)
    {
        for (int i = 0; i < wave.normalEnemies; i++)
        {
            phases.levendeEnemies++;
            SpawnEnemy(normalEnemyPrefab);
            yield return new WaitForSeconds(wave.spawnRate);
        }

        for (int i = 0; i < wave.bigEnemies; i++)
        {
            phases.levendeEnemies++;
            SpawnEnemy(bigEnemyPrefab);
            yield return new WaitForSeconds(wave.spawnRate);
        }

        for (int i = 0; i < wave.smallEnemies; i++)
        {
            phases.levendeEnemies++;
            SpawnEnemy(smallEnemyPrefab);
            yield return new WaitForSeconds(wave.spawnRate);
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
