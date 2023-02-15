using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// source: https://www.youtube.com/watch?v=JivuXdrIHK0

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUi;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    
    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void LoadMenu()
    {
        Debug.Log("Would load StartMenu ...");
        //TODO when issue 30 is merged:
        //SceneManager.LoadScene("Scenes/StartMenu");
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
