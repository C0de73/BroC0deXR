using System.Collections;
using UnityEngine;

public class CloneSpawner : MonoBehaviour
{
    public GameObject objectToClone;
    public Transform spawnPosition;

    private void Start()
    {
        StartCoroutine(SpawnAfterDelay());
    }

    IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(2f); // wait 2 seconds
        Instantiate(objectToClone, spawnPosition.position, spawnPosition.rotation);
    }
}