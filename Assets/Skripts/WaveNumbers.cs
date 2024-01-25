using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveNumbers : MonoBehaviour
{
    public SecondSpawner secondSpawner;
    public Spawner spawner; // —сылка на скрипт Spawner
    public TextMeshProUGUI waveText; // —сылка на компонент TextMeshProUGUI дл€ отображени€ номера волны

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
        int enemyCount = 0; // ѕеременна€ дл€ хранени€ количества врагов

        if (spawner != null && spawner.waves != null)
        {
                if (spawner.currentWave >= 2 && spawner.currentWave < spawner.waves.Count + 1)
                {
                    if (spawner.currentWave < 4)
                    {
                        enemyCount = spawner.waves[spawner.currentWave - 2].enemyCount; // ѕолучаем количество врагов из текущей волны первого спавнера
                    }
                    else
                    {
                        if (secondSpawner != null && secondSpawner.waves != null && secondSpawner.currentWave >= 2 && secondSpawner.currentWave < secondSpawner.waves.Count + 1)
                        {
                            enemyCount = spawner.waves[spawner.currentWave - 2].enemyCount + secondSpawner.waves[secondSpawner.currentWave - 2].enemyCount; // ѕолучаем сумму количества врагов из текущей волны первого и второго спавнеров
                        }
                        else
                        {
                            enemyCount = spawner.waves[spawner.currentWave - 2].enemyCount; // ≈сли второй спавнер не инициализирован или список волн пуст, используем только количество врагов из первого спавнера
                        }
                    }
                }
        }

        waveText.text = "¬олна: " + (spawner.currentWave - 1).ToString() + ", ¬раги: " + enemyCount.ToString(); // ќбновл€ем текст с номером волны и количеством врагов
    }




}

