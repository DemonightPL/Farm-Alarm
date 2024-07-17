using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectbuy : MonoBehaviour
{
    public GameObject building;
    private bool istouched;
    public MoneyManager moneyManager;
    public int price;
    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown(0) & istouched & moneyManager.money >= price)
        {
            moneyManager.DecreaseMoney(price);
            Instantiate(building, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }



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
}
