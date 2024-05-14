using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentriloPauseMenu : MonoBehaviour
{
    public static bool VentriloIsPaused = false;
    public GameObject VentriloPauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        VentriloPauseMenuUI.SetActive(false);
        VentriloIsPaused = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!VentriloIsPaused)
            {
                Pause();
            }
        }

    }
    void Pause()
    {
        VentriloPauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        VentriloIsPaused = true;
    }
    public void Resume()
    {
        VentriloPauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        VentriloIsPaused = false;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Ventrilo...");
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");

    }
}
