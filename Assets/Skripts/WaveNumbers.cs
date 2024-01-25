using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveNumbers : MonoBehaviour
{
    public SecondSpawner secondSpawner;
    public Spawner spawner; // ������ �� ������ Spawner
    public TextMeshProUGUI waveText; // ������ �� ��������� TextMeshProUGUI ��� ����������� ������ �����

    private void Start()
    {
        UpdateWaveText();
    }

    private void Update()
    {
        if (spawner == null)
        {
            return;
        }

        if (spawner.waves == null)
        {
            return;
        }

        if (spawner.currentWave >= 0 && spawner.currentWave <= spawner.waves.Count)
        {
            UpdateWaveText();
        }
    }

    private void UpdateWaveText()
    {
        int enemyCount = 0; // ���������� ��� �������� ���������� ������

        if (spawner != null && spawner.waves != null)
        {
                if (spawner.currentWave >= 2 && spawner.currentWave < spawner.waves.Count + 1)
                {
                    if (spawner.currentWave < 4)
                    {
                        enemyCount = spawner.waves[spawner.currentWave - 2].enemyCount; // �������� ���������� ������ �� ������� ����� ������� ��������
                    }
                    else
                    {
                        if (secondSpawner != null && secondSpawner.waves != null && secondSpawner.currentWave >= 2 && secondSpawner.currentWave < secondSpawner.waves.Count + 1)
                        {
                            enemyCount = spawner.waves[spawner.currentWave - 2].enemyCount + secondSpawner.waves[secondSpawner.currentWave - 2].enemyCount; // �������� ����� ���������� ������ �� ������� ����� ������� � ������� ���������
                        }
                        else
                        {
                            enemyCount = spawner.waves[spawner.currentWave - 2].enemyCount; // ���� ������ ������� �� ��������������� ��� ������ ���� ����, ���������� ������ ���������� ������ �� ������� ��������
                        }
                    }
                }
        }

        waveText.text = "�����: " + (spawner.currentWave - 1).ToString() + ", �����: " + enemyCount.ToString(); // ��������� ����� � ������� ����� � ����������� ������
    }




}

