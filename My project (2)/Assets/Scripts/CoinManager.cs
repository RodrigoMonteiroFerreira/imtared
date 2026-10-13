
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int coins = 0;
    public Text coinText;

    private void Awake()
    {
        Instance = this;
        UpdateUI();
    }

    public void AddCoin()
    {
        coins++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Moedas: " + coins;
        }
    }
}