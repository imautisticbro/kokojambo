
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollect : MonoBehaviour
{
    public int Coins = 0;
    public TextMeshProUGUI CoinText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Coins += 1;
            UpdateCoinText();
            Destroy(other.gameObject);
        }
    }

    private void UpdateCoinText()
    {
        CoinText.text = Coins.ToString();
    }
}
