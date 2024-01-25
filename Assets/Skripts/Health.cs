using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    private CoinCounter counter;
    public int coinReward = 5;
    public GameObject pausePanel;
    public string baseTag = "Base";

    private void Start()
    {
        GameObject textMeshObject = GameObject.FindWithTag("CoinText");
        if (textMeshObject != null)
        {
            counter = textMeshObject.GetComponent<CoinCounter>();
        }
        else
        {
            Debug.LogWarning("Не удалось найти объект с тегом 'CoinText'.");
        }
    }

    public void TakeHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (counter != null)
            {
                counter.AddCoins(coinReward);
            }
            Destroy(gameObject);

            GameObject baseObject = GameObject.FindGameObjectWithTag(baseTag);
            if (baseObject != null && baseObject.CompareTag("Base"))
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }
}
