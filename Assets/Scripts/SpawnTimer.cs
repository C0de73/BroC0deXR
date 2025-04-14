using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{

    private float secondsCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(secondsCount);
        secondsCount += Time.deltaTime;

        if ((secondsCount%2) == 0)
        {
            CloneSpawner.CreateClone();

        }
    }
}
