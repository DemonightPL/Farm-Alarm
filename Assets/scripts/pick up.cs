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
    private List<string> tagList = new List<string> { "Pickup", "Hay", "Chicken", "Egg", "Cow"};

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) & isTouchingPickup || Input.GetKeyDown(KeyCode.E) & holding)
        {
            if (holding)
            {
                Drop();
            }
            else
            {
                PickUp();
            }
        }

        if (holding)
        {
            currentPickup.transform.position = transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        isTouchingPickup = true;
        possiblePickup = other;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        isTouchingPickup = false;
    }

    void PickUp()
    {
        if (IsInTagList(possiblePickup.gameObject))
        {
            currentPickup = possiblePickup.gameObject;
            holding = true;
        currentPickup.GetComponent<Collider2D>().enabled = false;
        }
        
    }

    void Drop()
    {
        currentPickup.GetComponent<Collider2D>().enabled = true;
        holding = false;
    }

    bool IsInTagList(GameObject gameObject)
    {
        return tagList.Contains(gameObject.tag);
    }
}
