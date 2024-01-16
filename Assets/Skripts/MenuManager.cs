using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
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
}
