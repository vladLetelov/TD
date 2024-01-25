using System.Collections;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public int coinCount = 0;
    public TMPro.TextMeshProUGUI coinText;

    void Start()
    {
        UpdateCoinText();
        StartCoroutine(AddCoinsOverTime()); // Запускаем корутину
    }

    IEnumerator AddCoinsOverTime() // Корутина для добавления монет каждые 10 секунд
    {
        while (true) // Бесконечный цикл
        {
            yield return new WaitForSeconds(10); // Ждем 10 секунд
            AddCoins(10); // Добавляем 10 монет
        }
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateCoinText();
    }

    public void SpendCoins(int amount)
    {
        if (amount <= coinCount)
        {
            coinCount -= amount;
            UpdateCoinText();
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }

    public void UpdateCoinText()
    {
        coinText.text = "Монеты: " + coinCount.ToString();
    }

    public void AddCoinsDifferentMethod(int coinsToAdd)
    {
        coinCount += coinsToAdd;

        // Сохраняем общее количество монет
        PlayerPrefs.SetInt("TotalCoins", coinCount);
        PlayerPrefs.Save();
    }

    public void SaveCoinCountOnClick()
    {
        SaveCoinCount();
    }
    public void SaveCoinCount()
    {
        PlayerPrefs.SetInt("TotalCoins", coinCount);
        PlayerPrefs.Save();
    }
}

