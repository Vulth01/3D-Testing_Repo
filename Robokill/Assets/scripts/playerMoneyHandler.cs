using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerMoneyHandler : MonoBehaviour
{
    public int playerMoney;

    [SerializeField] private TextMeshProUGUI moneyTMP;

    private playerController player;

    public static playerMoneyHandler moneyInstance;




    void Awake()
    {
        moneyTMP.text = playerMoney.ToString();
        DontDestroyOnLoad(gameObject);
        if (moneyInstance == null)
        {
            moneyInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        player = FindObjectOfType<playerController>();
        Debug.Log(player);
    }
    public static void UpdateMoney(int amount)
    {
        moneyInstance.playerMoney += amount;

        moneyInstance.updateText();
    }

    public void purchaseItem(int itemIndex)
    {

       // if (moneyInstance.playerMoney > itemPrice)
        {
            //playerMoneyHandler.UpdateMoney(-itemPrice);
            FindObjectOfType<playerController>().PickUpFunct(itemIndex);
        }

    }

    private void updateText()
    {
        moneyTMP.text = playerMoney.ToString();
    }
}
