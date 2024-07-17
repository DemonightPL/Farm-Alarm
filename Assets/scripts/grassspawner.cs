using System.Collections;
using UnityEngine;

public class grassspawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float minX, maxX, minY, maxY;
    public float minSpawnTime, maxSpawnTime;
    public float ammount = 0f;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
           
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
            float spawnX = Random.Range(minX, maxX);
            float spawnY = Random.Range(minY, maxY);
            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            if(ammount < 10f){
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            ammount += 1f;
            }
            
            
        }
    }
}
