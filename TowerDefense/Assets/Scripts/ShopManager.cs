using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public static bool isBuyMode = false;
    public Button buyButton;

    void Start()
    {
        if (buyButton != null)
        {
            buyButton.onClick.AddListener(OnBuyButtonClicked);
            Debug.Log("Buy button listener added.");
        }
        else
        {
            Debug.LogError("Buy button is not assigned in the Inspector.");
        }
    }

    public void OnBuyButtonClicked()
    {
        isBuyMode = true;
        Debug.Log("Buy mode activated");
    }


}
