using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public bool enablePause = true; // ��������� ������� ���������� ��� ����� �����
    public GameObject exitPanel; // ��������� ���������� ��� ������ ������

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
        if (Input.GetKeyDown(KeyCode.Escape) && enablePause) // ���������, ������ �� ������� Esc � ����� ����� �������
        {
            TogglePause(); // �������� ����� ������������ �����
        }
    }

    void TogglePause()
    {
        if (Time.timeScale == 0) // ���������, ���� ����� ���������
        {
            Time.timeScale = 1; // ������������ �����
            exitPanel.SetActive(false); // ������ ������ ������ ����������
        }
        else
        {
            Time.timeScale = 0; // ��������� �����
            exitPanel.SetActive(true); // ������ ������ ������ ��������
        }
    }
}
