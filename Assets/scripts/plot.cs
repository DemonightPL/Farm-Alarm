using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plot : MonoBehaviour
{
    public GameObject Hay;
    public float minX, maxX, minY, maxY;
    public float minSpawnTime, maxSpawnTime;
    public float ammount = 0f;
    private bool hasseeds;
    private bool canspawn;
   void Start()
   {
        StartCoroutine(SpawnHay());
   }
    void Update()
    {
        if(ammount > 10f)
        {
            ammount = 0f;
            
            hasseeds = false;
            canspawn = false;
        }
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Seeds") & !hasseeds)
        {
            Destroy(other.gameObject);
            hasseeds = true;
            StartCoroutine(SetSeedsAfterDelay());
            
        }
    }

    IEnumerator SetSeedsAfterDelay()
    {
        yield return new WaitForSeconds(10f);
        canspawn = true;
    }

    IEnumerator SpawnHay()
    {
        while (true)
        {
          
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
            float spawnX = Random.Range(minX, maxX);
            float spawnY = Random.Range(minY, maxY);
            Vector2 spawnPosition = new Vector2(transform.position.x + spawnX, transform.position.y + spawnY);
            if(canspawn)
            {
            Instantiate(Hay, spawnPosition, Quaternion.identity);
            ammount += 1f;
            
            }
            
        }
    }

     
}
