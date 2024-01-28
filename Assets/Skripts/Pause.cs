using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject menuPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        bool isActive = !menuPanel.activeSelf;
        menuPanel.SetActive(isActive);
        Time.timeScale = isActive ? 0f : 1f;
    }

    public void ResumeGame()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
