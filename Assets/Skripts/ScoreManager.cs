using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public int TotalCoins;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // ��������� ����������� ������ ��� ������� ����
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        scoreText.text = TotalCoins.ToString();
    }

    public void AddScore(int coinsToAdd)
    {
        TotalCoins += coinsToAdd;
        scoreText.text = TotalCoins.ToString();

        // ��������� ������, ���� �� ������ �������� ������������ �������
        if (TotalCoins > PlayerPrefs.GetInt("TotalCoins", 0))
        {
            PlayerPrefs.SetInt("TotalCoins", TotalCoins);
            PlayerPrefs.Save();
        }
    }
}
