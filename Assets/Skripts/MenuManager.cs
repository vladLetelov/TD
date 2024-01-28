using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public bool enablePause = true; // Добавляем булевую переменную для опции паузы
    public GameObject exitPanel; // Добавляем переменную для панели выхода

    public void ChangeScene(int scene)
    {
        if (scene != -1)
        {
            SceneManager.LoadScene(scene);
        }
        else
        {
            ExitGame();
        }
    }

    void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && enablePause) // Проверяем, нажата ли клавиша Esc и опция паузы активна
        {
            TogglePause(); // Вызываем метод переключения паузы
        }
    }

    void TogglePause()
    {
        if (Time.timeScale == 0) // Проверяем, если время замедлено
        {
            Time.timeScale = 1; // Возобновляем время
            exitPanel.SetActive(false); // Делаем панель выхода неактивной
        }
        else
        {
            Time.timeScale = 0; // Замедляем время
            exitPanel.SetActive(true); // Делаем панель выхода активной
        }
    }
}
