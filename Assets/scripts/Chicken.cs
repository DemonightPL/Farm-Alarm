using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public GameObject egg;
   
    public void eggspawn()
    {
        Instantiate(egg, transform.position, Quaternion.identity);
    }
}
