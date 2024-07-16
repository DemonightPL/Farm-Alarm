using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public GameObject haybox;
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

}