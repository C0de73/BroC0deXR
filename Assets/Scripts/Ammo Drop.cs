using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{

    public GameObject ammo;
    public Transform wherespawn;
    

    // Start is called before the first frame update
  

    public void DropAmmo()
    {
        Instantiate(ammo, wherespawn.position, wherespawn.rotation);
    }


}
