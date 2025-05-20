using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using TMPro;

public class EnemyKillTracker : MonoBehaviour
{
    public int killCount = 0;
    public TMP_Text killCounterText;  // << Use TMP_Text for TextMeshPro

    public static EnemyKillTracker instance;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public static void RegisterKill()
    {
        if (instance != null)
        {
            instance.killCount++;
            Debug.Log("Enemy killed. Total: " + instance.killCount);
            instance.UpdateKillCounterUI();
        }
    }

    void UpdateKillCounterUI()
    {
        if (killCounterText != null)
        {
            killCounterText.text = "Kills: " + killCount;
        }
    }
}