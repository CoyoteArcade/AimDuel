using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuController : MonoBehaviour
{
    public GameObject victoryMenu;
    public GameObject gameOverMenu;

    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        victoryMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.health <= 0)
        {
            // wait 1 second before showing the game over menu
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
        } else if( playerHealth.health > 0 && playerInventory.numOfCoins >= 8) {
            victoryMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Ventrilo...");
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");

    }
}
