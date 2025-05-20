using System.Collections;
using UnityEngine;
using TMPro;
using EmeraldAI;

public class WaveSpawner : MonoBehaviour
{
    public GameObject objectToClone;
    public Transform[] spawnPoints;

    public int initialEnemyCount = 3;
    public int incrementPerWave = 2;
    public float spawnDelay = 2f;
    public float waveDelay = 5f;

    public TMP_Text waveText;

    private int currentWave = 0;
    private int enemiesToSpawn = 0;
    private int enemiesSpawnedThisWave = 0;
    private int killsAtWaveStart = 0;

    private bool isSpawning = false;

    private void Start()
    {
        StartNextWave();
    }

    void StartNextWave()
    {
        currentWave++;
        enemiesToSpawn = initialEnemyCount + ((currentWave - 1) * incrementPerWave);
        enemiesSpawnedThisWave = 0;
        killsAtWaveStart = EnemyKillTracker.instance != null ? EnemyKillTracker.instance.killCount : 0;

        if (waveText != null)
            waveText.text = "Wave: " + currentWave;

        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        isSpawning = true;

        while (enemiesSpawnedThisWave < enemiesToSpawn)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject clone = Instantiate(objectToClone, spawnPoint.position, spawnPoint.rotation);

            clone.layer = LayerMask.NameToLayer("Enemy");

            // Emerald AI setup
            EmeraldSystem ai = clone.GetComponent<EmeraldSystem>();
            EmeraldHealth health = clone.GetComponent<EmeraldHealth>();

            if (ai != null)
            {
                ai.enabled = false;
                ai.enabled = true;

                if (ai.HealthComponent == null && health != null)
                    ai.HealthComponent = health;
            }

            enemiesSpawnedThisWave++;
            yield return new WaitForSeconds(spawnDelay);
        }

        isSpawning = false;

        // Wait for all enemies to be killed before starting next wave
        StartCoroutine(CheckForWaveCompletion());
    }

    IEnumerator CheckForWaveCompletion()
    {
        while ((EnemyKillTracker.instance != null ? EnemyKillTracker.instance.killCount : 0) < killsAtWaveStart + enemiesToSpawn)
        {
            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(waveDelay);
        StartNextWave();
    }
}
