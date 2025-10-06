using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public int coinCount = 0;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateCoinText();
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + coinCount;
    }
}
