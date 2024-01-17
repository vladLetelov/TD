using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject healthBarPrefab;
    public int maxEnemy = 5;
    public Canvas canvas;

    public float timeSpawn = 2f;
    private float timer;

    public float distance = 3;

    public List<Wave> waves = new List<Wave>();

    public int currentWave = 1; // ��������� ���������� ��� �������� ������ ������� �����

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
                SpawnEnemy();
            }
        }

        if (currentWave <= waves.Count) // ���������, ��� ������� ����� �� ��������� ����� ���������� ����
        {
            if (transform.childCount == 0) // ���������, ��� ��� ����� ���������� ����� ���� ����������
            {
                StartNextWave(); // ��������� ��������� �����
            }
        }
    }

    private void StartNextWave()
    {
        if (currentWave <= waves.Count)
        {
            Wave wave = waves[currentWave - 1]; // �������� ������� ����� �� ������� ������� ����� - 1
            SpawnWave(wave); // ��������� ����� ��� ������� �����
            Debug.Log("������� �����: " + (currentWave - 1));
        }

        currentWave++; // ����������� ����� ������� �����


        if (currentWave -1 == waves.Count + 1)
        {
            currentWave += 1; // ���� ������� ����� ��������� ����� ���������� ����, ���������� ����� ������� ����� �� 1
        }

    }

    private void SpawnWave(Wave wave)
    {
        StartCoroutine(SpawnEnemiesWithDelay(wave.enemyCount, wave.enemyDistance));
    }

    private IEnumerator SpawnEnemiesWithDelay(int enemyCount, float enemyDistance)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(enemyDistance);
            yield return new WaitForSeconds(delay); // ��������� �������� ����� ������� ���������
        }
    }

    public float delay = 2f; // �������� 2f �� �������� ��������

    private void SpawnEnemy(float enemyDistance = 0f)
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefab, new Vector3(-110, 10, 90), Quaternion.identity, transform);
        spawnedEnemy.transform.rotation = Quaternion.Euler(0, 180, 0);

        GameObject healthBar = Instantiate(healthBarPrefab);
        healthBar.transform.SetParent(canvas.transform);
        healthBar.transform.localScale = new Vector3(9, 9, 9);

        Health enemyHealth = spawnedEnemy.GetComponent<Health>();
        healthBar.GetComponent<HealthBar>().playerHealth = enemyHealth;

        healthBar.GetComponent<HealthBar>().playerTransform = spawnedEnemy.transform;

        spawnedEnemy.transform.position += new Vector3(0, 0, enemyDistance);
    }
}

