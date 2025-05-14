using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public float range = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(20)) // Left click
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                Debug.Log("Hit: " + hit.transform.name);
                var ai = hit.transform.GetComponentInParent<EmeraldAI.EmeraldSystem>();
                if (ai != null)
                {
                    ai.HealthComponent.Damage(25, null, 0, false);
                    Debug.Log("Damaged AI: " + ai.name);
                }
            }
            else
            {
                Debug.Log("Missed!");
            }
        }
    }
}
