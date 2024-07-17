using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public GameObject haybox;
    public GameObject chicken;
    public GameObject fence;
    public GameObject cow;
    public MoneyManager moneyManager;
    public Vector2 spawnPosition;
    public GameObject seeds;
    public GameObject sheep;
    // Start is called before the first frame update
    void Start()
    {
       spawnPosition = new Vector2(-5, 3);
    }

    public void buyhaybox()
    {
        if(moneyManager.money >= 45)
        {
            moneyManager.DecreaseMoney(45);
        Instantiate(haybox, spawnPosition, Quaternion.identity);
        }
        
    }
    public void buychicken()
    {
         if(moneyManager.money >= 100)
        {
        moneyManager.DecreaseMoney(100);
        Instantiate(chicken, spawnPosition, Quaternion.identity);
        }
    }
    public void buyfence()
    {
         if(moneyManager.money >= 10)
        {
        moneyManager.DecreaseMoney(10);
        Instantiate(fence, spawnPosition, Quaternion.identity);
        }
    }
    public void buycow()
    {
         if(moneyManager.money >= 300)
        {
        moneyManager.DecreaseMoney(300);
        Instantiate(cow, spawnPosition, Quaternion.identity);
        }
    }
    public void buyseeds()
    {
         if(moneyManager.money >= 10)
        {
        moneyManager.DecreaseMoney(10);
        Instantiate(seeds, spawnPosition, Quaternion.identity);
        }
    }
    public void buysheep()
    {
         if(moneyManager.money >= 1000)
        {
        moneyManager.DecreaseMoney(1000);
        Instantiate(sheep, spawnPosition, Quaternion.identity);
        }
    }
}
