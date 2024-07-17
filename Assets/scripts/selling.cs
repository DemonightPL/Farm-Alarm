using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selling : MonoBehaviour
{
    public MoneyManager moneyManager;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Hay"))
        {
            moneyManager.AddMoney(3);
           Destroy(other.gameObject);
           Debug.Log("sell");
        }
        else if (other.gameObject.CompareTag("Egg"))
        {
            moneyManager.AddMoney(20);
           Destroy(other.gameObject);
           Debug.Log("sell");
        }
         else if (other.gameObject.CompareTag("Milk"))
        {
            moneyManager.AddMoney(50);
           Destroy(other.gameObject);
           Debug.Log("sell");
        }
        else if (other.gameObject.CompareTag("Grass"))
        {
            moneyManager.AddMoney(2);
           Destroy(other.gameObject);
           Debug.Log("sell");
        }
        else if (other.gameObject.CompareTag("Chicken"))
        {
            moneyManager.AddMoney(80);
           Destroy(other.gameObject);
           Debug.Log("sell");
        }
    }
}
