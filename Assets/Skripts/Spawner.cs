using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject healthBarPrefab; // ��������� ������� �������� ��� ������
    public int maxEnemy = 5;
    public Canvas canvas; // ��������� ������ �� Canvas

    public float timeSpawn = 2f;
    private float timer;

    public float distance = 3;

    private void Start()
    {
        timer = timeSpawn;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeSpawn;
            if (transform.childCount < maxEnemy)
            {
                GameObject spawnedEnemy = Instantiate(enemyPrefab, new Vector3(-110, 10, 90), Quaternion.identity, transform);
                spawnedEnemy.transform.rotation = Quaternion.Euler(0, 180, 0); // Rotate the enemy object

                GameObject healthBar = Instantiate(healthBarPrefab); // ������� ��������� ������� ��������
                healthBar.transform.SetParent(canvas.transform); // ��������� ������� �������� � Canvas
                healthBar.transform.localScale = new Vector3(9, 9, 9); // ������������� scale � 9

                Health enemyHealth = spawnedEnemy.GetComponent<Health>(); // �������� ��������� Health �����
                healthBar.GetComponent<HealthBar>().playerHealth = enemyHealth; // ������������� playerHealth � HealthBar

                healthBar.GetComponent<HealthBar>().playerTransform = spawnedEnemy.transform; // ��������� ������� �������� � ������
            }
        }
    }
}
