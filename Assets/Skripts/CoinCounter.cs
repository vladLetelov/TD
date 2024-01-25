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
        StartCoroutine(AddCoinsOverTime()); // ��������� ��������
    }

    IEnumerator AddCoinsOverTime() // �������� ��� ���������� ����� ������ 10 ������
    {
        while (true) // ����������� ����
        {
            yield return new WaitForSeconds(10); // ���� 10 ������
            AddCoins(10); // ��������� 10 �����
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
        coinText.text = "������: " + coinCount.ToString();
    }

    public void AddCoinsDifferentMethod(int coinsToAdd)
    {
        coinCount += coinsToAdd;

        // ��������� ����� ���������� �����
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

