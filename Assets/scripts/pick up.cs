using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public bool isTouchingPickup = false;
    private GameObject currentPickup;
    private Collider2D possiblePickup;
    private Rigidbody2D rb;
    private bool holding = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //picking and droping
        if (Input.GetKeyDown(KeyCode.E) & isTouchingPickup ||  Input.GetKeyDown(KeyCode.E) & holding)
        { 
            if(holding)
            {
                Drop();
                
            }
            else
            {
             
                PickUp();
            }
           
        }
    
        if(holding)
        {
            currentPickup.transform.position = transform.position;
           

        }
    

        
        
    }
    

    // knowing if possible to pick
    void OnTriggerStay2D(Collider2D other)
    {
        isTouchingPickup= true;
        possiblePickup = other;

    }
    void OnTriggerExit2D(Collider2D collider)
    {
        isTouchingPickup= false;

    }


    void PickUp()
    {
        if (possiblePickup.gameObject.CompareTag("Pickup"))
        {
            currentPickup = possiblePickup.gameObject;
            //Debug.Log("Ready to pick up " + other.gameObject.name);
        }
        holding = true;
        currentPickup.GetComponent<Collider2D>().enabled = false;

    }
    void Drop()

    {
        currentPickup.GetComponent<Collider2D>().enabled = true;
        holding = false;

    }
        
}
