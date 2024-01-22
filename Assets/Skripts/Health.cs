using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    private CoinCounter counter; // �������� ������ �� CoinCounter

    private void Start()
    {
        // �����������, ��� ��� ������ TextMeshPro ����� ��� "CoinText"
        GameObject textMeshObject = GameObject.FindWithTag("CoinText");
        if (textMeshObject != null)
        {
            counter = textMeshObject.GetComponent<CoinCounter>();
        }
        else
        {
            Debug.LogWarning("�� ������� ����� ������ � ����� 'CoinText'.");
        }
    }

    public void TakeHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (counter != null)
            {
                counter.AddCoins(5); // ����������� ���������� ����� ����� ������������ �������
            }
            Destroy(gameObject);
        }
    }
}
