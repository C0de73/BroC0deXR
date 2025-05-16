using System.Collections;
using UnityEngine;
using EmeraldAI;

public class CloneSpawner : MonoBehaviour
{
    public GameObject objectToClone;
    public Transform[] spawnPoints;
    public int cap;

    private int spawnedCount = 0;
    private bool isSpawning = false;

    private void Start()
    {
        StartCoroutine(SpawnClonesWithDelay());
    }

    IEnumerator SpawnClonesWithDelay()
    {
        if (isSpawning) yield break;
        isSpawning = true;

        while (spawnedCount < cap)
        {
            Transform chosenSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject clone = Instantiate(objectToClone, chosenSpawn.position, chosenSpawn.rotation);

            // Set proper layer
            clone.layer = LayerMask.NameToLayer("Enemy");

            // Initialize Emerald AI manually
            EmeraldSystem ai = clone.GetComponent<EmeraldSystem>();
            EmeraldHealth health = clone.GetComponent<EmeraldHealth>();

            if (ai != null)
            {
                // Force re-enable to simulate setup
                ai.enabled = false;
                ai.enabled = true;

                if (ai.HealthComponent == null && health != null)
                    ai.HealthComponent = health;
            }

            spawnedCount++;
            yield return new WaitForSeconds(2f);
        }

        isSpawning = false;
    }
}