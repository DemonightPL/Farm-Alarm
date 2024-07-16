using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public bool istouched;
    public GameObject objectToSpawn;
    public float maxSpawnDistance = 3f;
    public float minSpawnDistance = 1f;
   
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
             ThrowObject();

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
