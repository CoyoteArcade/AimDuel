using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadAimMap : MonoBehaviour
{
    public void LoadAimMap()
    {
        SceneManager.LoadScene("aim_map");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void LoadSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
