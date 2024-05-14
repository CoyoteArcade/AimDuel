using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject crosshair;
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        if (GameIsPaused) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        crosshair.SetActive(true);
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        crosshair.SetActive(false);
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Cursor.lockState = CursorLockMode.None;
        crosshair.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
}
