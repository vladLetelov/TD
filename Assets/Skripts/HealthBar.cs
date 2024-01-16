using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Health playerHealth;
    public Transform playerTransform; // ��������� Transform ������
    public Vector3 offset; // ��������� �������� ������� �������� ������������ ������

    private void Start()
    {
        SetMaxHealth(playerHealth.maxHealth);
        transform.position = playerTransform.position + offset; // �������������� ��������� ������� ��������
    }

    private void Update()
    {
        SetHealth(playerHealth.health);
        transform.position = playerTransform.position + offset; // ��������� ��������� ������� ��������
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
