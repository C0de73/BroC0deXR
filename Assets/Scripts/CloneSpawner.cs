using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawner : MonoBehaviour
{
    public static GameObject objectToClone;
    public static Transform spawnPosition;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Or any other key/input
        {
            CreateClone();
        }
    }

    public static void CreateClone()
    {
        Instantiate(objectToClone, spawnPosition.position, spawnPosition.rotation);
    }
}