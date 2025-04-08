using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawner : MonoBehaviour
{
    public GameObject objectToClone;
    public Transform spawnPosition;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Or any other key/input
        {
            CreateClone();
        }
    }

    public void CreateClone()
    {
        Instantiate(objectToClone, spawnPosition.position, spawnPosition.rotation);
    }
}