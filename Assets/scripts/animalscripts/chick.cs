using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : MonoBehaviour
{
    private Vector2 spawnPosition;
    public GameObject foodindicator;
    public float food;
    public float growth;
    public float growthRate = 0.01f;
    private bool ishungry;
    public GameObject adult;
    private GameObject newObject;
    // Start is called before the first frame update
   
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Grass"))
        {
            
            Destroy(other.gameObject);
            food = 1f;
            ishungry = false;
            Destroy(newObject);
            
        }
    }

     void FixedUpdate()
    {
        if(food > 0f)
        {
               
            food -= 0.1f * Time.deltaTime;
        }
        if (food < 0.2f && !ishungry)
        {
            Hungry();
            ishungry = true;
            
        }
        
        if(food > 0.4f)
        {
        Vector3 newScale = transform.localScale + Vector3.one * growthRate * Time.deltaTime;
        transform.localScale = newScale;
            growth+=1 * Time.deltaTime;
        }
        
        if(growth> 10)
        {
            Instantiate(adult, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    void Hungry()
    {
        spawnPosition = transform.position;
        spawnPosition.x -= 0.2f;
        spawnPosition.y += 0.2f;
        newObject = Instantiate(foodindicator, spawnPosition, transform.rotation);
        newObject.transform.parent = transform;
    }
    
    
}
