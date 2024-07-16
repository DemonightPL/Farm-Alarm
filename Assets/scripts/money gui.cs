using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int money = 0;
    public TMP_Text moneyText;
    
    public void Start()
    {
      UpdateMoneyText();
    }
   public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }
    public void DecreaseMoney(int amount)
    {
        money -= amount;
        UpdateMoneyText();
    }


    void UpdateMoneyText()
    {
        moneyText.text = "Money: $" + money.ToString();
    }
}
