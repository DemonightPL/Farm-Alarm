using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float food;
    public bool caneat;
    public float fur;
    public bool cancut;
    public GameObject wool;
     private bool istouched;
    private ammountshower childScript;
    // Start is called before the first frame update
     void Start()
   {
    childScript = GetComponentInChildren<ammountshower>();
   }

    // Update is called once per frame
    void Update()
    {
        childScript.fillAmount = fur;

        if (Input.GetMouseButtonDown(0) & istouched & cancut)
        {
            cut();
           
            fur = 0f;
            cancut = false;
        }
    }

     void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Hay") & caneat)
        {
            food=1f;
           Destroy(other.gameObject);
           
           caneat = false;
          
        }

    }
     
     void cut()
     {
        Instantiate(wool, transform.position, transform.rotation);
     }
    void FixedUpdate()
    {
        if(fur < 1f)
        {
            fur += 0.1f * Time.deltaTime;
        }
        else
        {
            cancut = true;
        }
        

        if(food > 0f)
        {
            
            food -= 0.1f * Time.deltaTime;
        }
        if(food< 0.5f)
        {
            caneat = true;
        }
    }
        
         void OnTriggerEnter2D(Collider2D other)
         {
         if (other.CompareTag("Hand"))
         {
            istouched = true;
         }
         }

   void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hand"))
        {
            istouched = false;
        }
    }
        
   
        
}

