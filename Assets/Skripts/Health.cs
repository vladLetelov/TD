using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    private CoinCounter counter; // Добавьте ссылку на CoinCounter

    private void Start()
    {
        // Предположим, что ваш объект TextMeshPro имеет тег "CoinText"
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
                counter.AddCoins(5); // Увеличиваем количество монет перед уничтожением объекта
            }
            Destroy(gameObject);
        }
    }
}
