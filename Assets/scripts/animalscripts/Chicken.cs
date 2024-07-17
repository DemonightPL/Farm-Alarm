using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public GameObject egg;
    public float food;
    private bool caneat;
   public GameObject foodindicator;
   public bool ishungry = false;
   private GameObject  newObject;
   private Vector2 spawnPosition;
    public void eggspawn()
    {
        Instantiate(egg, transform.position, Quaternion.identity);
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Grass") & caneat)
        {
            food=1f;
           Destroy(other.gameObject);
           full();
           caneat = false;
           ishungry = false;
        }
    }
    void FixedUpdate()
    {
        if(food > 0f)
        {
            
            food -= 0.1f * Time.deltaTime;
        }
        if(food< 0.5f)
        {
            caneat = true;
        }
        if(food < 0.2f & !ishungry)
        {
            Hungry();
            ishungry = true;
        }
        
        
    }

    void Hungry()
    {
        spawnPosition = transform.position;
        spawnPosition.x -=0.5f;
        spawnPosition.y +=0.5f;
        newObject = Instantiate(foodindicator, spawnPosition, transform.rotation);
        newObject.transform.parent = transform;
    }
    void full()
    {
        Destroy(newObject);
    }
}
