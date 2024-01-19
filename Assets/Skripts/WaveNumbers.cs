using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveNumbers : MonoBehaviour
{
    public Spawner spawner; // Ссылка на скрипт Spawner
    public TextMeshProUGUI waveText; // Ссылка на компонент TextMeshProUGUI для отображения номера волны

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
        waveText.text = "Волна: " + (spawner.currentWave - 1).ToString(); // Обновляем текст с номером волны
    }
}

