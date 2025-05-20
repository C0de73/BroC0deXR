using UnityEngine;

public class KillReport2 : MonoBehaviour
{
    public void ReportKillAndDisable()
    {
        EnemyKillTracker.RegisterKill();
        gameObject.SetActive(false); // "Revive" later instead of destroy
    }
}


