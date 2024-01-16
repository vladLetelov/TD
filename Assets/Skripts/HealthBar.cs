using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Health playerHealth;
    public Transform playerTransform; // ƒобавл€ем Transform игрока
    public Vector3 offset; // ƒобавл€ем смещение полоски здоровь€ относительно игрока

    private void Start()
    {
        SetMaxHealth(playerHealth.maxHealth);
        transform.position = playerTransform.position + offset; // »нициализируем положение полоски здоровь€
    }

    private void Update()
    {
        SetHealth(playerHealth.health);
        transform.position = playerTransform.position + offset; // ќбновл€ем положение полоски здоровь€
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
