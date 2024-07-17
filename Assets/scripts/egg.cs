using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egg : MonoBehaviour
{
    private bool istouched;
    public GameObject chick;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hand"))
        {
            istouched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hand"))
        {
            istouched = false;
        }
    }

   

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) & istouched)
        {
            
            Instantiate(chick, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
