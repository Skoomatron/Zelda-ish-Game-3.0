using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;
    public string mainMenu;
    void Start()
    {
        isPaused = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("Paused"))
        {
            Resume();
        }
    }
    public void Resume()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void QuitGame()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
