using System.Collections;
using UnityEngine;

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
        if (isSpawning) yield break; // Prevent overlapping spawns
        isSpawning = true;

        while (spawnedCount < cap)
        {
            Transform chosenSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(objectToClone, chosenSpawn.position, chosenSpawn.rotation);
            spawnedCount++;

            yield return new WaitForSeconds(2f); // Delay before next spawn
        }

        isSpawning = false;
    }
}