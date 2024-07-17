using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pancakes : MonoBehaviour
{
    public GameObject pancake;
    
    public float fammount = 0f;
    public float eammount = 0f;
    public float mammount = 0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(mil());
    }

    


     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flour"))
        {
            Destroy(other.gameObject);
            
            fammount +=1;
        }
        else if (other.CompareTag("Egg"))
        {
            Destroy(other.gameObject);
            
            eammount +=1;
        }
        else if (other.CompareTag("Milk"))
        {
            Destroy(other.gameObject);
            
            mammount +=1;
        }
        
    }


    IEnumerator mil()
    {
        while (true)
        {
        
            yield return new WaitForSeconds(20f);
        if(eammount > 0  & fammount > 1 & mammount > 0)
        {
            
            eammount -=1;
            fammount -=2;
            mammount -=1;
         Instantiate(pancake, transform.position, transform.rotation);
         
        }
        
        }
    }
}
