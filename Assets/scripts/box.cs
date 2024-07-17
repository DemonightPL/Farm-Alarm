using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public bool istouched;
    public GameObject objectToSpawn;
    private float maxSpawnDistance = 2f;
    private float minSpawnDistance = 1f;
    public int items = 100;
    
   
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
        
         if (Input.GetMouseButtonDown(0) & istouched & items > 0)
        {
             ThrowObject();
             items-=10;

        }
        else if(items <= 0)
        {
            Destroy(gameObject);

        }
    }
    
    void ThrowObject()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector2 spawnPosition = (Vector2)transform.position + randomDirection * randomDistance;

        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    

        
    }
}
