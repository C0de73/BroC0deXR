using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{

    public GameObject ammo;
    public Transform wherespawn;
    

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ammo, wherespawn.position, wherespawn.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
