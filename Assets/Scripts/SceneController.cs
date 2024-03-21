using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
  public float destroyDelay = 10f; // Time in seconds before the object is destroyed

    void Start()
    {
        InvokeRepeating("UpdateTimer", 0f, 1f); // Update timer every second
        Invoke("DestroyPlayer", destroyDelay); // Destroy object after delay
    }

    void UpdateTimer()
    {
        destroyDelay -= 1f;
        Debug.Log("Timer: " + destroyDelay + " secs");
    }

    void DestroyPlayer()
    {
        CancelInvoke("UpdateTimer"); // Stop updating timer
        //Destroy(gameObject); // Destroy object
    }
}

