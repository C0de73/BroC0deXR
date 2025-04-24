using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawner : MonoBehaviour
{
    public static GameObject objectToClone;
    public static Transform spawnPosition;
    private static float secondsCount;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Or any other key/input
        {
            CreateClone();
            Instantiate(objectToClone, spawnPosition.position, spawnPosition.rotation); 
        }
    }

    public static void CreateClone()
    {
        Debug.Log(secondsCount);
        secondsCount += Time.deltaTime;

        if ((secondsCount%2) == 0)
        {
           

        }
        
    }
}