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
        // Загрузить сохраненный рекорд при запуске игры
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        scoreText.text = TotalCoins.ToString();
    }

    public void AddScore(int coinsToAdd)
    {
        TotalCoins += coinsToAdd;
        scoreText.text = TotalCoins.ToString();

        // Сохранить рекорд, если он больше текущего сохраненного рекорда
        if (TotalCoins > PlayerPrefs.GetInt("TotalCoins", 0))
        {
            PlayerPrefs.SetInt("TotalCoins", TotalCoins);
            PlayerPrefs.Save();
        }
    }
}
