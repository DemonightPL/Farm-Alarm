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
    // Start is called before the first frame update
    void Start()
    {
       spawnPosition = new Vector2(-5, 3);
    }

    public void buyhaybox()
    {
        moneyManager.DecreaseMoney(45);
        Instantiate(haybox, spawnPosition, Quaternion.identity);
    }
    public void buychicken()
    {
        moneyManager.DecreaseMoney(100);
        Instantiate(chicken, spawnPosition, Quaternion.identity);
    }
    public void buyfence()
    {
        moneyManager.DecreaseMoney(10);
        Instantiate(fence, spawnPosition, Quaternion.identity);
    }
    public void buycow()
    {
        moneyManager.DecreaseMoney(300);
        Instantiate(cow, spawnPosition, Quaternion.identity);
    }
}
