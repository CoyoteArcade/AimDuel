using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float sensitivity = 1.0f;
    private MouseLook playerLook;
    private MouseLook cameraLook;

    // Start is called before the first frame update
    void Start()
    {
        playerLook = this.gameObject.GetComponent<MouseLook>();
        cameraLook = GameObject.Find("Player/Main Camera").GetComponent<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SensController.Instance != null) {
            sensitivity = SensController.Instance.sensitivity;
        }

        playerLook.sensitivityHor = sensitivity;
        playerLook.sensitivityVert = sensitivity;
        cameraLook.sensitivityHor = sensitivity;
        cameraLook.sensitivityVert = sensitivity;
    }
}
