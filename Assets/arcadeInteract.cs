using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Add this line if you are using TextMeshPro

public class arcadeInteract : MonoBehaviour
{
    private bool isPlayerNear = false;
    public TextMeshProUGUI interactionText;  // Change this to public Text if using standard UI Text

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            LoadScene();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            interactionText.gameObject.SetActive(true);  // Show the interaction text
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            interactionText.gameObject.SetActive(false);  // Hide the interaction text
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("main");  // Replace with your scene name
    }
}