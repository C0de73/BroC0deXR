using UnityEngine;

public class KillReport2 : MonoBehaviour
{
    public float destroyDelay = 3f;

    public void ReportKillAndDestroy()
    {
        EnemyKillTracker.RegisterKill();
        Destroy(gameObject, destroyDelay);
    }
}

