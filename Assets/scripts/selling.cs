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
            moneyManager.AddMoney(10);
           Destroy(other.gameObject);
           Debug.Log("sell");
        }
    }
}
