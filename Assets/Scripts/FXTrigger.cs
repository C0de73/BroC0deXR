using UnityEngine;

public class FXTrigger : MonoBehaviour
{
    public GameObject targetObject;         // The object to detect collision with
    public GameObject fxPrefab;             // The visual effect to instantiate
    public Transform fxSpawnPoint;          // Optional: where to spawn the FX (default is collision point)

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetObject)
        {
            Vector3 spawnPosition = fxSpawnPoint ? fxSpawnPoint.position : transform.position;
            Instantiate(fxPrefab, spawnPosition, Quaternion.identity);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, GetComponent<SphereCollider>().radius);
    }
}