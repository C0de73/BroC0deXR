using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EmeraldAI;

public class WaveSpawner : MonoBehaviour
{
    public GameObject objectToClone;
    public Transform[] spawnPoints;

    public int initialEnemyCount = 3;
    public int incrementPerWave = 2;
    public float spawnDelay = 0.5f;
    public float waveDelay = 3f;

    public TMP_Text waveText;

    private int currentWave = 0;
    private int killsAtWaveStart = 0;
    private List<GameObject> enemyPool = new List<GameObject>();

    private void Start()
    {
        StartNextWave();
    }

    void StartNextWave()
    {
        currentWave++;
        int enemiesThisWave = initialEnemyCount + ((currentWave - 1) * incrementPerWave);
        killsAtWaveStart = EnemyKillTracker.instance != null ? EnemyKillTracker.instance.killCount : 0;

        if (waveText != null)
            waveText.text = "Wave: " + currentWave;

        StartCoroutine(SpawnWave(enemiesThisWave));
    }

    IEnumerator SpawnWave(int enemyCount)
    {
        int spawned = 0;

        for (int i = 0; i < enemyCount; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = GetPooledEnemy();

            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = spawnPoint.rotation;
            enemy.SetActive(true);

            // Reset health and AI
            EmeraldSystem ai = enemy.GetComponent<EmeraldSystem>();
            EmeraldHealth health = enemy.GetComponent<EmeraldHealth>();
            if (ai != null)
            {
                ai.enabled = false;
                ai.enabled = true;
                if (ai.HealthComponent == null && health != null)
                    ai.HealthComponent = health;
                if (health != null)
                {
                    health.CurrentHealth = health.StartingHealth;
                }
            }

            spawned++;
            yield return new WaitForSeconds(spawnDelay);
        }

        // Wait for kills before next wave
        StartCoroutine(CheckForWaveCompletion(enemyCount));
    }

    IEnumerator CheckForWaveCompletion(int waveSize)
    {
        while ((EnemyKillTracker.instance != null ? EnemyKillTracker.instance.killCount : 0) < killsAtWaveStart + waveSize)
        {
            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(waveDelay);
        StartNextWave();
    }

    GameObject GetPooledEnemy()
    {
        foreach (GameObject e in enemyPool)
        {
            if (!e.activeInHierarchy)
                return e;
        }

        // None available — create a new one
        GameObject newEnemy = Instantiate(objectToClone);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }
}
