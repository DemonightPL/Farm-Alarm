using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : MonoBehaviour
{
    private Vector2 spawnPosition;
    public GameObject foodindicator;
    public float food;
    private bool ishungry;
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
