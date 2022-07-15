using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("MainIsland");
    }
    public void LoadGame()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
