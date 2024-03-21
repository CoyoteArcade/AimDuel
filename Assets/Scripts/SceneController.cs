using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
  private GameObject camera;
  private Camera cam;
  public float destroyDelay = 30f; // Time in seconds before the object is destroyed
    public float width;
    public float height;
    public int timer_posX;
    public int timer_posY;

    void Start()
    {
        camera = GameObject.Find("Player/Main Camera");
        cam = camera.GetComponent<Camera>();
        width = cam.pixelWidth;
        height = cam.pixelHeight;
        // Debug.Log($"Width: {width}");
        // Debug.Log($"Height: {height}");

        timer_posX = (int)width - 50;
        timer_posY = 15;
        
        InvokeRepeating("UpdateTimer", 0f, 1f); // Update timer every second
        Invoke("DestroyPlayer", destroyDelay); // Destroy object after delay
    }

    void OnGUI() {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 30;
        myStyle.normal.textColor = Color.white;

        GUI.Label(new Rect(timer_posX, timer_posY, 100, 20), $"{destroyDelay}", myStyle);
    }
    void UpdateTimer()
    {
        destroyDelay -= 1f;
        Debug.Log("Timer: " + destroyDelay + " secs");
    }

    void DestroyPlayer()
    {
        CancelInvoke("UpdateTimer"); // Stop updating timer
        Destroy(gameObject); // Destroy object
        // unlock cursor
        Cursor.lockState = CursorLockMode.None;
        // load EndMenu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndMenu");
    }
}

